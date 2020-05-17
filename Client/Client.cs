using System;
using WebSocketSharp;


class Client
{
    static WebSocket client;
    static Random R;


    static void Main(string[] args)
    {
        R = new Random();
        client = new WebSocket("ws://localhost:8081/demo");
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
        client.Send("Client_"+R.Next(100));
        // danger danger
        //client.Close();
    }
}
