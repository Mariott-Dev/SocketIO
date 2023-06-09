﻿using System;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace ClientSock
{
    class Program
    {

        static void Main(string[] args)
        {
        connection:
            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 1302);
                string messageToSend = "This is a client test. **Replace with BB JSON Stream** <eom>";
                int byteCount = Encoding.ASCII.GetByteCount(messageToSend + 1);
                byte[] sendData = Encoding.ASCII.GetBytes(messageToSend);

                NetworkStream stream = client.GetStream();
                stream.Write(sendData, 0, sendData.Length);
                Console.WriteLine("sending data from client *BB* to listener...");

                StreamReader sr = new StreamReader(stream);
                string? response = sr.ReadLine();
                Console.WriteLine(response);

                stream.Close();
                client.Close();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("failed to connect to listener...");
                goto connection;
            }
        }
    }
}

