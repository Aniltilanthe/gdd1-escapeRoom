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
        for ( int i= 0; i < ObjectsToManage.Length; i++ )
        {
            if (currentDisplay.GetComponent<SpriteRenderer>() != null && currentDisplay.GetComponent<SpriteRenderer>().sprite != null)
            {
                if (ObjectsToManage[i].name == currentDisplay.GetComponent<SpriteRenderer>().sprite.name)
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
