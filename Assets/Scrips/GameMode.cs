using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
        if (Input.GetButtonDown("Turn"))
            Time.timeScale = 1;
    }

    public static void Lost()
    {
        Time.timeScale = 0;
        if (Input.GetButtonDown("Turn"))
            SceneManager.LoadScene("Scenes/SampleScene");
    }
}
