using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    DisplayController currentDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();

    }

    // Update is called once per frame
    void Update()
    {
        //0 - for left button
        if (Input.GetMouseButtonDown(0)) {

        }
    }
}
