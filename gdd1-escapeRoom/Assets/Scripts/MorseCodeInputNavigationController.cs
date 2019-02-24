using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MorseCodeInputNavigationController : MonoBehaviour
{

    private DisplayController currentDisplay;
    public GameObject[] morseCodeInputButtonObjects;
    public GameObject[] morseCodeInputObjects;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
    }
    // Update is called once per frame
    void Update()
    {
        HideDisplay();
        Display();

    }

    public void HideDisplay()
    {
        for (int i = 1; i <= 4; i ++)
        {
            if (i != currentDisplay.CurrentRoom || 
                currentDisplay.CurrentState != DisplayController.State.zoom || 
                currentDisplay.CurrentWall != 2)
            {
                morseCodeInputButtonObjects = GameObject.FindGameObjectsWithTag("MorseCodeInputButton-" + i);

                foreach (GameObject morseCodeInputBtn in morseCodeInputButtonObjects)
                {
                    morseCodeInputBtn.GetComponent<Button>().enabled = false;
                }


                //TODO - hide input for current Room
                //hideInput(i);
            }
        }
    }
    private void hideInput(int i)
    {
        morseCodeInputObjects = GameObject.FindGameObjectsWithTag("MorseCodeInput-" + i);

        foreach (GameObject morseCodeInput in morseCodeInputObjects)
        {
            morseCodeInput.SetActive(false);
        }
    }
    public void Display()
    {
        if ( currentDisplay.CurrentState == DisplayController.State.zoom && currentDisplay.CurrentWall == 2 )
        {
            morseCodeInputButtonObjects = GameObject.FindGameObjectsWithTag("MorseCodeInputButton-" + currentDisplay.CurrentRoom);

            foreach (GameObject morseCodeInputBtn in morseCodeInputButtonObjects)
            {
                morseCodeInputBtn.GetComponent<Button>().enabled = true;
            }

            //TODO - show input for current Room
            //showInput();
        }
    }

    public void showInput()
    {
        Debug.Log("show input ");
            morseCodeInputObjects = GameObject.FindGameObjectsWithTag("MorseCodeInput-" + currentDisplay.CurrentRoom);

            foreach (GameObject morseCodeInput in morseCodeInputObjects)
            {
                morseCodeInput.SetActive(true);
            }
    }

    public void OnInput(string inputRowColumn)
    {
        MorseCodeInputController currentObj = GameObject.Find("morseCodeInput-" + inputRowColumn).GetComponent<MorseCodeInputController>();
     
        currentObj.CurrentInput = currentObj.CurrentInput + 1;
    }
}
