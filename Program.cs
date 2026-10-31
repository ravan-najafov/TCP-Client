using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

using Socket clientSocket = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Stream,
    ProtocolType.Tcp
    );

int port = 5000;

var Ipendpoint = new IPEndPoint(IPAddress.Loopback, port);
clientSocket.Connect(Ipendpoint);

while (true)
{
    string vibor;

    Console.WriteLine("Enter Commands: ");
    Console.WriteLine("UP - Peremesti na odnu kletku  vverx");
    Console.WriteLine("DOWN - Peremesti na odnu kletku vniz");
    Console.WriteLine("LEFT - Peremesti na odnu kletku vlevo");
    Console.WriteLine("RIGHT - Peremesti na odnu kletku vpravo");
    Console.WriteLine("POSITION - Pokazivat tekusuyu pozicuyu");
    Console.WriteLine("EXIT - Zaversit rabotu");
    Console.WriteLine("==================================================");
    Console.WriteLine(" ");
    Console.Write($"Enter command: ");
    vibor = Console.ReadLine();
    
    byte[] buffer = Encoding.UTF8.GetBytes(vibor);

    clientSocket.Send(buffer);

    byte[] responseBuffer = new byte[1024];

    int received = clientSocket.Receive(responseBuffer);
    if (received == 0)
    {
        Console.WriteLine("Server disconnected!");
        break;
    }

    string response = Encoding.UTF8.GetString(responseBuffer, 0, received);

    Console.WriteLine(response);

    if(vibor == "EXIT")
    {
        break;
    }
    else
    {
        Console.WriteLine(" ");
    }
}
