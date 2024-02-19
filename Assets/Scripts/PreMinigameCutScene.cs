using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PreMinigameCutScene : MonoBehaviour
{

    public Transform player;
    public Transform LookTarget;
    public CinemachineFreeLook cutsceneCam;
    public CinemachineFreeLook MainCam;
    public GameObject Tekst;
    [SerializeField] private float CutSceneTime = 3f;
    [SerializeField] private int NewSceneNumber = 1;
    [SerializeField] AudioSource dialog;

    
    //Animation
    public Animator NPCAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            other.GetComponent<BoxCollider>().enabled = false;
            cutsceneCam.enabled = true;
            MainCam.enabled = false;
            Tekst.SetActive(true);
            //Player look at the talking npc
            Vector3 lookDirection = LookTarget.position - player.position;
            player.rotation = Quaternion.LookRotation(lookDirection);
            NPCAnimator.SetBool("Talk", true);


            if (dialog != null)
            {
                dialog.Play();
            }
            StartCoroutine(FinishCut());
        }

        //Scenechange after x seconds of cutscene
        IEnumerator FinishCut()
        {
            yield return new WaitForSeconds(CutSceneTime);
            Tekst.SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene(NewSceneNumber);
        }

    }
    
}

