using Azure.Core;
using Azure.Messaging.WebPubSub;

namespace Without.Systems.AzureWebPubSub;

public class AzureWebPubSub : IAzureWebPubSub
{
   public bool GroupExists(string connectionString, string hub, string group)
   {
      WebPubSubServiceClient client = GetWebPubSubServiceClient(connectionString, hub);
      return client.GroupExists(group);
   }

   public void SendToGroup(string connectionString, string hub, string group, string content,
      string contentType = "text")
   {
      WebPubSubServiceClient client = GetWebPubSubServiceClient(connectionString, hub);
      client.SendToGroup(group, content, ParseContentType(contentType));
   }

   public void SendToUser(string connectionString, string userId, string content, string contentType = "text")
   {
      WebPubSubServiceClient client = GetWebPubSubServiceClient(connectionString, userId);
      client.SendToUser(userId, content, ParseContentType(contentType));
   }

   public void SendToAll(string connectionString, string hub, string content,
      string contentType = "text")
   {
      WebPubSubServiceClient client = GetWebPubSubServiceClient(connectionString, hub);
      client.SendToAll(content, ParseContentType(contentType));
   }

   public void RemoveUserFromGroup(string connectionString, string hub, string group, string userId)
   {
      WebPubSubServiceClient client = GetWebPubSubServiceClient(connectionString, hub);
      client.RemoveUserFromGroup(group, userId);
   }

   public void RemoveUserFromAllGroups(string connectionString, string hub, string userId)
   {
      WebPubSubServiceClient  client = GetWebPubSubServiceClient(connectionString, hub);
      client.RemoveUserFromAllGroups(userId);
   }

   public void AddUserToGroup(string connectionString, string hub, string group, string userId)
   {
      WebPubSubServiceClient  client = GetWebPubSubServiceClient(connectionString, hub);
      client.AddUserToGroup(group, userId);
   }

   public string GetClientAccessUri(string connectionString, string hub, string userId, int tokenLifespan = 120)
   {
      WebPubSubServiceClient  client = GetWebPubSubServiceClient(connectionString, hub);
      var response = client.GetClientAccessUri(TimeSpan.FromMinutes(tokenLifespan), userId);
      return response.AbsoluteUri;
   }
   
   private static ContentType ParseContentType(string contentType)
   {
      return contentType switch
      {
         "text" => ContentType.TextPlain,
         "json" => ContentType.ApplicationJson,
         _ => throw new ArgumentException($"Invalid message content type of {contentType}")
      };
   }
   
   
   private WebPubSubServiceClient GetWebPubSubServiceClient(string connectionString, string hub)
   {
      return new WebPubSubServiceClient(connectionString, hub);
   }
}