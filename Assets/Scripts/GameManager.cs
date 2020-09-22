using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
/*using UnityEditor;*/
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

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
}

[Serializable]
public struct FoodBools
{
    public bool scorpittyFood;
    public bool whaleFood;
    public bool mantarayFood;
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
}

[Serializable]
public struct WhalePathing
{
    public bool pathToDark;
    public bool pathToForest;

    public bool whaleAtForest;
    public bool whaleAtDark;
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
    public GameObject playerCam;
    public GameObject finalCam;

    public GameObject flower;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameOverCheck();
    }

    private void GameOverCheck()
    {
        if (bools.AnimalsMetBools.CorvinineMet && bools.AnimalsMetBools.MantarayMet &&
            bools.AnimalsMetBools.OctopusMet && bools.AnimalsMetBools.ScorpittyMet && bools.AnimalsMetBools.SerpMet &&
            bools.AnimalsMetBools.WhaleMet)
        {
            player.GetComponent<ThirdPersonCharacter>().enabled = false;
            player.GetComponent<ThirdPersonUserControl>().enabled = false;
            playerCam.SetActive(false);
            finalCam.SetActive(true);
            StartCoroutine(FinalAnimationDelay());
        }
    }

    private IEnumerator FinalAnimationDelay()
    {
        yield return new WaitForSeconds(4);
        flower.GetComponent<Animator>().Play("Take 001");
        finalCam.GetComponent<Animator>().Play("Camera");
    }

    public void AddCorvanineToBook()
    {
        book.bookPages[0] = pages.CorvaninePage;
    }

    public void AddScorpittyToBook()
    {
        book.bookPages[1] = pages.scorpittyPage;
    }

    public void AddSerpanceaeToBook()
    {
        book.bookPages[2] = pages.SerpanceaePage;
    }

    public void AddOctopusToBook()
    {
        book.bookPages[3] = pages.OctopusPage;
    }

    public void AddMantarayToBook()
    {
        book.bookPages[4] = pages.MantarayPage;
    }

    public void AddWhaleToBook()
    {
        book.bookPages[5] = pages.WhalePage;
    }
    
    public void DisplaySaveBaby()
    {
        StartCoroutine(SaveBabyText());
    }

    private IEnumerator SaveBabyText()
    {
        ScreenText.saveBabyText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ScreenText.saveBabyText.gameObject.SetActive(false);
    }

    public void DisplayBabySaved()
    {
        StartCoroutine(BabySavedText());
    }

    private IEnumerator BabySavedText()
    {
        ScreenText.babySavedText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ScreenText.babySavedText.gameObject.SetActive(false);
    }

    public void DisplayWoodRecieved()
    {
        StartCoroutine(WoodRecievedText());
    }

    private IEnumerator WoodRecievedText()
    {
        ScreenText.gotWoodText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ScreenText.gotWoodText.gameObject.SetActive(false);
    }

    public void DisplayScorpittyFoodText()
    {
        StartCoroutine(ScorpittyFoodText());
    }
    
    private IEnumerator ScorpittyFoodText()
    {
        ScreenText.scorpittyFoodText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ScreenText.scorpittyFoodText.gameObject.SetActive(false);
    }

    public void DisplayInstrumentRecieved()
    {
        StartCoroutine(InstrumentRecievedText());
    }

    private IEnumerator InstrumentRecievedText()
    {
        ScreenText.instrumentText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ScreenText.instrumentText.gameObject.SetActive(false);
    }

    public void DisplayBefriendText()
    {
        StartCoroutine(BefriendText());
    }

    private IEnumerator BefriendText()
    {
        ScreenText.befriendText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ScreenText.befriendText.gameObject.SetActive(false);
    }

    public void DisplayBefriendSuccessText()
    {
        StartCoroutine(BefriendSuccessText());
    }

    private IEnumerator BefriendSuccessText()
    {
        ScreenText.befriendSuccessText.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        ScreenText.befriendSuccessText.gameObject.SetActive(false);
    }
}
