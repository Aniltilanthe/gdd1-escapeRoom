using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPassword : MonoBehaviour
{
    private DisplayController currentDisplay;
    GameObject[] screenInputs;
    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
        screenInputs = GameObject.FindGameObjectsWithTag("ScreenInput");
    }

    // Update is called once per frame
    void Update()
    {
        currentDisplay.InsertedPassword_W4 = "";
        for (int i = 1; i <= 4; i++)
        {
            foreach (GameObject screenIn in screenInputs)
            {
                if (screenIn.name == "Input" + i)
                {
                    if (screenIn.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Dot"))
                        currentDisplay.InsertedPassword_W4 += "D";
                    else if (screenIn.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Line"))
                        currentDisplay.InsertedPassword_W4 += "L";
                }
            }

        }
    }
}