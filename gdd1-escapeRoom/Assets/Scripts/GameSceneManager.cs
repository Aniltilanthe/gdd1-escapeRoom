using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    DisplayController currentDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Save stuff
            SaveGame();

            SceneManager.LoadScene("Menu");
        }
    }

    public void SaveGame()
    {
        // 1
        SaveSettings save = CreateSaveGameObject();

        // 2
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
    }

    private SaveSettings CreateSaveGameObject()
    {
        SaveSettings save = new SaveSettings();

        save.currentRoom = currentDisplay.CurrentRoom;
        save.currentWall = currentDisplay.CurrentWall;

        return save;
    }
}
