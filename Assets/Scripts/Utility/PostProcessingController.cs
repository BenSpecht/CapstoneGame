using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    public Material skyboxday;

    public Material skyboxnight;

    public GameObject dayCamera;
    public GameObject nightCamera;

    public GameObject daylight;
    public GameObject nightlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dayCamera.GetComponent<CinemachineVirtualCamera>().Priority == 100000)
            {
                dayCamera.GetComponent<CinemachineVirtualCamera>().Priority = 0;
            
                nightlight.SetActive(true);
                daylight.SetActive(false);
                RenderSettings.skybox = skyboxnight;

                dayCamera.GetComponent<PostProcessDebug>().enabled = false;
                dayCamera.GetComponent<PostProcessLayer>().enabled = false;
                dayCamera.GetComponent<PostProcessVolume>().enabled = false;

                nightCamera.GetComponent<PostProcessDebug>().enabled = true;
                nightCamera.GetComponent<PostProcessLayer>().enabled = true;
                nightCamera.GetComponent<PostProcessVolume>().enabled = true;
                
                // dayCamera.SetActive(false);
                // nightCamera.SetActive(true);
                //lighting.intensity = Mathf.PingPong(Time.time, 2);

                nightCamera.GetComponent<CinemachineVirtualCamera>().Priority = 100000;
            }
            else
            {
                nightCamera.GetComponent<CinemachineVirtualCamera>().Priority = 0;
                daylight.SetActive(true);
                nightlight.SetActive(false);
                
                dayCamera.GetComponent<PostProcessDebug>().enabled = true;
                dayCamera.GetComponent<PostProcessLayer>().enabled = true;
                dayCamera.GetComponent<PostProcessVolume>().enabled = true;

                nightCamera.GetComponent<PostProcessDebug>().enabled = false;
                nightCamera.GetComponent<PostProcessLayer>().enabled = false;
                nightCamera.GetComponent<PostProcessVolume>().enabled = false;
           
                // skybox.SetFloat("_Blend", )
           
                RenderSettings.skybox = skyboxday;
           
                //  dayCamera.SetActive(true);
                //  nightCamera.SetActive(false);
                //  //lighting.intensity = Mathf.PingPong(Time.time, 1);

                dayCamera.GetComponent<CinemachineVirtualCamera>().Priority = 100000;
            }
        }
    }
}
