using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomInObjectBehaviorController : MonoBehaviour
{
    
    private GameObject currentGameObject;

    private DisplayController currentDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
    }

    public void reset() {

        Debug.Log("Zoom in object behaviour controller Reset Called ");
    }
}
