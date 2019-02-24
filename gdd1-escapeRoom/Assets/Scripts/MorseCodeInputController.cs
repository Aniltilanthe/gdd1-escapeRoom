using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseCodeInputController : MonoBehaviour
{

    //Code - empty, 0, 1
    public int CurrentInput
    {
        get { return currentInput; }
        set
        {
            if (value == 3)
                currentInput = 0;
            else
                currentInput = value;
        }
    }
    private int currentInput;
    private int previousInput;

    // Start is called before the first frame update
    void Start()
    {
        //Start with empty
        CurrentInput = 0;

        //input value
        previousInput = 0;
        currentInput = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInput != previousInput )
        {
            Debug.Log("on Morse Code controller currentInput != previous" + currentInput + "  previous " + previousInput );
            if (currentInput == 0) {
                GetComponent<SpriteRenderer>().sprite = null;
            }
            if (currentInput == 1) {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Dot");
            }
            else if (currentInput == 2)
            {
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Line");
            }
        }

        previousInput = currentInput;
    }
}
