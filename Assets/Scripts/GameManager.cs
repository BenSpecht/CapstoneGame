using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Cinemachine;
/*using UnityEditor;*/
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using TMPro;

[Serializable]
public struct ScreenText
{
    public Text saveBabyText;
    public Text babySavedText;
    public Text gotWoodText;
    public Text scorpittyFoodText;
    public Text instrumentText;
    public Text befriendText;
    public Text befriendSuccessText;
}

[Serializable]
public struct Pages
{
    public Sprite CorvaninePage;
    public Sprite scorpittyPage;
    public Sprite SerpanceaePage;
    public Sprite WhalePage;
    public Sprite MantarayPage;
    public Sprite OctopusPage;
    public Sprite snailBunnyPage;
    public Sprite WendigoPage;
    public Sprite ElephantPage;
}

[Serializable]
public struct FoodBools
{
    public bool scorpittyFood;
    public bool whaleFood;
    public bool mantarayFood;
    public bool snailbunnyFood;

    public bool snailBunnyComingToFood;
}

[Serializable]
public struct ControlBools
{
    public bool playerControl;
    public bool whaleControl;
}

[Serializable]
public struct InventoryBools
{
    public bool hasCovanineBaby;
    public bool hasWood;
    public bool hasInstrument;
    public bool hasOctopusBox;
    public bool hasKey;
}

[Serializable]
public struct WhalePathing
{
    public bool tutorialToForest;
    public bool forestToDark;
    public bool darkToFlower;    

    public bool whaleAtTutorial;
    public bool whaleAtForest;
    public bool whaleAtDark;
    public bool whaleAtFlower;

    public bool whaleReadyToLeaveForest;
    public bool whaleReadyToLeaveDark;

    public bool whaleCircleForest;
    public bool whaleCircleDark;
}

[Serializable]
public struct AnimalsMetBools
{
    public bool WhaleMet;
    public bool ScorpittyMet;
    public bool SerpMet;
    public bool MantarayMet;
    public bool OctopusMet;
    public bool CorvinineMet;
    public bool WendigoMet;
    public bool SnailbunnyMet;
}

[Serializable]
public struct Bools
{
    public ControlBools ControlBools;
    public InventoryBools InventoryBools;
    public FoodBools FoodBools;
    public WhalePathing WhalePathing;
    public AnimalsMetBools AnimalsMetBools;

    public bool whaleFed;
}

public class GameManager : MonoBehaviour
{

    public Book book;

    public Bools bools;
    public ScreenText ScreenText;
    public Pages pages;


    public GameObject player;

    public TextMeshPro thinkingText;

    public Transform textmesh;

    public GameObject mainCamera;
    public GameObject flowerCamera;
    public bool hasBook;

    public GameObject flower;

    private bool runFlowerAnimation = false;
    
    // Start is called before the first frame update
    void Start()
    {
        thinkingText = FindObjectOfType<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bools.WhalePathing.whaleReadyToLeaveForest && bools.WhalePathing.whaleAtForest)
        {
            ForestWorldLeaveCheck();
        } else if (!bools.WhalePathing.whaleReadyToLeaveDark && bools.WhalePathing.whaleAtDark)
        {
            DarkWorldLeaveCheck();
        }
        GameOverCheck();
        
        textmesh.rotation = Quaternion.LookRotation( textmesh.position - Camera.main.transform.position );
    }

    private void DarkWorldLeaveCheck()
    {
        if (bools.AnimalsMetBools.CorvinineMet && bools.AnimalsMetBools.SerpMet && bools.AnimalsMetBools.WendigoMet && bools.AnimalsMetBools.ScorpittyMet)
        {
            bools.WhalePathing.whaleReadyToLeaveDark = true;
        }
    }

    private void ForestWorldLeaveCheck()
    {
        if (bools.AnimalsMetBools.MantarayMet && bools.AnimalsMetBools.OctopusMet && bools.AnimalsMetBools.SnailbunnyMet)
        {
            bools.WhalePathing.whaleReadyToLeaveForest = true;
        }
    }

    private void GameOverCheck()
    {
        if (bools.AnimalsMetBools.CorvinineMet && bools.AnimalsMetBools.MantarayMet &&
            bools.AnimalsMetBools.OctopusMet && bools.AnimalsMetBools.ScorpittyMet && bools.AnimalsMetBools.SerpMet &&
            bools.AnimalsMetBools.WhaleMet && bools.AnimalsMetBools.WendigoMet && bools.AnimalsMetBools.SnailbunnyMet && !runFlowerAnimation)
        {
            player.GetComponent<ThirdPersonCharacter>().enabled = false;
            player.GetComponent<ThirdPersonUserControl>().enabled = false;

            mainCamera.GetComponent<MouseOrbitImproved>().enabled = false;
            mainCamera.GetComponent<CinemachineBrain>().enabled = true;

            flowerCamera.GetComponent<CinemachineVirtualCamera>().Priority = 999999;
            flower.GetComponent<Animator>().Play("Take 001");
            flowerCamera.GetComponent<Animator>().Play("FlowerOpen");
            runFlowerAnimation = true;
        }
    }

    public void FlowerAnimationOver()
    {
        flowerCamera.GetComponent<Animator>().enabled = false;
        player.GetComponent<ThirdPersonCharacter>().enabled = true;
        player.GetComponent<ThirdPersonUserControl>().enabled = true;

        mainCamera.GetComponent<MouseOrbitImproved>().enabled = true;
        mainCamera.GetComponent<CinemachineBrain>().enabled = false;

        flowerCamera.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        bools.WhalePathing.whaleReadyToLeaveDark = true;
    }

    public void AddCorvanineToBook()
    {
        book.bookPages[7] = pages.CorvaninePage;
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Journal/Journal_NewTask", GetComponent<Transform>().position);
    }

    public void AddScorpittyToBook()
    {
        book.bookPages[6] = pages.scorpittyPage;
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Journal/Journal_NewTask", GetComponent<Transform>().position);
    }

    public void AddSerpanceaeToBook()
    {
        book.bookPages[8] = pages.SerpanceaePage;
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Journal/Journal_NewTask", GetComponent<Transform>().position);
    }

    public void AddOctopusToBook()
    {
        book.bookPages[2] = pages.OctopusPage;
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Journal/Journal_NewTask", GetComponent<Transform>().position);
    }

    public void AddMantarayToBook()
    {
        book.bookPages[3] = pages.MantarayPage;
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Journal/Journal_NewTask", GetComponent<Transform>().position);
    }

    public void AddWhaleToBook()
    {
        book.bookPages[1] = pages.WhalePage;
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Journal/Journal_NewTask", GetComponent<Transform>().position);
    }

    public void AddSnailBunnyToBook()
    {
        book.bookPages[4] = pages.snailBunnyPage;
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Journal/Journal_NewTask", GetComponent<Transform>().position);
    }

    public void AddWendigoToBook()
    {
        book.bookPages[9] = pages.WendigoPage;
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Journal/Journal_NewTask", GetComponent<Transform>().position);
    }

    public void AddElephantToBook()
    {
        book.bookPages[10] = pages.ElephantPage;
        //FMODUnity.RuntimeManager.PlayOneShot("event:/Journal/Journal_NewTask", GetComponent<Transform>().position);
    }
    
    public void DisplaySaveBaby()
    {
        StartCoroutine(SaveBabyText());
        
    }

    private IEnumerator SaveBabyText()
    {
        //ScreenText.saveBabyText.gameObject.SetActive(true);
        thinkingText.text = "*Looks like one is missing*";
        yield return new WaitForSeconds(5);
        //ScreenText.saveBabyText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayBabySaved()
    {
        StartCoroutine(BabySavedText());
    }

    private IEnumerator BabySavedText()
    {
        thinkingText.text = "*WRITE STUFF HERE JULIA*";
        ScreenText.babySavedText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ScreenText.babySavedText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayWoodRecieved()
    {
        StartCoroutine(WoodRecievedText());
    }

    private IEnumerator WoodRecievedText()
    {
        thinkingText.text = "*WRITE STUFF HERE JULIA*";
        ScreenText.gotWoodText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ScreenText.gotWoodText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayScorpittyFoodText()
    {
        StartCoroutine(ScorpittyFoodText());
    }
    
    private IEnumerator ScorpittyFoodText()
    {
        thinkingText.text = "*WRITE STUFF HERE JULIA*";
        ScreenText.scorpittyFoodText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ScreenText.scorpittyFoodText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayInstrumentRecieved()
    {
        StartCoroutine(InstrumentRecievedText());
    }

    private IEnumerator InstrumentRecievedText()
    {
        thinkingText.text = "*WRITE STUFF HERE JULIA*";
        ScreenText.instrumentText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ScreenText.instrumentText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayBefriendText()
    {
        StartCoroutine(BefriendText());
    }

    private IEnumerator BefriendText()
    {
        thinkingText.text = "*WRITE STUFF HERE JULIA*";
        ScreenText.befriendText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ScreenText.befriendText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayBefriendSuccessText()
    {
        StartCoroutine(BefriendSuccessText());
    }

    private IEnumerator BefriendSuccessText()
    {
        thinkingText.text = "*WRITE STUFF HERE JULIA*";
        ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }
}
