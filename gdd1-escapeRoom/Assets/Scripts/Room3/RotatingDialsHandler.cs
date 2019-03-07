using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingDialsHandler : MonoBehaviour
{
    private DisplayController currentDisplay;
    public GameObject[] rotatingDials;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
        rotatingDials = GameObject.FindGameObjectsWithTag("RotatingDial");
        Debug.Log("Buttons" + rotatingDials.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotateDial(int dial_num)
    {
        Debug.Log("HMMM"+rotatingDials[dial_num]);
        foreach (var dial in rotatingDials)
        {
            if (dial.name == "Arrow" + (dial_num + 1))
            {
                if (dial.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Rot_Arrow_Down"))
                    dial.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Rot_Arrow_Left");
                else if (dial.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Rot_Arrow_Left"))
                    dial.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Rot_Arrow_Up");
                else if (dial.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Rot_Arrow_Up"))
                    dial.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Rot_Arrow_Right");
                else if (dial.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Rot_Arrow_Right"))
                    dial.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Rot_Arrow_Down");
            }
        }
    }
}
