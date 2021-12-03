using System;
using System.Threading.Tasks;
using Alexandria.Test;
using Xunit;

namespace Alexandria.Tests
{
    public class AmazonDynamoDbSpec
    {
        [Fact]
        public Task Connect()
        {
            var rt = Runtime.New();
        }
    }
}
