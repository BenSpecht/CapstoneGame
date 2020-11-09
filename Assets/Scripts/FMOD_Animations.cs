﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMOD_Animations : MonoBehaviour
{
    //Player Run
    void PlayerFootstep(string path)
    {

        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    }

    /*Scorpitty Animations
    void PlayScorpittyCat_Meow(string path)
    {

        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    }
    */

    //Serpancae Animations
    void PlaySerpanceae_Stand(string path)
    {

        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    }

    void PlaySerpanceae_Hiss(string path)
    {

        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);

    }

    //Corvanine Animations
    void PlayCorvanine_Howl(string path)
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

    void PlayWhale_Idle(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }

    void PlayOctopus_Idle(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }

    void PlayWendigo_Roar(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }

    void PlayWendigo_Calm(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }

    void PlayElephant_Trumpet(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }
}
    