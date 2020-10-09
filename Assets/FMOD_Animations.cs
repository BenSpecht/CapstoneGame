using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMOD_Animations : MonoBehaviour
{
    
    void PlayScorpionCat_Meow(string path)
    {

        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    }

    void PlayFlowerSnake_Hiss(string path)
    {

        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    }

}
    