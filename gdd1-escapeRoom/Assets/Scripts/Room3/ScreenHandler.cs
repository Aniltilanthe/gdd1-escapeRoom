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
        foreach (var input in screenInputs)
        {
            if (input.name == "Input" + (dial_num + 1))
            {
                if (input.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("None"))
                    input.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Dot");
                else if (input.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Dot"))
                    input.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Line");
                else if (input.GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("General/Line"))
                    input.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
            }
        }
    }
}