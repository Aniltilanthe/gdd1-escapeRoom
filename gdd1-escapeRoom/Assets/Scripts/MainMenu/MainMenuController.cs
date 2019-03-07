using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mySlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("volume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
            SetSliderValue(PlayerPrefs.GetFloat("volume"));
        }
    }

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

            PlayerPrefs.SetFloat("volume", AudioListener.volume);
        }
    }

    public void SetSliderValue(float newValue)
    {
        mySlider.GetComponent<Slider>().value = newValue;
    }

    public void OnLoadLastSaved()
    {
        // 1
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            SaveSettings save = (SaveSettings)bf.Deserialize(file);
            file.Close();

            // 4

            SaveLoader.Instance.setRoomWall(save.currentRoom, save.currentWall);

            Debug.Log("Game Loaded room" + save.currentRoom + " wall " + save.currentWall);
        }
        else
        {
            Debug.Log("No game saved!");
        }


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
