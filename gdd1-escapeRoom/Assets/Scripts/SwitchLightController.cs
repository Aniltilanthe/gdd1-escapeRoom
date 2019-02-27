using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchLightController : MonoBehaviour
{
    //Lights
    public GameObject FirstLight;
    public GameObject SecondLight;
    public GameObject ThirdLight;
    public GameObject FourthLight;
    public GameObject FifthLight;
    public GameObject SixthLight;

    //Corresponding switches - for each light
    public GameObject FirstLightSwitch;
    public GameObject SecondLightSwitch;
    public GameObject ThirdLightSwitch;
    public GameObject FourthLightSwitch;
    public GameObject FifthLightSwitch;
    public GameObject SixthLightSwitch;

    private DisplayController currentDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();
    }
    
    //  lightNewState =  lightSwitchNewState    XOR     lightOldState
    public void onPressLightSwitch(int thisLightSwitchNumber)
    {
        switch (thisLightSwitchNumber)
        {
            case 1: {
                    FirstLight.GetComponent<Toggle>().isOn = FirstLightSwitch.GetComponent<Toggle>().isOn ^ FirstLight.GetComponent<Toggle>().isOn;
                    break;
                }
            case 2:
                {
                    SecondLight.GetComponent<Toggle>().isOn = SecondLightSwitch.GetComponent<Toggle>().isOn ^ FirstLight.GetComponent<Toggle>().isOn;
                    break;
                }
            case 3:
                {
                    ThirdLight.GetComponent<Toggle>().isOn = ThirdLightSwitch.GetComponent<Toggle>().isOn ^ FirstLight.GetComponent<Toggle>().isOn;
                    break;
                }
            case 4:
                {
                    FourthLight.GetComponent<Toggle>().isOn = FourthLightSwitch.GetComponent<Toggle>().isOn ^ FirstLight.GetComponent<Toggle>().isOn;
                    break;
                }
            case 5:
                {
                    FifthLight.GetComponent<Toggle>().isOn = FifthLightSwitch.GetComponent<Toggle>().isOn ^ FirstLight.GetComponent<Toggle>().isOn;
                    break;
                }
            case 6:
                {
                    SixthLight.GetComponent<Toggle>().isOn = SixthLightSwitch.GetComponent<Toggle>().isOn ^ FirstLight.GetComponent<Toggle>().isOn;
                    break;
                }
            default: break;
        }

        checkForAllLightsOn();
    }

    //when all lights are on - unlock puzzle
    private void checkForAllLightsOn()
    {
        if (FirstLight.GetComponent<Toggle>().isOn && SecondLight.GetComponent<Toggle>().isOn && ThirdLight.GetComponent<Toggle>().isOn &&
            FourthLight.GetComponent<Toggle>().isOn && FifthLight.GetComponent<Toggle>().isOn && SixthLight.GetComponent<Toggle>().isOn)
        {
            currentDisplay.updateRoomInformation("Room2", "Wall3", "Wall3_Painting_open");
        } else
        {
            currentDisplay.updateRoomInformation("Room2", "Wall3", "Wall3");
        }
    }
}
