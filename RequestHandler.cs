using Grpc.Core;
using Grpc.Net.Client;
using server;

namespace client_component;

public class RequestHandler
{
    private ServerClient.ServerClientClient _client;
    public RequestHandler(GrpcChannel channel)
    {
        _client = new ServerClient.ServerClientClient(channel);
    }
    public async Task Set(string key, string value)
    {
        try
        {
            UserReply user = await _client.SetAsync(new SetUserRequest { Id = key, Name = value });
            Console.WriteLine($"{user.Id}. {user.Name}");
        }
        catch (RpcException ex)
        { 
            Console.WriteLine(ex.Status.Detail);
        }
    }
    
    public async Task Get(string id)
    {
        try
        {
            UserReply sUser = await _client.GetAsync(new GetUserRequest { Id = id });
            Console.WriteLine($"{sUser.Id}.{sUser.Name}");
        }
        catch (RpcException e)
        {
            Console.WriteLine("There is no such user in data.\n");
        }
    }
}