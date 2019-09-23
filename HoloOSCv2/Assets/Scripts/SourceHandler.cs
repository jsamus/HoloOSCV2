using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceHandler : MonoBehaviour
{
    public GameObject source;
    ArrayList sources = new ArrayList();

    [SerializeField]
    private float numberOfObjects = 5;

    public void Start() {
        for(int i=1; i <= numberOfObjects; i++) {
            AddSourceObject(new Vector3(360/i,0,0));
        }
    }
    public void AddSourceObject(Vector3 pos) {
        //Instantiate Prefab at Runtime
        
        GameObject src = Instantiate(source, pos, Quaternion.identity); 
        src.name = "Source" + sources.Count;
        src.transform.parent = this.transform;
        src.GetComponent<SourceObject>().SetID(sources.Count);
        Vector3 up = pos;
        Vector3 LookAt = Vector3.Cross(up, -transform.right) + up;
        src.transform.LookAt(LookAt, up);
        sources.Add(src);
    }

    public void DeleteSourceObject() { 
        //Destroy() the targeted Source 
    }
}
