using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomInObjectBehaviorController : MonoBehaviour
{
    public enum RoomId
    {
        one, two, three, four
    }
    public enum WallId
    {
        one, two, three, four
    }
    public RoomId ThisRoomId;
    public WallId ThisWallId;

    private GameObject currentGameObject;

    private DisplayController currentDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
    }

    public void reset() {

        Debug.Log("Zoom in object behaviour controller Reset Called ");
        //HideDisplay();
        //Display();
    }

    /*
    void HideDisplay()
    {
        gameObject.SetActive(false);
    }

    void Display()
    {
        if (ThisRoomId == RoomId.one)
        {
            if (ThisWallId == WallId.one && currentDisplay.CurrentRoom == 1 && currentDisplay.CurrentWall == 1)
            {
                gameObject.SetActive(true);
            }
            else if (ThisWallId == WallId.two && currentDisplay.CurrentRoom == 1 && currentDisplay.CurrentWall == 2)
            {
                gameObject.SetActive(true);
            }
            else if (ThisWallId == WallId.three && currentDisplay.CurrentRoom == 1 && currentDisplay.CurrentWall == 3)
            {
                gameObject.SetActive(true);
            }
            else if (ThisWallId == WallId.four && currentDisplay.CurrentRoom == 1 && currentDisplay.CurrentWall == 4)
            {
                gameObject.SetActive(true);
            }
        }
        if (ThisRoomId == RoomId.two && currentDisplay.CurrentRoom == 2)
        {
            if (ThisWallId == WallId.one && currentDisplay.CurrentWall == 1)
            {
                gameObject.SetActive(true);
            }
            else if (ThisWallId == WallId.two && currentDisplay.CurrentWall == 2)
            {
                gameObject.SetActive(true);
            }
            else if (ThisWallId == WallId.three && currentDisplay.CurrentWall == 3)
            {
                gameObject.SetActive(true);
            }
            else if (ThisWallId == WallId.four && currentDisplay.CurrentWall == 4)
            {
                gameObject.SetActive(true);
            }
        }
        if (ThisRoomId == RoomId.three && currentDisplay.CurrentRoom == 3)
        {
            if (ThisWallId == WallId.one && currentDisplay.CurrentWall == 1)
            {
                gameObject.SetActive(true);
            }
            else if (ThisWallId == WallId.two && currentDisplay.CurrentWall == 2)
            {
                gameObject.SetActive(true);
            }
            else if (ThisWallId == WallId.three && currentDisplay.CurrentWall == 3)
            {
                gameObject.SetActive(true);
            }
            else if (ThisWallId == WallId.four && currentDisplay.CurrentWall == 4)
            {
                gameObject.SetActive(true);
            }
        }
        if (ThisRoomId == RoomId.four && currentDisplay.CurrentRoom == 4)
        {
            if (ThisWallId == WallId.one && currentDisplay.CurrentWall == 1)
            {
                gameObject.SetActive(true);
            }
            else if (ThisWallId == WallId.two && currentDisplay.CurrentWall == 2)
            {
                gameObject.SetActive(true);
            }
            else if (ThisWallId == WallId.three && currentDisplay.CurrentWall == 3)
            {
                gameObject.SetActive(true);
            }
            else if (ThisWallId == WallId.four && currentDisplay.CurrentWall == 4)
            {
                gameObject.SetActive(true);
            }
        }
    } */
}
