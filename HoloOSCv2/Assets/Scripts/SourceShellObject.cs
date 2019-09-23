using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceShellObject : MonoBehaviour {
    Transform trans;

    GameObject handler;
    OSCOutput output;

    void Start() {
        trans = GetComponent<Transform>().transform;
        handler = GameObject.FindGameObjectWithTag("OSCHandler");
        output = handler.GetComponent<OSCOutput>();
    }

    const string masterAzimuth = "/MultiEncoder/masterAzimuth";
    const string masterElevation = "/MultiEncoder/masterElevation";

    public float Elevation {
        get {
            float angle = trans.rotation.eulerAngles.x % 360;
            return angle > 180 ? angle - 360 : angle;
        }
    }
    public float Azimuth {
        get {
            float angle = trans.rotation.eulerAngles.y % 360;
            return angle > 180 ? angle - 360 : angle;
        }
    }

    public void sendMessageToOSCHandler() {
        string[] data = new string[2];
        data[0] = masterAzimuth;
        data[1] = Azimuth.ToString();
        output.SendMessage("SendOSCMessageToClient", data);
        data[0] = masterElevation;
        data[1] = Elevation.ToString();
        output.SendMessage("SendOSCMessageToClient", data);
    }
}
