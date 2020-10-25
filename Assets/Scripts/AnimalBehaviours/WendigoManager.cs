using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WendigoManager : MonoBehaviour
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
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            thinkingText.text = "CALM BITCH";
            
            anim.SetTrigger("calm");
            gameManager.AddWendigoToBook();
            gameManager.bools.AnimalsMetBools.WendigoMet = true;
            
            Debug.Log("CALMu");
            //moth.GetComponent<Animator>().Play("Moth_fly_away");
            //Julia doesn't know what she's doing, plz help her XD
            //gameObject.SetActive(false);
            //MAKE MOTH BECOME ULTIMATE LIFEFORM
        }
        
        
        
    }

    public void WendigoAwaken()
    {
        //gameObject.SetActive(true);
    }
}
