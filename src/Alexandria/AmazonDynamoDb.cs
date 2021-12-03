using Amazon;
using Amazon.DynamoDBv2;
using LanguageExt;
using LanguageExt.Sys.Traits;
using static LanguageExt.Prelude;

namespace Alexandria
{
    public static class AmazonDynamoDb<RT>
        where RT : struct, HasAmazonDynamoDb<RT>
    {
        public static Eff<RT, IAmazonDynamoDB> connectDyanmoDb(RegionEndpoint region) =>
            default(RT).AmazonDynamoDbEff.Map(x => x.Connect(region));
    }
}
