using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCutscene : MonoBehaviour
{
    //public GameObject player;
    //public GameObject key;
    public Camera cutsceneCam;
    public Animator DogAnimator;
    [SerializeField] private float CutSceneTime = 3f;
    [SerializeField] private int NewSceneNumber = 1;
    [SerializeField] AudioSource dialog;

    private void Awake()
    {
        {
            Debug.Log("AWAKE!!");
            cutsceneCam.enabled = true;
            DogAnimator.SetBool("Cry", true);
            //player.SetActive(false);
            //key.SetActive(false);
            //Disable mouse camera input
            //Play animation of the cutscene
            //dialog.Play();
            StartCoroutine(FinishCut());
        }

        //Scenechange after x seconds of cut scene
        IEnumerator FinishCut()
        {
            yield return new WaitForSeconds(CutSceneTime);
            DogAnimator.SetBool("Cry", false);
            SceneManager.LoadScene(NewSceneNumber);
        }
    } 
}

