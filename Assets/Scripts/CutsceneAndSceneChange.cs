using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneAndSceneChange : MonoBehaviour
{
    public GameObject player;
    public GameObject key;
    public Camera cutsceneCam;
    [SerializeField] private float CutSceneTime = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                cutsceneCam.enabled = true;
                player.SetActive(false);
                key.SetActive(false);
                StartCoroutine(FinishCut());
            }

            //Scenechange after 10s of cut scene
            IEnumerator FinishCut()
            {
                yield return new WaitForSeconds(CutSceneTime);
                //Play animation
                SceneManager.LoadScene(1);
                
            }
            
        }
            
    }
}
