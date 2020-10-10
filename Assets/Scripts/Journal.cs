using System.Collections;
using System.Collections.Generic;
/*using UnityEditor;*/
using UnityEngine;
using UnityEngine.Serialization;

public class Journal : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    public bool bookup;

    [FormerlySerializedAs("journalUI")] public GameObject journalUi;
    public GameManager gameManager;
    public GameObject bookBack;

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
        FMODUnity.RuntimeManager.PlayOneShot("event:/Journal/Journal_Close", gameObject.transform.position);
        bookBack.SetActive(false);
        journalUi.SetActive(false);
        gameManager.bools.ControlBools.playerControl = true;
        GameIsPaused = false;
    }

    void Pause()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Journal/Journal_Open", gameObject.transform.position);
        bookBack.SetActive(true);
        journalUi.SetActive(true);
        gameManager.bools.ControlBools.playerControl = false;
        GameIsPaused = true;
    }
}
