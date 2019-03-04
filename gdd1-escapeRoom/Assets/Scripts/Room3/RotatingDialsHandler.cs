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
        if (rotatingDials[dial_num].GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Rot_Arrow_Down"))
            rotatingDials[dial_num].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Rot_Arrow_Left");
        else if (rotatingDials[dial_num].GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Rot_Arrow_Left"))
            rotatingDials[dial_num].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Rot_Arrow_Up");
        else if (rotatingDials[dial_num].GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Rot_Arrow_Up"))
            rotatingDials[dial_num].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Rot_Arrow_Right");
        else if (rotatingDials[dial_num].GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Rot_Arrow_Right"))
            rotatingDials[dial_num].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Rot_Arrow_Down");
    }
}
