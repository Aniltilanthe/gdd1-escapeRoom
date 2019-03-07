using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPassword : MonoBehaviour
{
    private DisplayController currentDisplay;
    GameObject[] rotatingDials;
    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
        rotatingDials = GameObject.FindGameObjectsWithTag("RotatingDial");
    }

    // Update is called once per frame
    void Update()
    {
        currentDisplay.InsertedPassword_W1 = "";
        for (int i = 1; i <= 5; i++)
        {
            foreach (GameObject dial in rotatingDials)
            {
                if (dial.name == "Arrow" + i)
                {
                    if (dial.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Rot_Arrow_Down"))
                        currentDisplay.InsertedPassword_W1 += "D";
                    else if (dial.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Rot_Arrow_Left"))
                        currentDisplay.InsertedPassword_W1 += "L";
                    else if (dial.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Rot_Arrow_Up"))
                        currentDisplay.InsertedPassword_W1 += "U";
                    else if (dial.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Rot_Arrow_Right"))
                        currentDisplay.InsertedPassword_W1 += "R";
                }
            }
        }
    }
}
