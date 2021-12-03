using System;
using System.Text;
using System.Threading;
using LanguageExt;
using LanguageExt.Effects.Traits;
using LanguageExt.Sys;
using LanguageExt.Sys.Test;
using LanguageExt.Sys.Traits;
using static LanguageExt.Prelude;
using Traits = LanguageExt.Sys.Traits;


namespace Alexandria.Tests
{
    /// <summary>
    /// Test IO runtime
    /// </summary>
    public readonly struct Runtime :
        HasCancel<Runtime>,
        HasAmazonDynamoDb<Runtime>
    {
        public readonly RuntimeEnv env;

        Runtime(RuntimeEnv env) =>
            this.env = env;

        public RuntimeEnv Env =>
            env ?? throw new InvalidOperationException("Runtime Env not set.  Perhaps because of using default(Runtime) or new Runtime() rather than Runtime.New()");

        public static Runtime New(TestTimeSpec? timeSpec = default) =>
            new Runtime(new RuntimeEnv(new CancellationTokenSource(),
                                       Encoding.Default,
                                       new MemoryConsole(),
                                       new MemoryFS(),
                                       timeSpec,
                                       MemorySystemEnvironment.InitFromSystem()));

        public static Runtime New(CancellationTokenSource source, TestTimeSpec? timeSpec = default) =>
            new Runtime(new RuntimeEnv(source,
                                       Encoding.Default,
                                       new MemoryConsole(),
                                       new MemoryFS(),
                                       timeSpec,
                                       MemorySystemEnvironment.InitFromSystem()));

        public Runtime LocalCancel =>
            new Runtime(Env.LocalCancel);

        public CancellationToken CancellationToken => Env.Token;

        public CancellationTokenSource CancellationTokenSource => Env.Source;

        public Eff<Runtime, AmazonDynamoDbIO> AmazonDynamoDbEff =>
            Eff<Runtime, Traits.AmazonDynamoDbIO>(rt => new Test.AmazonDynamoDbIO(rt.Env.Console));
    }

    public class RuntimeEnv
    {
        public readonly CancellationTokenSource Source;
        public readonly CancellationToken Token;

        public RuntimeEnv(
            CancellationTokenSource source,
            CancellationToken token)
        {
            Source = source;
            Token = token;
        }
    }
}
