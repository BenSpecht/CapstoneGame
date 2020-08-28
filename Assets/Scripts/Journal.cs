﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Journal : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    [FormerlySerializedAs("journalUI")] public GameObject journalUi;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
            
        }
    }

    void Resume()
    {
        journalUi.SetActive(false);
        
        GameIsPaused = false;
    }

    void Pause()
    {
        journalUi.SetActive(true);
        
        GameIsPaused = true;
    }
}
