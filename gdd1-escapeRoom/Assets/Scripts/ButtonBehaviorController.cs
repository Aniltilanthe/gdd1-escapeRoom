using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviorController : MonoBehaviour
{
    public enum ButtonId
    {
        navigationButton, returnButton, continueButton
    }

    public ButtonId ThisButtonId;

    private DisplayController currentDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
    }

    void Update()
    {
        HideDisplay();
        Display();
    }

    void Display()
    {
        //on Normal state
        // show only navigation buttons
        if (currentDisplay.CurrentState == DisplayController.State.normal && ThisButtonId == ButtonId.navigationButton)
        {
            if (GetComponent<Image>() != null)
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                   GetComponent<Image>().color.b, 1);
            }
            GetComponent<Button>().enabled = true;
        }

        //On Zoom state
        //Show back button - to go back to normal state
        // on Wall 2 (Puzzle wall) show back and continue (to submit solution)
        if (currentDisplay.CurrentState == DisplayController.State.zoom)
        {
            if (ThisButtonId == ButtonId.returnButton) {
                if (GetComponent<Image>() != null)
                {
                    GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                        GetComponent<Image>().color.b, 1);
                }
                GetComponent<Button>().enabled = true;
            }

            if (currentDisplay.CurrentWall == 2 && ThisButtonId == ButtonId.continueButton)
            {
                if (GetComponent<Image>() != null)
                {
                    GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                       GetComponent<Image>().color.b, 1);
                }
                GetComponent<Button>().enabled = true;
            }
        }

        //On level complete state
        //show continue button - to go to next level 
        if (currentDisplay.CurrentState == DisplayController.State.levelComplete)
        {
            if (ThisButtonId == ButtonId.continueButton)
            {
                GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                    GetComponent<Image>().color.b, 1);
                GetComponent<Button>().enabled = true;
            }
        }
    }

    void HideDisplay() {

        //on Normal state
        // show only navigation buttons
        if (currentDisplay.CurrentState == DisplayController.State.normal)
        {
            if (ThisButtonId != ButtonId.navigationButton)
            {
                if (GetComponent<Image>() != null)
                {
                    GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                                GetComponent<Image>().color.b, 0);
                }
                GetComponent<Button>().enabled = false;
                this.transform.SetSiblingIndex(0);
            }
        }

        //In zoom in state 
        // Hide the navigation buttons
        // Show the back button to go back to normal 
        // show Continue to submit puzzle solution on wall 2
        if (currentDisplay.CurrentState == DisplayController.State.zoom)
        {
            if (ThisButtonId == ButtonId.navigationButton)
            {
                if (GetComponent<Image>() != null)
                {
                    GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                            GetComponent<Image>().color.b, 0);
                }
                GetComponent<Button>().enabled = false;
                this.transform.SetSiblingIndex(0);
            }

            //show continue button only on wall 2
            if (currentDisplay.CurrentWall != 2 && ThisButtonId == ButtonId.continueButton) 
            {
                if (GetComponent<Image>() != null)
                {
                    GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                            GetComponent<Image>().color.b, 0);
                }
                GetComponent<Button>().enabled = false;
                this.transform.SetSiblingIndex(0);
            }
        }

        //on level complete just show the 'Continue' button - to go to next level - Hide all others
        if (currentDisplay.CurrentState == DisplayController.State.levelComplete)
        {
            if (ThisButtonId != ButtonId.continueButton)
            {
                if (GetComponent<Image>() != null)
                {
                    GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                            GetComponent<Image>().color.b, 0);
                }
                GetComponent<Button>().enabled = false;
                this.transform.SetSiblingIndex(0);
            }

        }
    }
}
