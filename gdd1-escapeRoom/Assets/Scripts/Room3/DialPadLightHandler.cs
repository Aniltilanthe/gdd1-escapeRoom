using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialPadLightHandler : MonoBehaviour
{
    private DisplayController currentDisplay;
    public GameObject[] dialPadLights;
    public GameObject[] dialPadButtons;
    public bool dialPadActive = true;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
        dialPadLights = GameObject.FindGameObjectsWithTag("DialPadLight");
        dialPadButtons = GameObject.FindGameObjectsWithTag("DialPadButton");
        Debug.Log("tuto" + dialPadButtons.Length);
        currentDisplay.Counter_W2 = 0;
        //Display();
    }

    public void OnRedClick()
    {
        Debug.Log("RED");
        if (currentDisplay.Counter_W2 < dialPadLights.Length && currentDisplay.completedWalls.Count == 3)
        {
            dialPadLights[currentDisplay.Counter_W2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Light_OFF");
            currentDisplay.InsertedPassword_W2 += "R";
            currentDisplay.Counter_W2++;
        }
    }

    public void OnGreenClick()
    {
        Debug.Log("GREEN");
        if (currentDisplay.Counter_W2 < dialPadLights.Length && currentDisplay.completedWalls.Count == 3)
        {
            dialPadLights[currentDisplay.Counter_W2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Light_Green");
            currentDisplay.InsertedPassword_W2 += "G";
            currentDisplay.Counter_W2++;
        }
    }

    public void OnBlueClick()
    {
        Debug.Log("BLUE");
        if (currentDisplay.Counter_W2 < dialPadLights.Length && currentDisplay.completedWalls.Count == 3)
        {
            dialPadLights[currentDisplay.Counter_W2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Light_Blue");
            currentDisplay.InsertedPassword_W2 += "B";
            currentDisplay.Counter_W2++;
        }
    }

    public void OnYellowClick()
    {
        Debug.Log("YELLOW");
        if (currentDisplay.Counter_W2 < dialPadLights.Length && currentDisplay.completedWalls.Count == 3)
        {
            dialPadLights[currentDisplay.Counter_W2].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Light_ON");
            currentDisplay.InsertedPassword_W2 += "Y";
            currentDisplay.Counter_W2++;
        }
    }
}
