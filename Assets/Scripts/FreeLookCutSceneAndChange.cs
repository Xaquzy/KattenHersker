using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FreeLookCutSceneAndChange : MonoBehaviour
{

    public Transform player;
    public Transform LookTarget;
    public CinemachineFreeLook cutsceneCam;
    public CinemachineFreeLook MainCam;
    [SerializeField] private float CutSceneTime = 3f;
    [SerializeField] private int NewSceneNumber = 1;
    [SerializeField] AudioSource dialog;
    
    //Animation
    public Animator NPCAnimator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            Debug.Log("YAY ITS WORKING LILILILILILILILILILILILI");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            cutsceneCam.enabled = true;
            MainCam.enabled = false;
            //Player look at the talking npc
            Vector3 lookDirection = LookTarget.position - player.position;
            player.rotation = Quaternion.LookRotation(lookDirection);
            NPCAnimator.SetBool("Talk", true);

            //player.SetActive(false);
            //key.SetActive(false);
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

