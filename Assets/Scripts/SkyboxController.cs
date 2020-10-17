using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxController : MonoBehaviour
{

    public Material skyboxday;

    public Material skyboxnight;

    public Material skybox;
    
    

    
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           //skybox.SetFloat("_Blend", )
            RenderSettings.skybox = skyboxday;
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RenderSettings.skybox = skyboxnight;
            
            
        }
    }
}
