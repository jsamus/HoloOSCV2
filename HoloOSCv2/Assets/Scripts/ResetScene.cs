using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{

    const string azimuth = "/MultiEncoder/azimuth";
    const string elevation = "/MultiEncoder/elevation";


    void Start()
    {
       
    }

    void Update()
    {

    }


    public void updateSources()
    {
      GameObject[] sources;
      sources = GameObject.FindGameObjectsWithTag("Source");
      
      foreach (GameObject source in sources)
      {
          source.GetComponent<SourceObject>().sendMessageToOSCHandler();
      }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("DevScene");
        updateSources();
    }
    
}
