using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JailBreakScene : MonoBehaviour
{
    public Transform JaildoorTrigger;
    public Camera cutsceneCam;
    public Movement movement;
    [SerializeField] private float CutSceneTime = 3f;
    [SerializeField] private int NewSceneNumber = 1;
    [SerializeField] AudioSource dialog;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
                cutsceneCam.enabled = true;
                dialog.Play();
                StartCoroutine(FinishCut());
            }

            //Scenechange efter x sekunder af cutscene
            IEnumerator FinishCut()
            {
                yield return new WaitForSeconds(CutSceneTime);
                SceneManager.LoadScene(NewSceneNumber);
            }
        }  
    }
}
