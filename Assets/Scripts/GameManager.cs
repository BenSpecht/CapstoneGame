using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct ScreenText
{
    public Text saveBabyText;
    public Text babySavedText;
    public Text gotWoodText;
    public Text scorpittyFoodText;
    public Text instrumentText;
}

[Serializable]
public struct Pages
{
    public Sprite CorvaninePage;
    public Sprite scorpittyPage;
    public Sprite SerpanceaePage;
}

[Serializable]
public struct FoodBools
{
    public bool scorpittyFood;
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
}

[Serializable]
public struct Bools
{
    public ControlBools ControlBools;
    public InventoryBools InventoryBools;
    public FoodBools FoodBools;
    
}

public class GameManager : MonoBehaviour
{

    public Book book;

    public Bools bools;
    public ScreenText ScreenText;
    public Pages pages;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
