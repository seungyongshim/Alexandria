using Amazon;
using Amazon.DynamoDBv2;

namespace Alexandria.Test
{
    public readonly struct AmazonDynamoDbIO : LanguageExt.Sys.Traits.AmazonDynamoDbIO
    {
        public AmazonDynamoDbIO(IAmazonDynamoDB mockDynamoDb) => MockDynamoDb = mockDynamoDb;

        public IAmazonDynamoDB MockDynamoDb { get; }

        public IAmazonDynamoDB Connect(RegionEndpoint region) =>
            MockDynamoDb;
    }
}
