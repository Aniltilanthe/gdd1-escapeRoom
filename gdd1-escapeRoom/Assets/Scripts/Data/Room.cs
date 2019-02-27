using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{

    //Room information - Wall and correcponding Image name
    public Dictionary<string, string> wallInformation = new Dictionary<string, string>();
      
    public Room(string newWall1Imagename, string newWall2Imagename, string newWall3Imagename, string newWall4Imagename) 
    {
        wallInformation.Add("Wall1", newWall1Imagename);
        wallInformation.Add("Wall2", newWall2Imagename);
        wallInformation.Add("Wall3", newWall3Imagename);
        wallInformation.Add("Wall4", newWall4Imagename);
    }
}
