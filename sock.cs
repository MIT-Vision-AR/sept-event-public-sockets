using System.Collections;
using System.Reflection;
using UnityEngine;
using System;
// using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


public class sock : MonoBehaviour
{
    private int list_post;
    UdpClient client;
    Thread receiveThread;
    private string message;

    void Start()


    {
        list_post = 8300;//this must be same on both sides


        print("Starting connection now");
        InitConnection();
    }
    void InitConnection()
    {
        print("UDP Initialized");

        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }

    private void ReceiveData()
    {
        client = new UdpClient(list_post);
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Parse("0.0.0.0"), list_post); //connecting
                byte[] data = client.Receive(ref anyIP); //recieving from server

                message = Encoding.UTF8.GetString(data); //UTF-8 form
            }
            catch (Exception e)
            {
                print(e.ToString());
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        print(message);

    }
}
