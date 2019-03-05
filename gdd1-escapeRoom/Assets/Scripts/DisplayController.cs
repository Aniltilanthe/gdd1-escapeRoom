using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : MonoBehaviour
{
    public enum State { normal, zoom, levelComplete };
    public State CurrentState { get; set; }
    public string InsertedPassword_W1 { get; set; }
    public string InsertedPassword_W2 { get; set; }
    public string InsertedPassword_W3 { get; set; }
    public int Counter_W2 { get; set; }
    public int Current_screen_W3 { get; set; }
    public string InsertedPassword_W4 { get; set; }
    public List<int> completedWalls = new List<int>();

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
                currentWall = 1;
            else if (value == 0)
                currentWall = 4;
            else
                currentWall = value;
        }
    }
    private int currentWall;
    private int previousWall;
    private string insertedPassword_W1;
    private string insertedPassword_W2;
    private string insertedPassword_W3;
    private int counter_W2;
    private int current_screen_W3;
    private string insertedPassword_W4;

    private Dictionary<string, Room> roomInformation = new Dictionary<string, Room>();

    //For playing audio
    private AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //Start with Room1
        CurrentRoom = 1;

        //Stage/wall in the room
        previousWall = 4;
        currentWall = 1;

        //init room information
        initRoomInformation();

        audioPlayer = gameObject.AddComponent<AudioSource>();
        audioPlayer.volume = 0.1f; // Because otherwise you wouldn't hear the walking
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWall != previousWall    &&  CurrentState.ToString().Equals(State.normal.ToString()) ) {

            string room = "Room" + CurrentRoom.ToString();
            Room  currentRoomObj = roomInformation[room];
            string wallImageName = currentRoomObj.wallInformation["Wall" + currentWall.ToString()];

            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(room + "/" + wallImageName);


            if (completedWalls.Contains(currentWall))
                 GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room" + CurrentRoom.ToString() + "/Wall" + currentWall.ToString() + "_solved");
        }

        previousWall = currentWall;
    }

    private void Awake()
    {
        
    }

    public void showImage(string imageName)
    {
        string room = "Room" + CurrentRoom.ToString();
        Room currentRoomObj = roomInformation[room];
        string wallImageName = currentRoomObj.wallInformation["Wall" + currentWall.ToString()];

        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(room + "/" + wallImageName + "_" + imageName.ToString());

        //GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room" + CurrentRoom.ToString() + "/Wall" + currentWall.ToString() + "_" + imageName.ToString());
    }

    public void resetToCurrentLevel() {


        string room = "Room" + CurrentRoom.ToString();
        Room currentRoomObj = roomInformation[room];
        string wallImageName = currentRoomObj.wallInformation["Wall" + currentWall.ToString()];

        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(room + "/" + wallImageName );

        //GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room" + CurrentRoom.ToString() + "/Wall" + currentWall.ToString());

        if (completedWalls.Contains(currentWall))
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room" + CurrentRoom.ToString() + "/Wall" + currentWall.ToString() + "_solved");

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
        previousWall = 4;
        currentWall = 1;

        //state to normal
        CurrentState = State.normal;

        //reset images
        resetToCurrentLevel();        
    }

    public void updateRoomInformation(string room, string wall, string newWallImageName)
    {
        Room currentRoomObj = roomInformation[room];

        currentRoomObj.wallInformation.Remove(wall);

        currentRoomObj.wallInformation.Add(wall, newWallImageName);

        resetToCurrentLevel();
    }


    //Initial room information - Room and Wall correcponding Images
    private void initRoomInformation()
    {

        Room room1 = new Room("Wall1", "Wall2", "Wall3", "Wall4");
        Room room2 = new Room("Wall1", "Wall2", "Wall3", "Wall4");
        Room room3 = new Room("Wall1", "Wall2", "Wall3", "Wall4");
        Room room4 = new Room("Wall1", "Wall2", "Wall3", "Wall4");

        roomInformation.Add("Room1", room1);
        roomInformation.Add("Room2", room2);
        roomInformation.Add("Room3", room3);
        roomInformation.Add("Room4", room4);
    }


    public void PlayPuzzleSuccess()
    {
        PlayAudio("Audio/PuzzleSuccess-2");
    }

    public void PlayPuzzleFail()
    {
        PlayAudio("Audio/PuzzleFail");
    }

    void PlayAudio(string fileName)
    {
        if (fileName != null)
        {
            audioPlayer.PlayOneShot((AudioClip)Resources.Load(fileName));
        }
    }
}
