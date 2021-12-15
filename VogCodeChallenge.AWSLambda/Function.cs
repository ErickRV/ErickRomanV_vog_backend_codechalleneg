using System;
using System.IO;
using System.Text;

using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace VogCodeChallenge.AWSLambda
{
    public class Function
    {
        public void FunctionHandler(DynamoDBEvent dynamoEvent, ILambdaContext context)
        {
            foreach (var record in dynamoEvent.Records)
            {
                if (record.EventName == OperationType.MODIFY) {
                    if (record.Dynamodb.Keys.TryGetValue("id", out AttributeValue value))
                    {
                        context.Logger.LogLine($"DynamoDb item with id: {value.S} was updated");
                    }
                    else {
                        context.Logger.LogLine("ERROR! An updated whithout id was recived!!!!");
                    }
                }
            }
        }
    }
}