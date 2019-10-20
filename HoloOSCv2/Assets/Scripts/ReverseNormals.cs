using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReverseNormals : MonoBehaviour
{
    
    void Start()
    {
        MeshFilter currentMesh = GetComponent(typeof(MeshFilter)) as MeshFilter;
        if (currentMesh != null)
        {
            //copying current Mesh:
            Mesh reverseMesh = currentMesh.mesh;
            Vector3[] normals = reverseMesh.normals;
            //inverting direction:
            for (int i = 0; i < normals.Length; i++)
               normals[i] = -normals[i];
            reverseMesh.normals = normals;

        }
    }
}