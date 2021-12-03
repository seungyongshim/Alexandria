using Amazon;
using Amazon.DynamoDBv2;

namespace Alexandria.Live
{
    public readonly struct AmazonDynamoDbIO : LanguageExt.Sys.Traits.AmazonDynamoDbIO
    {
        public IAmazonDynamoDB Connect(RegionEndpoint region) =>
            new AmazonDynamoDBClient(region);
    }
}
