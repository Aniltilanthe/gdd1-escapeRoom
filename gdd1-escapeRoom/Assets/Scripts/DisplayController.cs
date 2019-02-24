using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    public enum State { normal, zoom, levelComplete };
    public State CurrentState { get; set; }

    //Rooms - 1,2,3,4
    public int CurrentRoom
    {
        get { return currentRoom; }
        set
        {
            if (value == 5)
                currentRoom = 4;
            else
                currentRoom = value;
        }
    }
    private int currentRoom;

    //Walls - 1,2,3,4
    public int CurrentWall {
        get { return currentWall; }
        set {
            if (value == 5)
                onExit();
            else
                currentWall = value;
        }
    }
    private int currentWall;
    private int previousWall;

    private GameObject[] morseCodeInputObjects;

    // Start is called before the first frame update
    void Start()
    {
        //Start with Room1
        CurrentRoom = 1;

        //Stage/wall in the room
        previousWall = 0;
        currentWall = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWall != previousWall    &&  CurrentState.ToString().Equals(State.normal.ToString()) ) {
     
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room"+ CurrentRoom.ToString() + "/Wall" + currentWall.ToString());
        }

        previousWall = currentWall;
    }

    public void showImage(string imageName)
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room" + CurrentRoom.ToString() + "/Wall" + currentWall.ToString() + "_" + imageName.ToString());
    }

    public void resetToCurrentLevel() {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room" + CurrentRoom.ToString() + "/Wall" + currentWall.ToString());
    }

    public void onLevelComplete()
    {
        showImage("End");
        CurrentState = State.levelComplete;
    }

    public void onGoToNextLevel()
    {
        CurrentRoom = CurrentRoom + 1;
        resetToLevelStart();
    }

    public void onExit()
    {
    }

    public void resetToLevelStart()
    {
        //Stage/wall in the room
        previousWall = 0;
        currentWall = 1;

        resetToCurrentLevel();

        resetOtherLevelUIElements();
    }

    public void resetOtherLevelUIElements()
    {

        for (int i = 1; i <= 4; i++)
        {
            if (i != CurrentRoom)
            {
                morseCodeInputObjects = GameObject.FindGameObjectsWithTag("MorseCodeInput-" + i);

                foreach (GameObject morseCodeInput in morseCodeInputObjects)
                {
                    morseCodeInput.SetActive(false);
                }
            } else
            {
                morseCodeInputObjects = GameObject.FindGameObjectsWithTag("MorseCodeInput-" + i);

                foreach (GameObject morseCodeInput in morseCodeInputObjects)
                {
                    morseCodeInput.SetActive(true);
                }
            }
        }
    }
}
