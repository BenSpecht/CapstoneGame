using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MothManager : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshPro thinkingText;
    

    // Start is called before the first frame update
    void Start()
    {
        thinkingText = FindObjectOfType<TextMeshPro>();
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            thinkingText.text = "*MOTH BEGONE*";
            
            
        }
       
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            thinkingText.text = " ";
             gameObject.SetActive(false);
             //MAKE MOTH BECOME ULTIMATE LIFEFORM
        }
    }

    private void OnTriggerExit(Collider other)
    {
        thinkingText.text = " ";
    }
}
