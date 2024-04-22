using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.AzureWebPubSub;

[OSInterface(
    Name = "AzureWebPubSub",
    Description = "Azure Web PubSub connector library",
    IconResourceName = "Without.Systems.AzureWebPubSub.Resources.WebPubSub.png")]
public interface IAzureWebPubSub
{
    [OSAction(
        Description = "Check if there are any client connections in a group",
        ReturnName = "result",
        ReturnDescription = "True if there are connections within the group",
        ReturnType = OSDataType.Boolean,
        IconResourceName = "Without.Systems.AzureWebPubSub.Resources.WebPubSub.png")]
    bool GroupExists(
        [OSParameter(
            Description = "Connection string contains Endpoint and AccessKey",
            DataType = OSDataType.Text)]
        string connectionString, 
        [OSParameter(
            Description = "Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.",
            DataType = OSDataType.Text)]
        string hub, 
        [OSParameter(
            Description = "Group name",
            DataType = OSDataType.Text)]
        string group);

    [OSAction(
        Description = "Send a message to all connections of a group",
        IconResourceName = "Without.Systems.AzureWebPubSub.Resources.WebPubSub.png")]
    void SendToGroup(
        [OSParameter(
            Description = "Connection string contains Endpoint and AccessKey",
            DataType = OSDataType.Text)]
        string connectionString, 
        [OSParameter(
            Description = "Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.",
            DataType = OSDataType.Text)]
        string hub,
        [OSParameter(
            Description = "Group name",
            DataType = OSDataType.Text)]
        string group,
        [OSParameter(
            Description = "Message content",
            DataType = OSDataType.Text)]
        string content,
        [OSParameter(
            Description = "Content type of message. Can be text or json. Defaults to text",
            DataType = OSDataType.Text)]
        string contentType = "text");

    [OSAction(
        Description = "Send a message to connected user",
        IconResourceName = "Without.Systems.AzureWebPubSub.Resources.WebPubSub.png")]
    void SendToUser(
        [OSParameter(
            Description = "Connection string contains Endpoint and AccessKey",
            DataType = OSDataType.Text)]
        string connectionString, 
        [OSParameter(
            Description = "Connected User Identifier",
            DataType = OSDataType.Text)]
        string userId,
        [OSParameter(
            Description = "Message content",
            DataType = OSDataType.Text)]
        string content,
        [OSParameter(
            Description = "Content type of message. Can be text or json. Defaults to text",
            DataType = OSDataType.Text)]
        string contentType = "text");

    [OSAction(
        Description = "Send a message to all connections in a hub",
        IconResourceName = "Without.Systems.AzureWebPubSub.Resources.WebPubSub.png")]
    void SendToAll(
        [OSParameter(
            Description = "Connection string contains Endpoint and AccessKey",
            DataType = OSDataType.Text)]
        string connectionString,
        [OSParameter(
            Description = "Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.",
            DataType = OSDataType.Text)]
        string hub,
        [OSParameter(
            Description = "Message content",
            DataType = OSDataType.Text)]
        string content,
        [OSParameter(
            Description = "Content type of message. Can be text or json. Defaults to text",
            DataType = OSDataType.Text)]
        string contentType = "text");

    [OSAction(
        Description = "Remove a connected user from a group",
        IconResourceName = "Without.Systems.AzureWebPubSub.Resources.WebPubSub.png")]
    void RemoveUserFromGroup(
        [OSParameter(
            Description = "Connection string contains Endpoint and AccessKey",
            DataType = OSDataType.Text)]
        string connectionString,
        [OSParameter(
            Description = "Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.",
            DataType = OSDataType.Text)]
        string hub, 
        [OSParameter(
            Description = "Group name",
            DataType = OSDataType.Text)]
        string group,
        [OSParameter(
            Description = "Connected User Identifier",
            DataType = OSDataType.Text)]
        string userId);
    
    [OSAction(
        Description = "Remove a connected user from all groups",
        IconResourceName = "Without.Systems.AzureWebPubSub.Resources.WebPubSub.png")]
    void RemoveUserFromAllGroups(
        [OSParameter(
            Description = "Connection string contains Endpoint and AccessKey",
            DataType = OSDataType.Text)]
        string connectionString,
        [OSParameter(
            Description = "Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.",
            DataType = OSDataType.Text)]
        string hub,
        [OSParameter(
            Description = "Connected User Identifier",
            DataType = OSDataType.Text)]
        string userId);
    
    [OSAction(
        Description = "Add a connected user to a group",
        IconResourceName = "Without.Systems.AzureWebPubSub.Resources.WebPubSub.png")]
    void AddUserToGroup(
        [OSParameter(
            Description = "Connection string contains Endpoint and AccessKey",
            DataType = OSDataType.Text)]
        string connectionString,
        [OSParameter(
            Description = "Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.",
            DataType = OSDataType.Text)]
        string hub,
        [OSParameter(
            Description = "Group name",
            DataType = OSDataType.Text)]
        string group,
        [OSParameter(
            Description = "Connected User Identifier",
            DataType = OSDataType.Text)]
        string userId);
    
    [OSAction(
        Description = "Create a client access uri",
        ReturnName = "uri",
        ReturnDescription = "Client Access URI",
        ReturnType = OSDataType.Text,
        IconResourceName = "Without.Systems.AzureWebPubSub.Resources.WebPubSub.png")]
    string GetClientAccessUri(
        [OSParameter(
            Description = "Connection string contains Endpoint and AccessKey",
            DataType = OSDataType.Text)]
        string connectionString,
        [OSParameter(
            Description = "Target hub name, which should start with alphabetic characters and only contain alpha-numeric characters or underscore.",
            DataType = OSDataType.Text)]
        string hub,
        [OSParameter(
            Description = "Connected User Identifier",
            DataType = OSDataType.Text)]
        string userId,
        [OSParameter(
            Description = "Lifespan in minutes until the access token expires. Defaults to 120 minutes",
            DataType = OSDataType.Integer)]
        int tokenLifespan = 120);
}