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
using UnityEngine.SceneManagement;

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
    public Text foundJartext;
    public Text placeJartext;
    public Text octoJartext;
    public Text rayFoodtext;
    public Text rayHappytext;
    public Text foundBerriestext;
    public Text placeBerriestext;
    public Text bunnieseattext;
    public Text whalePickuptext;
    public Text whaleDarkPickuptext;
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
    public Sprite JackOMothPage;
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
    public bool MothMet;
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
    public GameObject treeCamera;
    public bool hasBook;

    public GameObject flower;

    private bool runFlowerAnimation = false;
    private static readonly int PlayFinal = Animator.StringToHash("PlayFinal");

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
        }
        else if (!bools.WhalePathing.whaleReadyToLeaveDark && bools.WhalePathing.whaleAtDark)
        {
            DarkWorldLeaveCheck();
        }
        
        textmesh.rotation = Quaternion.LookRotation(textmesh.position - Camera.main.transform.position);


        if (Input.GetKeyDown(KeyCode.P))
        {
            player.GetComponent<ThirdPersonCharacter>().enabled = false;
            player.GetComponent<ThirdPersonUserControl>().enabled = false;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            mainCamera.GetComponent<MouseOrbitImproved>().enabled = false;
            mainCamera.GetComponent<CinemachineBrain>().enabled = true;

            flowerCamera.GetComponent<CinemachineVirtualCamera>().Priority = 9999999;
            flower.GetComponent<Animator>().Play("Take 001");
            flowerCamera.GetComponent<Animator>().Play("FlowerOpen");
            runFlowerAnimation = true;
        }
    }

    private void DarkWorldLeaveCheck()
    {
        if (bools.AnimalsMetBools.CorvinineMet && bools.AnimalsMetBools.SerpMet && bools.AnimalsMetBools.WendigoMet &&
            bools.AnimalsMetBools.ScorpittyMet && bools.AnimalsMetBools.MothMet)
        {
            DisplayWhalePickUp();
            bools.WhalePathing.whaleReadyToLeaveDark = true;
        }
    }

    private void ForestWorldLeaveCheck()
    {
        if (bools.AnimalsMetBools.MantarayMet && bools.AnimalsMetBools.OctopusMet &&
            bools.AnimalsMetBools.SnailbunnyMet)
        {
            DisplayWhalePickUp();
            bools.WhalePathing.whaleReadyToLeaveForest = true;
        }
    }

    public void GameOverCheck()
    {
        if (bools.AnimalsMetBools.CorvinineMet && bools.AnimalsMetBools.MantarayMet &&
            bools.AnimalsMetBools.OctopusMet && bools.AnimalsMetBools.ScorpittyMet && bools.AnimalsMetBools.SerpMet &&
            bools.AnimalsMetBools.WhaleMet && bools.AnimalsMetBools.WendigoMet && bools.AnimalsMetBools.MothMet && bools.AnimalsMetBools.SnailbunnyMet &&
            !runFlowerAnimation)
        {
            player.GetComponent<ThirdPersonCharacter>().enabled = false;
            player.GetComponent<ThirdPersonUserControl>().enabled = false;
            player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            mainCamera.GetComponent<MouseOrbitImproved>().enabled = false;
            mainCamera.GetComponent<CinemachineBrain>().enabled = true;

            flowerCamera.GetComponent<CinemachineVirtualCamera>().Priority = 9999999;
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
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        mainCamera.GetComponent<MouseOrbitImproved>().enabled = true;
        mainCamera.GetComponent<CinemachineBrain>().enabled = false;

        flowerCamera.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        bools.WhalePathing.whaleReadyToLeaveDark = true;
    }

    public void TreeLightAnimation()
    {
        player.GetComponent<ThirdPersonCharacter>().enabled = false;
        player.GetComponent<ThirdPersonUserControl>().enabled = false;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        mainCamera.GetComponent<MouseOrbitImproved>().enabled = false;
        mainCamera.GetComponent<CinemachineBrain>().enabled = true;

        treeCamera.GetComponent<CinemachineVirtualCamera>().Priority = 9999999;
        treeCamera.GetComponent<Animator>().Play("TreeLight");
        // flowerCamera.GetComponent<Animator>().SetBool(PlayFinal, true);
        // runFlowerAnimation = true;
    }

    public void TreeLightAnimationOver()
    {
        SceneManager.LoadScene("Home_menu");
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

    public void AddMothToBook()
    {

        book.bookPages[5] = pages.JackOMothPage;


    }

    private IEnumerator SaveBabyText()
    {
        //ScreenText.saveBabyText.gameObject.SetActive(true);
        thinkingText.text = "*Looks like a baby is missing*";
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
        thinkingText.text = "*You look lost! Let's find your mum*";
        //ScreenText.babySavedText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.babySavedText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayWoodRecieved()
    {
        StartCoroutine(WoodRecievedText());
    }

    private IEnumerator WoodRecievedText()
    {
        thinkingText.text = "*These planks could be useful*";
        //ScreenText.gotWoodText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.gotWoodText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayScorpittyFoodText()
    {
        StartCoroutine(ScorpittyFoodText());
    }

    private IEnumerator ScorpittyFoodText()
    {
        thinkingText.text = "*I bet one of these animals eats meat*";
        //ScreenText.scorpittyFoodText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.scorpittyFoodText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayInstrumentRecieved()
    {
        StartCoroutine(InstrumentRecievedText());
    }

    private IEnumerator InstrumentRecievedText()
    {
        thinkingText.text = "*A pan flute! I should try playing it*";
        //ScreenText.instrumentText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.instrumentText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayBefriendText()
    {
        StartCoroutine(BefriendText());
    }

    private IEnumerator BefriendText()
    {
        thinkingText.text = "*I think it likes me*";
        //ScreenText.befriendText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayBefriendSuccessText()
    {
        StartCoroutine(BefriendSuccessText());
    }

    private IEnumerator BefriendSuccessText()
    {
        thinkingText.text = "*I think it likes me*";
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }
    
    private IEnumerator JarFound()
    {
        thinkingText.text = "*A jar! Maybe I can catch something in it*";
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayFoundJartext()
    {
        StartCoroutine(JarFound());
    }
    
    private IEnumerator JarPlaced()
    {
        thinkingText.text = "*looks like these guys love to hide in small spaces*";
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayJarPlacedText()
    {
        StartCoroutine(JarPlaced());

    }
    
    private IEnumerator BerriesFound()
    {
        thinkingText.text = "*I bet one of these animals eats berries*";
                          
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DispalyBerriesFoundText()
    {
        StartCoroutine(BerriesFound());


    }
    private IEnumerator BerriesFed()
    {
        thinkingText.text = "*I got one to come out! They must love this food*";
                          
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayBerriesFedText()
    {
        StartCoroutine(BerriesFed());

    }
    
    private IEnumerator WhaleFed()
    {
        thinkingText.text = "*That creature looks hungry!*";
                          
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }
    
    public void DisplayWhaleFedText()
    {
        StartCoroutine(WhaleFed());

    }
    private IEnumerator MantaFoodFound()
    {
        thinkingText.text = "*More corral! This one must be for another fishy creature*";
                          
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }
    
    public void DisplayMantaFoodText()
    {
        StartCoroutine(MantaFoodFound());

    }
    
    private IEnumerator MantaFed()
    {
        thinkingText.text = "*Wow, they really love their corral! Fly away now little friend*";
                          
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }
    public void DisplayMantaFedText()
    {
        StartCoroutine(MantaFed());

    }

    private IEnumerator WhaleForestPickup()
    {
        yield return new WaitForSeconds(4);
        thinkingText.text = "*I think the Whale is coming to pick me up*";
                          
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayWhalePickUp()
    {
        StartCoroutine(WhaleForestPickup());

    }
    
    private IEnumerator ScropFed()
    {
        thinkingText.text = "*Geez, this kitty loves meat, but it's already running off again*";
                          
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayScropFedText()
    {
        StartCoroutine(ScropFed());

    }
    
    private IEnumerator WendiCalm()
    {
        thinkingText.text = "*Looks like he’s calmed down now. You’re not so scary after all*";
                          
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayWendiCalm()
    {
        StartCoroutine(WendiCalm());

    }
    
    private IEnumerator BridgeFix()
    {
        thinkingText.text = "*That should work*";
                          
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void DisplayRepairtext()
    {
        StartCoroutine(BridgeFix());

    }
    
    private IEnumerator Interact()
    {
        thinkingText.text = "*Hmmm*";
                          
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }
    
    public void DisplayInteract()
    {
        //StartCoroutine(Interact());

    }

    private IEnumerator Interactfix()
    {
        thinkingText.text = " ";
                          
        //ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        //ScreenText.befriendSuccessText.gameObject.SetActive(false);
        thinkingText.text = " ";
    }

    public void FixInteract()
    {
        StartCoroutine(Interactfix());

    }
}
