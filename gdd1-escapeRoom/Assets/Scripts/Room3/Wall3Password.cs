using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall3Password : MonoBehaviour
{
    private DisplayController currentDisplay;
    GameObject[] screenInputs;
    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
        screenInputs = GameObject.FindGameObjectsWithTag("ScreenInput2");
    }

    // Update is called once per frame
    void Update()
    {
        currentDisplay.InsertedPassword_W3 = "";
        foreach (GameObject screenIn in screenInputs)
        {
            if (screenIn.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Dot"))
                currentDisplay.InsertedPassword_W3 += "D";
            else if (screenIn.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Line"))
                currentDisplay.InsertedPassword_W3 += "L";
        }
    }
}
