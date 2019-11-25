using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{

    const string azimuth = "/MultiEncoder/azimuth";
    const string elevation = "/MultiEncoder/elevation";
    GameObject handler;
    SourceObject sourceobject;
    OSCOutput output;

    // Start is called before the first frame update
    void Start()
    {
        //handler = GameObject.FindGameObjectWithTag("OSCHandler");
        //output = handler.GetComponent<OSCOutput>();
        //sourceobject = GameObject.FindGameObjectWithTag("SourceObject");
    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void SendOSCMessageToClient(string[] data) {
        //Debug.Log("Sent a Message to the Client: " + ipadress + ":" + port + " adress: "+data[0]+" message: "+ data[1]);
        //oscOut.Send(data[0], float.Parse(data[1]));
    //}



    public void RestartScene(){
        SceneManager.LoadScene("DevScene");
    }

    public void resetPos(){
      for (int i = 1; i <= 5; i++) {
        string[] data = new string[2];

        data[0] = azimuth + i.ToString();
        data[1] = sourceobject.GetAzimuth().ToString();
        Debug.Log(data[0]);
        output.SendMessage("SendOSCMessageToClient", data);

        data[0] = elevation + i.ToString();
        data[1] = sourceobject.GetElevation().ToString();
        Debug.Log(data[0]);
        output.SendMessage("SendOSCMessageToClient", data);
      }

    }
}
