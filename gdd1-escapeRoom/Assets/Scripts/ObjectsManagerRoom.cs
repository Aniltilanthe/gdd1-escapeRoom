using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManagerRoom : MonoBehaviour
{
    private DisplayController currentDisplay;

    public GameObject[] ObjectsToManage;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
    }

    // Update is called once per frame
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
                if (ObjectsToManage[i].name == ("Room" + currentDisplay.CurrentRoom))
                {
                    ObjectsToManage[i].SetActive(true);
                }
                else
                {
                    ObjectsToManage[i].SetActive(false);
                }
            }
        }
    }
}