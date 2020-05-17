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
        WebSocketServer server = new WebSocketServer(8081);
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
            //base.OnOpen();
            Console.WriteLine("A client has joined");

            foreach (var item in ids)
            {
                Send(item.Value + " is on the server. Beware!");
            }
            ids[ID] = "";
        }

        //protected override void OnClose(CloseEventArgs e)
        //{
        //    //base.OnClose(e);
        //}

        protected override void OnMessage(MessageEventArgs e)
        {
            ids[ID] = e.Data;
            
            //base.OnMessage(e);
            // Console.WriteLine(e.Data);
           // Console.WriteLine("Active users num: " + ids.Count);
            // same as foreach underneath
            //Sessions.Broadcast("I received your message");

            //// same as broadcast above
            //foreach (var id in ids)
            //{
            //    Sessions.SendTo("I received your message", id);
            //}

            // sends data to all clients
            //Sessions.Broadcast();

            // send data to a specific client
            //Sessions.SendTo("I received your message", ID);

            //Send("I received your message");
            // option b - can send message to a different user
            // I WILL USE (byte[] data, string id) parameters
        }
    }
}

