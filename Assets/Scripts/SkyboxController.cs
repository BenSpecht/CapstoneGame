using System.Collections;
using System.Collections.Generic;
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
            daylight.SetActive(true);
            nightlight.SetActive(false);
           //skybox.SetFloat("_Blend", )
            RenderSettings.skybox = skyboxday;
            dayCamera.SetActive(true);
            nightCamera.SetActive(false);
            //lighting.intensity = Mathf.PingPong(Time.time, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            nightlight.SetActive(true);
            daylight.SetActive(false);
            RenderSettings.skybox = skyboxnight;
            dayCamera.SetActive(false);
            nightCamera.SetActive(true);
            //lighting.intensity = Mathf.PingPong(Time.time, 2);
            
        }
    }
}
