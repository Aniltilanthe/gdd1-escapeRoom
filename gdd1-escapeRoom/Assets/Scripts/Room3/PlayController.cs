using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    private DisplayController currentDisplay;
    
    IDictionary<int, string> codes_screen = new Dictionary<int, string>()
                                            {
                                                {0, "LL"},
                                                {1, "DDD"},
                                                {2, "LDL"},
                                                {3, "LDLD"},
                                                {4, "LLDL"}
                                            };

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
        currentDisplay.Current_screen_W3 = 0;
        //source.playOnAwake = false;
    }

    public void StartBlinking()
    {
        Debug.Log("Blink");
        StartCoroutine(Waiter());
        // Wait for the audio to have finished


    }

    IEnumerator Waiter()
    {
        var previous = currentDisplay.GetComponent<SpriteRenderer>().sprite;
        foreach (char c in codes_screen[currentDisplay.Current_screen_W3])
        {
            Debug.Log("UUUUUUU " + c + currentDisplay.GetComponent<SpriteRenderer>().sprite);
            Debug.Log("UUUUUUU " + "Room3/Wall3_Screen_wall_mini_screen_solution_" + currentDisplay.Current_screen_W3);
            currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room3/Wall3_Screen_wall_mini_screen_solution_" + currentDisplay.Current_screen_W3);
            if(c == 'D')
                yield return new WaitForSeconds(1.5f);
            else yield return new WaitForSeconds(3f);
            currentDisplay.GetComponent<SpriteRenderer>().sprite = previous;
            yield return new WaitForSeconds(0.75f);
        }
    }

    //IEnumerator Waiter()
    //{
    //    IDictionary<char, string> currentCodes;
    //    var zoomInObjects = FindObjectsOfType<ZoomInObject>();
    //    ZoomInObject zoomInObject = null;
    //    foreach (var zoomObj in zoomInObjects)
    //    {
    //        if (zoomObj.zoomedInImageName.Contains("screen"))
    //            zoomInObject = zoomObj;
    //    }
    //    char key = zoomInObject.zoomedInImageName[zoomInObject.zoomedInImageName.Length - 1];
    //    if (zoomInObject.zoomedInImageName.Contains("ABJURE"))
    //        currentCodes = codes_screen_1;
    //    else if (zoomInObject.zoomedInImageName.Contains("VEX"))
    //        currentCodes = codes_screen_2;
    //    else currentCodes = codes_screen_3;

    //    foreach (char c in currentCodes[key])
    //    {
    //        AudioClip a;
    //        if (c == 'D')
    //        {
    //            audioo.PlayOneShot((AudioClip)Resources.Load("dot"));
    //            a = (AudioClip)Resources.Load("dot");
    //            yield return new WaitForSeconds(a.length + .5f);
    //        }
    //        else if (c == 'L')
    //        {
    //            audioo.PlayOneShot((AudioClip)Resources.Load("dash"));
    //            a = (AudioClip)Resources.Load("dash");
    //            yield return new WaitForSeconds(a.length + .5f);
    //        }


    //    }
    //}
}