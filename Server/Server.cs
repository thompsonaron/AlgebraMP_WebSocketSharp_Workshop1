using System;
using System.Collections.Generic;
//using for client
using WebSocketSharp;
// using for server
using WebSocketSharp.Server;

class Server
{
    static void Main(string[] args)
    {
        Console.WriteLine("Server start");
        WebSocketSharp.Server.WebSocketServer server = new WebSocketServer(8080);
        // each behaviour has its own path
        server.AddWebSocketService<DemoBehaviour>("/demo"); // localhost:8081/d emo
        server.Start();
        while (true)
        {

        }
    }

    public class DemoBehaviour : WebSocketBehavior
    {
        // list has to be static so client ids would be shared through multiple instances of demo behaviour
        static Dictionary<string, string> ids = new Dictionary<string, string>(); // ID, nickname

        protected override void OnOpen()
        {
            foreach (var item in ids)
            {
                Send(item.Value + " is on the server. Beware!");
                Sessions.SendTo("A new client is on the server. Be careful", item.Key);
            }
            ids[ID] = "";
            base.OnOpen();
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            ids[ID] = e.Data;
            base.OnMessage(e);
        }
    }
}

