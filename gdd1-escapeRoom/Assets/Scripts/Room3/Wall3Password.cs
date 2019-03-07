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
        for (int i = 1; i <= 4; i++)
        {
            foreach (GameObject input in screenInputs)
            {
                if (input.name == "Input" + i)
                {
                    if (input.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Dot"))
                        currentDisplay.InsertedPassword_W3 += "D";
                    else if (input.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Line"))
                        currentDisplay.InsertedPassword_W3 += "L";
                }
            }
        }
    }
}
