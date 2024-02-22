using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("TurtleFollow", 0);
        PlayerPrefs.SetInt("SnakeFollow", 0);
        PlayerPrefs.SetInt("HorseFollow", 0);
    }
}
