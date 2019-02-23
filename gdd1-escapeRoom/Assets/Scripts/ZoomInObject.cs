using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInObject : MonoBehaviour, IInteractable
{
    public string zoomedInImageName;

    public void Interact(DisplayController currentDisplay)
    {
        gameObject.layer = 2;

        currentDisplay.showImage(zoomedInImageName);

        currentDisplay.CurrentState = DisplayController.State.zoom;
    }
}
