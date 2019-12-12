using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{

    const string azimuth = "/MultiEncoder/azimuth";
    const string elevation = "/MultiEncoder/elevation";

    void Awake()
    {   
       StartCoroutine(ExampleCoroutine());
    }

    public void RestartScene()
    {   
        SceneManager.LoadScene("DevScene");
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

    IEnumerator ExampleCoroutine()
   {
        //waits for 0.001 seconds before updating Sources
        yield return new WaitForSeconds(0.001F);
        updateSources();

   }
    
}
