using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        SaveLoader.Instance.reset();
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }

    public void OnValueChanged(GameObject mySlider)
    {
        if (mySlider != null)
        {
            AudioListener.volume = mySlider.GetComponent<Slider>().value;
        }
    }

    public void OnLoadLastSaved()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            SaveController save = (SaveController)bf.Deserialize(file);
            file.Close();

            // 4
            SaveLoader.Instance.setRoomWall(save.currentRoom, save.currentWall);

            Debug.Log("Game Loaded");
        }
        else
        {
            Debug.Log("No game saved!");
        }


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
