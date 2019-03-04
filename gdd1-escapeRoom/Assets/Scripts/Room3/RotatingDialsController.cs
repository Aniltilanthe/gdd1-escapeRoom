using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingDialsController : MonoBehaviour
{
    private DisplayController currentDisplay;
    public enum Type { up, down, left, right };


    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Rot_Arrow_Down");
        Debug.Log("Rotating-Start" + GetComponent<SpriteRenderer>().sprite.name.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
