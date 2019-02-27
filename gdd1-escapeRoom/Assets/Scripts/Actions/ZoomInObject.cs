using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInObject : MonoBehaviour, IInteractable
{
    public string zoomedInImageName;

    public void Interact(DisplayController currentDisplay)
    {
        Debug.Log("Zoom in object " + zoomedInImageName);
        //Bug fix - for unable to click again ! - changing Layer from Default to another
        //gameObject.layer = 2;

        currentDisplay.showImage(zoomedInImageName);

        currentDisplay.CurrentState = DisplayController.State.zoom;
    }
}
