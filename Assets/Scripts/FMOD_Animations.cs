using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMOD_Animations : MonoBehaviour
{
    //Player Run
    void PlayerFootstep(string path)
    {

        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    }

    //Scorpitty Animations
    void PlayScorpionCat_Meow(string path)
    {

        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    }

    //Serpancae Animations
    void PlaySerpanceae_Stand(string path)
    {

        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    }

    void PlaySerpanceae_Hiss(string path)
    {

        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    }

    //CorvaninePup Animations
    void PlayCorvaninePup_Idle1(string path)
    {

        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    }

    void PlayCorvaninePup_Idle2(string path)
    {

        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    }

}
    