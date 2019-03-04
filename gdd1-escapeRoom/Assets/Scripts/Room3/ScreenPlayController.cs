using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPlayController : MonoBehaviour
{
    private DisplayController currentDisplay;
    public AudioSource sound;
    AudioSource audioo;

    IDictionary<char, string> codes_screen_1 = new Dictionary<char, string>()
                                            {
                                                {'0', "DL"},
                                                {'1', "LDDD"},
                                                {'2', "DLLL"},
                                                {'3', "DDD"},
                                                {'4', "DLL"},
                                                {'5', "D"}
                                            };
    IDictionary<char, string> codes_screen_2 = new Dictionary<char, string>()
                                            {
                                                {'0', "DDDL"},
                                                {'1', "D"},
                                                {'2', "LDDL"}
                                            };
    IDictionary<char, string> codes_screen_3 = new Dictionary<char, string>()
                                            {
                                                {'0', "LLDD"},
                                                {'1', "D"},
                                                {'2', "DLLD"},
                                                {'3', "DDDD"},
                                                {'4', "LDLL"},
                                                {'5', "DLD"}
                                            };

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
        //source.playOnAwake = false;
    }

    void playSound()
    {
        Debug.Log("Sound");
        audioo = gameObject.AddComponent<AudioSource>();
        StartCoroutine(Waiter());
        // Wait for the audio to have finished


    }

    IEnumerator Waiter()
    {
        IDictionary<char, string> currentCodes;
        var zoomInObjects = FindObjectsOfType<ZoomInObject>();
        ZoomInObject zoomInObject = null;
        foreach(var zoomObj in zoomInObjects)
        {
            if (zoomObj.zoomedInImageName.Contains("screen"))
                zoomInObject = zoomObj;
        }
        char key = zoomInObject.zoomedInImageName[zoomInObject.zoomedInImageName.Length - 1];
        if (zoomInObject.zoomedInImageName.Contains("ABJURE"))
            currentCodes = codes_screen_1;
        else if (zoomInObject.zoomedInImageName.Contains("VEX"))
            currentCodes = codes_screen_2;
        else currentCodes = codes_screen_3;

        foreach (char c in currentCodes[key])
        {
            AudioClip a;
            if (c == 'D')
            {
                audioo.PlayOneShot((AudioClip)Resources.Load("dot"));
                a = (AudioClip)Resources.Load("dot");
                yield return new WaitForSeconds(a.length + .5f);
            }
            else if(c == 'L')
            {
                audioo.PlayOneShot((AudioClip)Resources.Load("dash"));
                a = (AudioClip)Resources.Load("dash");
                yield return new WaitForSeconds(a.length + .5f);
            }
            
            
        }
    }
}
