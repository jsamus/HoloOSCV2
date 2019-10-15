using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioSources : MonoBehaviour
{
    ArrayList audiosources = new ArrayList();
    public Material audioMat;
    public GameObject dummy;
    void Start()
    {
        
    }

    public void createAudiObject()
    {
        Vector3 startPos = new Vector3(0, 0, 1);
        GameObject audiosrc = Instantiate(dummy, startPos, Quaternion.identity);
        //GameObject audiosrc = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        int name = audiosources.Count + 1;
        audiosrc.name = name.ToString();
        audiosrc.transform.position = startPos;
        audiosrc.GetComponent<Renderer>().material = audioMat;
        SphereCollider sCollider = audiosrc.GetComponent<SphereCollider>();
        sCollider.center = Vector3.zero;
        sCollider.radius = 0.3f;
        audiosrc.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        audiosources.Add(audiosrc);

    }

    public void stayOnSurface()
    {
        if (audiosources.Count != 0)
        {
            foreach(GameObject i in audiosources)
            {
                float myDistance = (i).transform.position.magnitude;

            }
        }
        else print("no sources added");
       
    }
}
