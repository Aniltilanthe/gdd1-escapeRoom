using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NavigationController : MonoBehaviour
{
    DisplayController currentDisplay;

    public GameObject[] zoomInObjectBehaviors;

    public GameObject[] morseCodeInputObjects;

    private int morseCodeRowCount;
    private int morseCodeColumnCount;

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
            zoomInObjectBehavior.GetComponent<ZoomInObjectBehaviorController>().reset();
        }
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;

        foreach (GameObject zoomInObjectBehavior in zoomInObjectBehaviors)
        {
            zoomInObjectBehavior.GetComponent<ZoomInObjectBehaviorController>().reset();
        }
    }

    public void onClickZoomReturn()
    {

        var zoomInObjects = FindObjectsOfType<ZoomInObject>();
        foreach (var zoomInObj in zoomInObjects) {
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
        int[,] solutionRoom1 = new int[,] { { 1, 0, 1, 0 }, { 1, 0, 1, 0 }, { 0, 0, 0, 0 }, { 1, 1, 1, 1 } };
        
        Boolean solutionMatch = true;

        morseCodeInputObjects = GameObject.FindGameObjectsWithTag("MorseCodeInput-" + currentDisplay.CurrentRoom);

        foreach (GameObject morseCodeInput in morseCodeInputObjects)
        {
            int currentRowInput = morseCodeInput.GetComponent<MorseCodeInputController>().CurrentInput;
            
            string rowCol = morseCodeInput.name.Split('-')[1];
            char[] rowColArr = rowCol.ToCharArray();

            int row = (int)Char.GetNumericValue(rowColArr[1]) - 1 ;
            int col = (int)Char.GetNumericValue(rowColArr[3]) - 1;
            
            if ( solutionRoom1[row, col]  != currentRowInput) {
                solutionMatch = false;
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
