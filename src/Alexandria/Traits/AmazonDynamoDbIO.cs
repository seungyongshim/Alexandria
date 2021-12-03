using Amazon;
using Amazon.DynamoDBv2;
using LanguageExt;
using LanguageExt.Attributes;
using LanguageExt.Effects.Traits;

namespace LanguageExt.Sys.Traits
{
    public interface AmazonDynamoDbIO
    {
        IAmazonDynamoDB Connect(RegionEndpoint region);
    }

    [Typeclass("*")]
    public interface HasAmazonDynamoDb<RT> : HasCancel<RT>
        where RT : struct, HasCancel<RT>
    {
        Eff<RT, AmazonDynamoDbIO> AmazonDynamoDbEff { get; }
    }
}
