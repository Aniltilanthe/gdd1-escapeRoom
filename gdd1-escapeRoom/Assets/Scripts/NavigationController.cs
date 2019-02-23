using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationController : MonoBehaviour
{
    DisplayController currentDisplay;

    ZoomInObjectBehaviorController zoomInObjectBehavior;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();

        zoomInObjectBehavior = GameObject.Find("zoomInObject").GetComponent<ZoomInObjectBehaviorController>();
    }

    public void OnRightClickArrow() {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;

        zoomInObjectBehavior.reset();
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;

        zoomInObjectBehavior.reset();
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
