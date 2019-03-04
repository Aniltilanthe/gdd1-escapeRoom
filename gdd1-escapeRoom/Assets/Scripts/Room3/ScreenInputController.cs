using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInputController : MonoBehaviour
{
    private DisplayController currentDisplay;


    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
    }

    // Update is called once per frame
    void Update()
    {

    }

}
