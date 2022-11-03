using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changescene : MonoBehaviour
{
    public int SampleScene;
    private void OnTriggerEnter2D(Collider2D other){
        print("Trigger Entered");

        if(other.tag == "Player"){
            print("Switching Scene to" + SampleScene);
            SceneManager.LoadScene(SampleScene, LoadSceneMode.Single);
        }
    }
}
