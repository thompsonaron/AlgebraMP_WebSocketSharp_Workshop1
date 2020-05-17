using System;
using System.Threading.Tasks;
using WebSocketSharp;


class Client
{
    static WebSocket client;
    static Random r;

    static void Main(string[] args)
    {
        r = new Random();
        client = new WebSocket("ws://localhost:8080/demo");
        client.OnOpen += Client_OnOpen;
        client.OnMessage += Client_OnMessage;
        client.Connect();

        // it will close too fast for Client_OnOpen to fire
        while (true)
        {

        }
    }

    private static void Client_OnMessage(object sender, MessageEventArgs e)
    {
        Console.WriteLine(e.Data);

    }

    private static void Client_OnOpen(object sender, EventArgs e)
    {
        var id = "Client_" + r.Next(100);
        Console.WriteLine("I am : " + id);
        client.Send(id);
    }
}
