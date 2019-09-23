using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OSCOutput : MonoBehaviour
{
    [SerializeField]
    private OscOut oscOut;

    [SerializeField]
    string port;
    [SerializeField]
    string ipadress;

    // Start is called before the first frame update
    void Start()
    {
        port = "8000";
        ipadress = "127.0.0.1";
        oscOut = gameObject.GetComponent<OscOut>();
    }

    // data[0] must always be the adress ; adress is taken from https://plugins.iem.at/docs/osc/#multiencoder
    // data[1] must always be the value to send
    public void SendOSCMessageToClient(string[] data) {
        //Debug.Log("Sent a Message to the Client: " + ipadress + ":" + port + " adress: "+data[0]+" message: "+ data[1]);
        oscOut.Send(data[0], float.Parse(data[1]));
    }

    public void UpdateReceiver() {
        string info = GetRecieverInfo();
        try {
            string[] infos = ReceiverAdressConverter.splitAdress(info);
            SetIpadress(infos[0]);
            SetPort(infos[1]);
        }
        catch {
            SetIpadress("127.0.0.1");
            SetPort("8000");
        }
        OpenReciever();
    }
    public void OpenReciever() {
        oscOut.Open(Int32.Parse(port), ipadress);
    }
    //Catches Info of the Textmesh-Component that gets overwritten by System-Keyboard-Input
    public string GetRecieverInfo() {
        GameObject inputTextObject = GameObject.FindGameObjectWithTag("Text");
        return inputTextObject.GetComponent<TextMeshPro>().text;
    }
    public void SetIpadress(string ip) {
        this.ipadress = ip;
    }
    public void SetPort(string port) {
        this.port = port;
    }
}
