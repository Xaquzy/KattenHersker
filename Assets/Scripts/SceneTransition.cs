using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void LoadMainMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene("1 - Main Menu");

    }

    public void LoadWin()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene("9 - Win");
    }

    public void LoadNewGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("2 - Cat on Throne");
    }

    
    public void HorseMinigame()
    {
        PlayerPrefs.SetString("HorseFollow", "The horse will now follow you!");
        PlayerPrefs.SetString("HorseRecent", "The horse was most recently aquired");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene("5 - Byen");
    }

    public void SnakeMinigame()
    {
        PlayerPrefs.SetString("SnakeFollow", "The snake will now follow you!");
        PlayerPrefs.SetString("SnakeRecent", "The snake was most recently aquired");
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene("5 - Byen");
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
