using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    public enum State { normal, zoom };
    public State CurrentState { get; set; }

    //Rooms - 1,2,3,4
    public int CurrentRoom { get; set; }

    //Walls - 1,2,3,4
    public int CurrentWall {
        get { return currentWall; }
        set {
            if (value == 5)
                currentWall = 1;
            else
                currentWall = value;
        }
    }
    private int currentWall;
    private int previousWall;

    private bool isZoomedIn = false;

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
}
