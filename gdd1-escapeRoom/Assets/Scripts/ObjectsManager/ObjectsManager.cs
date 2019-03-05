using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    private DisplayController currentDisplay;

    public GameObject[] ObjectsToManage;

    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();

    }

    void Update()
    {
        ManageObjects();
    }

    void ManageObjects()
    {
        for (int i = 0; i < ObjectsToManage.Length; i++)
        {
            if (currentDisplay.GetComponent<SpriteRenderer>() != null && currentDisplay.GetComponent<SpriteRenderer>().sprite != null)
            {
                string[] words;
                if (currentDisplay.GetComponent<SpriteRenderer>().sprite.name.Contains("solved") && currentDisplay.CurrentRoom == 3 && currentDisplay.CurrentWall == 1)
                {
                    words = currentDisplay.GetComponent<SpriteRenderer>().sprite.name.Split('_');
                    if (ObjectsToManage[i].name == words[0])
                    {
                        ObjectsToManage[i].SetActive(true);
                    }
                }
                else if (ObjectsToManage[i].name == currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
                {
                    ObjectsToManage[i].SetActive(true);
                }
                else if (ObjectsToManage[i].name == "Wall4_screen_ABJURE_0" && currentDisplay.GetComponent<SpriteRenderer>().sprite.name.Contains("Wall4_screen_"))
                {
                    ObjectsToManage[i].SetActive(true);
                }
                else if (ObjectsToManage[i].name == "Wall3_Screen_wall_0" && currentDisplay.GetComponent<SpriteRenderer>().sprite.name.Contains("Wall3_Screen_"))
                {
                    ObjectsToManage[i].SetActive(true);
                }
                else if (ObjectsToManage[i].name == "W1_Switches_screen_1" && currentDisplay.GetComponent<SpriteRenderer>().sprite.name.Contains("Wall1_Switches_screen_"))
                {
                    ObjectsToManage[i].SetActive(true);
                }
                else if (ObjectsToManage[i].name == "Wall1_zoom" && currentDisplay.CurrentRoom == 3 && currentDisplay.CurrentWall == 1)
                {
                    ObjectsToManage[i].SetActive(true);
                }

                //else if (currentDisplay.GetComponent<SpriteRenderer>().sprite.name.Contains("Wall1_Switches_screen_") && ObjectsToManage[i].name == ("Wall1_screen") && currentDisplay.CurrentRoom == 3 && currentDisplay.CurrentWall == 1)
                //{
                //    ObjectsToManage[i].SetActive(true);
                //}
                else
                {
                    ObjectsToManage[i].SetActive(false);
                }
            }
        }
    }
}