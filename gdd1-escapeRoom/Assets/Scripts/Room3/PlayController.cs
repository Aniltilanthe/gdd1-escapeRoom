using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    private DisplayController currentDisplay;
    public GameObject image;

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
        image = GameObject.FindGameObjectWithTag("ScreenImage");
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
        //var previous = currentDisplay.GetComponent<SpriteRenderer>().sprite;
        char num = currentDisplay.GetComponent<SpriteRenderer>().sprite.name[currentDisplay.GetComponent<SpriteRenderer>().sprite.name.Length - 1];
        int key = num - '0';
        foreach (char c in codes_screen[key])
        {
            //Debug.Log("UUUUUUU " + c + currentDisplay.GetComponent<SpriteRenderer>().sprite);
            //Debug.Log("UUUUUUU " + "Room3/Wall3_Screen_wall_mini_screen_solution_" + currentDisplay.Current_screen_W3);
            //currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Room3/Wall3_Screen_wall_mini_screen_solution_" + currentDisplay.Current_screen_W3);
            //if(c == 'D')
            //    yield return new WaitForSeconds(1.5f);
            //else yield return new WaitForSeconds(3f);
            //currentDisplay.GetComponent<SpriteRenderer>().sprite = previous;
            //yield return new WaitForSeconds(0.25f);
            image.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/White_square");
            if (c == 'D')
                yield return new WaitForSeconds(0.25f);
            else yield return new WaitForSeconds(0.75f);
            image.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
            yield return new WaitForSeconds(0.5f);
        }
    }
}