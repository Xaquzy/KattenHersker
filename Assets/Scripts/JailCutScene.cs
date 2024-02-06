using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JailCutScene : MonoBehaviour
{
    public GameObject player;
    public GameObject key;
    public Movement JaildoorFly;
    public GameObject Jaildoortrigger;
    public Camera cutsceneCam;
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
                player.SetActive(false);
                key.SetActive(false);
                JaildoorFly.enabled = true;
                Jaildoortrigger.SetActive(false);
                //Disable mouse camera input
                //Play animation of the cutscene
                dialog.Play();
                StartCoroutine(FinishCut());
            }

            //Scenechange after 10s of cut scene
            IEnumerator FinishCut()
            {

                yield return new WaitForSeconds(CutSceneTime);
                SceneManager.LoadScene(NewSceneNumber);

            }

        }
    }
}
