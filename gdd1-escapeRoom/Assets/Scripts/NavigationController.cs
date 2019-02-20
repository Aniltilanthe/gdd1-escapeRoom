using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    DisplayController currentDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
    }

    public void OnRightClickArrow() {
        currentDisplay.CurrentStage = currentDisplay.CurrentStage + 1;
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentStage = currentDisplay.CurrentStage - 1;
    }

}
