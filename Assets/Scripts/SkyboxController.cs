using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{

    public Material skyboxday;

    public Material skyboxnight;

    //public Material skybox;

    public GameObject dayCamera;
    public GameObject nightCamera;

    public GameObject daylight;
    public GameObject nightlight;

    //private Light lighting;

    
    // Start is called before the first frame update
    void Start()
    {
       //lighting = GetComponent<Light>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            nightCamera.GetComponent<CinemachineVirtualCamera>().Priority = 0;
           daylight.SetActive(true);
           nightlight.SetActive(false);
           
           // skybox.SetFloat("_Blend", )
           
           RenderSettings.skybox = skyboxday;
           
           //  dayCamera.SetActive(true);
           //  nightCamera.SetActive(false);
           //  //lighting.intensity = Mathf.PingPong(Time.time, 1);

           dayCamera.GetComponent<CinemachineVirtualCamera>().Priority = 100000;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            dayCamera.GetComponent<CinemachineVirtualCamera>().Priority = 0;
            
            nightlight.SetActive(true);
            daylight.SetActive(false);
            RenderSettings.skybox = skyboxnight;
            // dayCamera.SetActive(false);
            // nightCamera.SetActive(true);
            //lighting.intensity = Mathf.PingPong(Time.time, 2);

            nightCamera.GetComponent<CinemachineVirtualCamera>().Priority = 100000;

        }
    }
}
