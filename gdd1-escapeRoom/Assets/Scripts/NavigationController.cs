using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    DisplayController currentDisplay;

    public GameObject[] zoomInObjectBehaviors;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();

        zoomInObjectBehaviors = GameObject.FindGameObjectsWithTag("Interactable");
    }

    public void OnRightClickArrow() {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;

        foreach (GameObject zoomInObjectBehavior in zoomInObjectBehaviors)
        {
            zoomInObjectBehavior.GetComponent<ZoomInObjectBehaviorController>().reset();
        }
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;

        foreach (GameObject zoomInObjectBehavior in zoomInObjectBehaviors)
        {
            zoomInObjectBehavior.GetComponent<ZoomInObjectBehaviorController>().reset();
        }
    }

    public void onClickZoomReturn()
    {

        var zoomInObjects = FindObjectsOfType<ZoomInObject>();
        foreach (var zoomInObj in zoomInObjects) {
            zoomInObj.gameObject.layer = 0;
        }

        currentDisplay.CurrentState = DisplayController.State.normal;
        currentDisplay.resetToCurrentLevel();

    }

}
