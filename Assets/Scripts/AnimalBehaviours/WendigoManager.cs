using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WendigoManager : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshPro thinkingText;

    private Animator anim;

    public GameObject playFlute;

    public GameObject carryFlute;
    // Start is called before the first frame update
    void Start()
    {
        thinkingText = FindObjectOfType<TextMeshPro>();

        anim = gameObject.GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            thinkingText.text = "*Woah! He looks angry! There must be a way to calm him down… Maybe that song in the book*";
            
            anim.SetTrigger("calm");
            gameManager.AddWendigoToBook();
            gameManager.bools.AnimalsMetBools.WendigoMet = true;

            //hope this doesn't break lol
            thinkingText.text = " ";

            Debug.Log("CALMu");
            playFlute.SetActive(true);
            carryFlute.SetActive(false);
            
            //moth.GetComponent<Animator>().Play("Moth_fly_away");
            //Julia doesn't know what she's doing, plz help her XD
            //gameObject.SetActive(false);
            //MAKE MOTH BECOME ULTIMATE LIFEFORM
        }
        
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            playFlute.SetActive(false);
            carryFlute.SetActive(true);
            
            
        }
    }

    public void WendigoAwaken()
    {
        //gameObject.SetActive(true);
    }
}
