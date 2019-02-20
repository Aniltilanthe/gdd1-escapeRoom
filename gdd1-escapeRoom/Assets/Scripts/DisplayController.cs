using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{

    public int CurrentRoom { get; set; }

    public int CurrentStage {
        get { return currentStage; }
        set {
            if (value == 5)
                currentStage = 1;
            else
                currentStage = value;
        }
    }
    private int currentStage;
    private int previousStage;

    // Start is called before the first frame update
    void Start()
    {
        //Start with Room1
        CurrentRoom = 1;

        //Stage/wall in the room
        previousStage = 0;
        currentStage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStage != previousStage) {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room"+ CurrentRoom.ToString() + "/Wall" + currentStage.ToString());
            /*
            switch (currentStage)
            {
                case 1:
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room1/Speaker");
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room1/Door");
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room1/Table");
                    break;
                case 4:
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room1/Paintings");
                    break;
                case 5:
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room1/Paper_zoom-in");
                    break;
                case 6:
                    GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room1/Paper_zoom-in");
                    break;
                default:
                    print("Incorrect intelligence level.");
                    break;
            }*/
        }

        previousStage = currentStage;
    }
}
