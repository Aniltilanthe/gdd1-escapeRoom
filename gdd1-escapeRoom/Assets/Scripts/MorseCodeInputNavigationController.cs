using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MorseCodeInputNavigationController : MonoBehaviour
{
    public void OnInput(string inputRowColumn)
    {
        MorseCodeInputController currentObj = GameObject.Find("morseCodeInput" + inputRowColumn).GetComponent<MorseCodeInputController>();
     
        currentObj.CurrentInput = currentObj.CurrentInput + 1;
    }
}
