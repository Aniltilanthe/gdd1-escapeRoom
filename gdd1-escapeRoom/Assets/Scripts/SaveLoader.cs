using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoader : Singleton<SaveLoader>
{
    // (Optional) Prevent non-singleton constructor use.
    protected SaveLoader() { }

    public int CurrentRoom = 1;
    public int CurrentWall = 1;
    

    public void setRoomWall(int newRoom, int newWall)
    {
        CurrentRoom = newRoom;
        CurrentWall = newWall;
    }

    public void reset()
    {
        CurrentRoom = 1;
        CurrentWall = 1;
    }

}
