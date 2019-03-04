using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHandler : MonoBehaviour
{
    private DisplayController currentDisplay;
    public GameObject[] screenInputs;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
        screenInputs = GameObject.FindGameObjectsWithTag("ScreenInput2");
        Debug.Log("Buttons" + screenInputs.Length);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeInput(int dial_num)
    {
        Debug.Log("ChangeInput" + screenInputs.Length);
        if (screenInputs[dial_num].GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("None"))
            screenInputs[dial_num].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Dot");
        else if (screenInputs[dial_num].GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Dot"))
            screenInputs[dial_num].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Line");
        else if (screenInputs[dial_num].GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Line"))
            screenInputs[dial_num].GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
    }
}