using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class Tutorial : MonoBehaviour
{
    public GameManager gameManager;

    [FormerlySerializedAs("wasdtext")] public GameObject popuptext1;

    [FormerlySerializedAs("mousetext")] public GameObject popuptext2;

    public GameObject opentext;
    public GameObject groundbook;

    public bool bookup;

    //public GameObject jumptext;

    //public GameObject pickuptext;
    // Start is called before the first frame update
    private void Start()
    {
        bookup = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            popuptext1.SetActive(true);
            popuptext2.SetActive(true);
            
            
            
            
        }

        else
        {
            popuptext1.SetActive(false);
            popuptext2.SetActive(false);
        }

        


        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            bookup = true;

            popuptext1.SetActive(false);
            popuptext2.SetActive(false);
            groundbook.SetActive(false);
            opentext.SetActive(true);
        }
    }
}
