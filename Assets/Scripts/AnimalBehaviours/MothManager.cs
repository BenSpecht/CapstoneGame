using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MothManager : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshPro thinkingText;

    private Animator anim;
    
    

    // Start is called before the first frame update
    void Start()
    {
        thinkingText = FindObjectOfType<TextMeshPro>();

        anim = gameObject.GetComponent <Animator>();
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            thinkingText.text = "*What a pretty moth*";
            
            
        }
       
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            thinkingText.text = " ";
            
            anim.SetTrigger("fly");
            gameManager.AddMothToBook();
            
            Debug.Log("FLY BASTARD");
            //moth.GetComponent<Animator>().Play("Moth_fly_away");
            //Julia doesn't know what she's doing, plz help her XD
            //gameObject.SetActive(false);
             //MAKE MOTH BECOME ULTIMATE LIFEFORM
        }
    }

    private void OnTriggerExit(Collider other)
    {
        thinkingText.text = " ";
    }
}
