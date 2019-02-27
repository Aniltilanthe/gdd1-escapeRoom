using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NavigationController : MonoBehaviour
{
    DisplayController currentDisplay;

    public GameObject[] zoomInObjectBehaviors;

    public GameObject[] morseCodeInputObjects;

    //Solution for Room puzzle
    int[,] solutionRoom1 = new int[,] { { 2, 2, 2, 0 }, { 1, 2, 2, 1 }, { 1, 0, 0, 0 }, { 2, 1, 0, 0 } };
    int[,] solutionRoom2 = new int[,] { { 1, 2, 2, 2, 2, 0 }, { 1, 1, 1, 1, 1, 0 }, { 1, 2, 2, 2, 2, 0 }, { 1, 2, 2, 2, 2, 0 }, { 2, 2, 2, 2, 1, 0 }, { 2, 2, 1, 1, 1, 0} };
    int[,] solutionRoom3 = new int[,] { { 1, 2, 2, 2, 2, 0 }, { 1, 1, 1, 1, 1, 0 }, { 1, 2, 2, 2, 2, 0 }, { 1, 2, 2, 2, 2, 0 }, { 2, 2, 2, 2, 1, 0 }, { 2, 2, 1, 1, 1, 0 } };
    int[,] solutionRoom4 = new int[,] { { 1, 2, 2, 2, 2, 0 }, { 1, 1, 1, 1, 1, 0 }, { 1, 2, 2, 2, 2, 0 }, { 1, 2, 2, 2, 2, 0 }, { 2, 2, 2, 2, 1, 0 }, { 2, 2, 1, 1, 1, 0 } };


    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();

        zoomInObjectBehaviors = GameObject.FindGameObjectsWithTag("Interactable");

        morseCodeInputObjects = GameObject.FindGameObjectsWithTag("MorseCodeInput");
    }

    public void OnRightClickArrow() {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;

        foreach (GameObject zoomInObjectBehavior in zoomInObjectBehaviors)
        {
            //zoomInObjectBehavior.GetComponent<ZoomInObjectBehaviorController>().reset();
        }
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;

        foreach (GameObject zoomInObjectBehavior in zoomInObjectBehaviors)
        {
            //zoomInObjectBehavior.GetComponent<ZoomInObjectBehaviorController>().reset();
        }
    }

    public void onClickContinue()
    {
        //when level is not completed
        if (currentDisplay.CurrentState != DisplayController.State.levelComplete)
        {
            //when not puzzle solve submission wall
            if (currentDisplay.CurrentWall != 2)
            {
                onClickZoomReturn();
            }
            else
            {
                //when puzzle solve submission
                onClickUnlock();
            }
        }
        //when level is completed
        else
        {
            onGoToNextLevel();
        }
    }

    public void onClickZoomReturn()
    {

        Debug.Log("onClickZoomReturn ");

        var zoomInObjects = FindObjectsOfType<ZoomInObject>();
        foreach (var zoomInObj in zoomInObjects) {
            Debug.Log("old layer " + zoomInObj.gameObject.layer);
            zoomInObj.gameObject.layer = 0;
        }

        currentDisplay.CurrentState = DisplayController.State.normal;
        currentDisplay.resetToCurrentLevel();

    }

    public void onGoToNextLevel()
    {
        Debug.Log("on go to next level");
        currentDisplay.onGoToNextLevel();
    }

    public void onClickUnlock()
    {
        
        Boolean solutionMatch = true;

        morseCodeInputObjects = GameObject.FindGameObjectsWithTag("MorseCodeInput-" + currentDisplay.CurrentRoom);

        foreach (GameObject morseCodeInput in morseCodeInputObjects)
        {
            int currentRowInput = morseCodeInput.GetComponent<MorseCodeInputController>().CurrentInput;
            
            string rowCol = morseCodeInput.name.Split('-')[1];
            char[] rowColArr = rowCol.ToCharArray();

            int row = (int)Char.GetNumericValue(rowColArr[1]) - 1 ;
            int col = (int)Char.GetNumericValue(rowColArr[3]) - 1;
            

            if (currentDisplay.CurrentRoom == 1)
            {
                if (solutionRoom1[row, col] != currentRowInput)
                {
                    solutionMatch = false;
                }
            }
            else if (currentDisplay.CurrentRoom == 2)
            {
                if (solutionRoom2[row, col] != currentRowInput)
                {
                    solutionMatch = false;
                }
            } else if (currentDisplay.CurrentRoom == 3)
            {
                if (solutionRoom3[row, col] != currentRowInput)
                {
                    solutionMatch = false;
                }
            } else if (currentDisplay.CurrentRoom == 4)
            {
                if (solutionRoom4[row, col] != currentRowInput)
                {
                    solutionMatch = false;
                }
            }
        }

        if (solutionMatch) {
            Debug.Log("Solution matched");

            currentDisplay.onLevelComplete();
        }
        else
        {
            Debug.Log("Solution Not matched");
        }
    }

}
