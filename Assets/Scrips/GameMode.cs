using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    public AudioSource bgm;
    public void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            Time.timeScale = 1;
            bgm.Play();
        }
    }

    public static void Lost()
    {
        Time.timeScale = 0;
        if (Input.GetButtonDown("Start"))
            SceneManager.LoadScene("Scenes/SampleScene");
    }
}
