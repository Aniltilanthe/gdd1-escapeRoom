using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialPadLightsController : MonoBehaviour
{
    private DisplayController currentDisplay;
    public GameObject[] dialPadLights;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
        dialPadLights = GameObject.FindGameObjectsWithTag("DialPadLight");
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Light_Neutral");
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDisplay.CurrentState == DisplayController.State.zoom && currentDisplay.CurrentWall == 2)
        {
            string currentTag = gameObject.tag;

            if (currentTag == "DialPadLight")
            {
                if (GetComponent<SpriteRenderer>().sprite == Resources.Load<Sprite>("None"))
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Light_Neutral");
            }
            //GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Light_Green");
        }else GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");


    }
}
