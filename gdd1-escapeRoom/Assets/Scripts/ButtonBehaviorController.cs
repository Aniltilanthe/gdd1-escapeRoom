using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviorController : MonoBehaviour
{
    public enum ButtonId
    {
        navigationButton, returnButton
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
        if (currentDisplay.CurrentState == DisplayController.State.zoom && ThisButtonId == ButtonId.returnButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }

        if (currentDisplay.CurrentState == DisplayController.State.normal && ThisButtonId == ButtonId.navigationButton)
        {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 1);
            GetComponent<Button>().enabled = true;
        }
    }

    void HideDisplay() {
        if (currentDisplay.CurrentState == DisplayController.State.normal
            && ThisButtonId == ButtonId.returnButton) {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, 
                GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }

        if (currentDisplay.CurrentState == DisplayController.State.zoom && ThisButtonId == ButtonId.navigationButton) {
            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,
                GetComponent<Image>().color.b, 0);
            GetComponent<Button>().enabled = false;
            this.transform.SetSiblingIndex(0);
        }
    }
}
