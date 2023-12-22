using client_component;
using Grpc.Net.Client;

class Program
{
    public async static Task Main(string[] args)
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:8080");
        var handler = new RequestHandler(channel);
        while (true)
        {
            Console.WriteLine("Write a request to service.");
            var command = Console.ReadLine().Trim().Split(" ");
            var request = command[0];

            switch (request)
            {
                case "clr":
                    Console.Clear();
                    break;
                
                case "set":
                    try
                    {
                        var k = command[1];
                        var v = command[2];
                        await handler.Set(k, v);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You need try again with rule 'set {key} {value}'");
                    }

                    break;
                case "get":
                    try
                    {
                        var k = command[1];
                        await handler.Get(k);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("You need try again with rule 'get {key}'");
                    }
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
        
        
        /*bool success;
    string? id;
    string? consoleReply;
    switch (args[0])
    {
        case "clr":
            Console.Clear();
            break;
        case "exit":
            Environment.Exit(0);
            break;
        case "allusers":

            await handler.GetAllUsers();

            break;
        case "get":

            id = args[1];
            await handler.Get(id);

            break;

        case "set":

            id = args[1];
            consoleReply = args[2];
            if (consoleReply != null) await handler.Update(id, consoleReply);

            break;
        case "post":
            consoleReply = args[1];
            if (consoleReply != null) await handler.Create(consoleReply);

            break;
        case "delete":

            id = args[1];
            await handler.Delete(id);

            break;
        default:
            Console.WriteLine("Unknown request. Try again...");
            break;
    }
    */

        
        
        
        /*
        string? message = "";
        bool success;
        string? id;
        string? consoleReply;
        while (true)
        {
            Console.WriteLine("Write a request to service.");
            message = Console.ReadLine();
            switch (message)
            {
                case "clr":
                    Console.Clear();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                case "allusers":

                    await handler.GetAllUsers();

                    break;
                case "get":

                    id = GetIdFromConsole();
                    await handler.Get(id);

                    break;

                case "set":

                    id = GetIdFromConsole();

                    Console.WriteLine("Enter new name: ");
                    consoleReply = Console.ReadLine();
                    if (consoleReply != null) await handler.Update(id, consoleReply);

                    break;
                case "post":

                    Console.WriteLine("Enter new name: ");
                    consoleReply = Console.ReadLine();
                    if (consoleReply != null) await handler.Create(consoleReply);

                    break;
                case "delete":

                    id = GetIdFromConsole();
                    await handler.Delete(id);

                    break;
                default:
                    Console.WriteLine("Unknown request. Try again...");
                    break;
            }
        }

        string GetIdFromConsole()
        {
            Console.WriteLine("Write an id of user: ");
            consoleReply = Console.ReadLine();
            return consoleReply;
        }*/
        
    }
}