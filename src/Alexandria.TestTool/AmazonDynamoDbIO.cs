using System.Linq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Alexandria.Test
{
    public readonly struct AmazonDynamoDbIO : Traits.AmazonDynamoDbIO
    {
        public AmazonDynamoDbIO(IAmazonDynamoDB mockDynamoDb) => MockDynamoDb = mockDynamoDb;

        public IAmazonDynamoDB MockDynamoDb { get; }

        public IAmazonDynamoDB Connect(RegionEndpoint region) =>
            MockDynamoDb;
    }
}
