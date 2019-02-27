using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MorseCodeInputController : MonoBehaviour
{

    private DisplayController currentDisplay;
    public GameObject[] morseCodeInputObjects;

    //Code - empty, 0, 1
    public int CurrentInput
    {
        get { return currentInput; }
        set
        {
            if (value == 3)
                currentInput = 0;
            else
                currentInput = value;
        }
    }
    private int currentInput;
    private int previousInput;
    
    // Start is called before the first frame update
    void Start()
    {
        //Start with empty
        CurrentInput = 0;

        //input value
        previousInput = 0;
        currentInput = 0;


        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
    }

    // Update is called once per frame
    void Update()
    {

        //HideDisplay();
        //Display();

        if (currentInput != previousInput )
        {
            if (currentInput == 0) {
                GetComponent<SpriteRenderer>().sprite = null;
            }
            if (currentInput == 1) {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Dot");
            }
            else if (currentInput == 2)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Line");
            }
        }

        previousInput = currentInput;
    }


    public void HideDisplay()
    {

        /*
        for (int i = 1; i <= 4; i++)
        {
            if (i != currentDisplay.CurrentRoom)
            {
                morseCodeInputObjects = GameObject.FindGameObjectsWithTag("MorseCodeInput-" + currentDisplay.CurrentRoom);

                foreach (GameObject morseCodeInputBtn in morseCodeInputObjects)
                {
                    morseCodeInputBtn.GetComponent<Input>().enabled = false;
                }
            }
        } */
    }


    public void Display()
    {
        if (currentDisplay.CurrentState == DisplayController.State.zoom && currentDisplay.CurrentWall == 2)
        {
            string currentTag = gameObject.tag;

            if (currentTag == "MorseCodeInputButton-" + currentDisplay.CurrentRoom)
            {
                gameObject.SetActive(true);
            }
        }
    }
}
