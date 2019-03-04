using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NavigationController : MonoBehaviour
{
    DisplayController currentDisplay;

    public GameObject[] zoomInObjectBehaviors;

    public GameObject[] morseCodeInputObjects;

    //Solution for Room puzzle
    int[,] solutionRoom1 = new int[,] { { 2, 2, 2, 0 }, { 1, 2, 2, 1 }, { 1, 0, 0, 0 }, { 2, 1, 0, 0 } };
    int[,] solutionRoom2 = new int[,] { { 1, 2, 2, 2, 2, 0 }, { 1, 1, 1, 1, 1, 0 }, { 1, 2, 2, 2, 2, 0 }, { 1, 2, 2, 2, 2, 0 }, { 2, 2, 2, 2, 1, 0 }, { 2, 2, 1, 1, 1, 0} };
    int[,] solutionRoom3 = new int[,] { { 1, 2, 2, 2, 2, 0 }, { 1, 1, 1, 1, 1, 0 }, { 1, 2, 2, 2, 2, 0 }, { 1, 2, 2, 2, 2, 0 }, { 2, 2, 2, 2, 1, 0 }, { 2, 2, 1, 1, 1, 0 } };
    int[,] solutionRoom4 = new int[,] { { 1, 2, 2, 2, 2, 0 }, { 1, 1, 1, 1, 1, 0 }, { 1, 2, 2, 2, 2, 0 }, { 1, 2, 2, 2, 2, 0 }, { 2, 2, 2, 2, 1, 0 }, { 2, 2, 1, 1, 1, 0 } };

    string solutionRoom4_2 = "RGBYG";

    IDictionary<int, string> solutionRoom4_3 = new Dictionary<int, string>()
                                            {
                                                {0, "LL"},
                                                {1, "DDD"},
                                                {2, "LDL"},
                                                {3, "LDLD"},
                                                {4, "LLDL"}
                                            };

    IDictionary<char, string> solutionRoom4_1 = new Dictionary<char, string>()
                                            {
                                                {'1', "UDLRL"},
                                                {'2', "UDLRL"},
                                                {'3', "UDLRL"},
                                                {'4', "UDLRL"}
                                            };
    IDictionary<char, string> solutionRoom4_4_1 = new Dictionary<char, string>()
                                            {
                                                //{'0', "DL"},
                                                //{'1', "LDDD"},
                                                //{'2', "DLLL"},
                                                //{'3', "DDL"},
                                                //{'4', "DLD"},
                                                //{'5', "D"}
                                                 {'0', "D"},
                                                {'1', "D"},
                                                {'2', "D"},
                                                {'3', "D"},
                                                {'4', "D"},
                                                {'5', "D"}
                                            };
    IDictionary<char, string> solutionRoom4_4_2 = new Dictionary<char, string>()
                                            {
                                                //{'0', "DDDL"},
                                                //{'1', "D"},
                                                //{'2', "LDDL"}
                                                {'0', "D"},
                                                {'1', "D"},
                                                {'2', "D"},
                                            };
    IDictionary<char, string> solutionRoom4_4_3 = new Dictionary<char, string>()
                                            {
                                                //{'0', "LLDD"},
                                                //{'1', "D"},
                                                //{'2', "DLLD"},
                                                //{'3', "DDDD"},
                                                //{'4', "LDLL"},
                                                //{'5', "DLD"}
                                                {'0', "D"},
                                                {'1', "D"},
                                                {'2', "D"},
                                                {'3', "D"},
                                                {'4', "D"},
                                                {'5', "D"}
                                            };


    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();

        zoomInObjectBehaviors = GameObject.FindGameObjectsWithTag("Interactable");

        morseCodeInputObjects = GameObject.FindGameObjectsWithTag("MorseCodeInput");
    }

    public void OnRightClickArrow() {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall + 1;

        foreach (GameObject zoomInObjectBehavior in zoomInObjectBehaviors)
        {
            //zoomInObjectBehavior.GetComponent<ZoomInObjectBehaviorController>().reset();
        }
    }

    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall = currentDisplay.CurrentWall - 1;

        foreach (GameObject zoomInObjectBehavior in zoomInObjectBehaviors)
        {
            //zoomInObjectBehavior.GetComponent<ZoomInObjectBehaviorController>().reset();
        }
    }

    public void onClickContinue()
    {
        //when level is not completed
        if (currentDisplay.CurrentState != DisplayController.State.levelComplete)
        {
            //when not puzzle solve submission wall
            if (currentDisplay.CurrentWall != 2)
            {
                onClickZoomReturn();
            }
            else
            {
                //when puzzle solve submission
                onClickUnlock();
            }
        }
        //when level is completed
        else
        {
            onGoToNextLevel();
        }
    }

    public void onClickZoomReturn()
    {

        Debug.Log("onClickZoomReturn ");

        var zoomInObjects = FindObjectsOfType<ZoomInObject>();
        foreach (var zoomInObj in zoomInObjects) {
            Debug.Log("old layer " + zoomInObj.gameObject.layer);
            zoomInObj.gameObject.layer = 0;
        }

        currentDisplay.CurrentState = DisplayController.State.normal;
        currentDisplay.resetToCurrentLevel();

        if(currentDisplay.CurrentRoom == 3 && currentDisplay.CurrentWall == 2 && currentDisplay.completedWalls.Count == 3)
        {
            if(currentDisplay.Counter_W2 == 0)
            {
                var dialPadLights = GameObject.FindGameObjectsWithTag("DialPadLight");
                foreach (var light in dialPadLights)
                {
                    light.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Light_Neutral");
                }
            }
        }

    }

    public void onGoToNextLevel()
    {
        Debug.Log("on go to next level");
        currentDisplay.onGoToNextLevel();
    }

    public void DeactivateObjects()
    {
        var screenInputs = GameObject.FindGameObjectsWithTag("ScreenInput");
        foreach (var input in screenInputs)
        {
            //input.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
            input.SetActive(false);
        }
        var screenButtons = GameObject.FindGameObjectsWithTag("ScreenButton");
        foreach (var button in screenButtons)
        {
            //input.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
            button.SetActive(false);
        }

    }

    public void ActivateObjects()
    {
        var screenInputs = GameObject.FindGameObjectsWithTag("ScreenInput");
        foreach (var input in screenInputs)
        {
            //input.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
            input.SetActive(true);
        }
        var screenButtons = GameObject.FindGameObjectsWithTag("ScreenButton");
        foreach (var button in screenButtons)
        {
            //input.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
            button.SetActive(true);
        }

    }

    public void onClickUnlock()
    {
        
        Boolean solutionMatch = true;

        morseCodeInputObjects = GameObject.FindGameObjectsWithTag("MorseCodeInput-" + currentDisplay.CurrentRoom);

        foreach (GameObject morseCodeInput in morseCodeInputObjects)
        {
            int currentRowInput = morseCodeInput.GetComponent<MorseCodeInputController>().CurrentInput;
            
            string rowCol = morseCodeInput.name.Split('-')[1];
            char[] rowColArr = rowCol.ToCharArray();

            int row = (int)Char.GetNumericValue(rowColArr[1]) - 1 ;
            int col = (int)Char.GetNumericValue(rowColArr[3]) - 1;
            

            if (currentDisplay.CurrentRoom == 1)
            {
                if (solutionRoom1[row, col] != currentRowInput)
                {
                    solutionMatch = false;
                }
            }
            else if (currentDisplay.CurrentRoom == 2)
            {
                if (solutionRoom2[row, col] != currentRowInput)
                {
                    solutionMatch = false;
                }
            } else if (currentDisplay.CurrentRoom == 3)
            {
                if (solutionRoom3[row, col] != currentRowInput)
                {
                    solutionMatch = false;
                }
            } else if (currentDisplay.CurrentRoom == 4)
            {
                if (solutionRoom4[row, col] != currentRowInput)
                {
                    solutionMatch = false;
                }
            }
        }

        if (currentDisplay.CurrentRoom == 1)
        {
            //if (solutionRoom1[row, col] != currentRowInput)
            //{
            //    solutionMatch = false;
            //}
        }
        else if (currentDisplay.CurrentRoom == 2)
        {
            //if (solutionRoom2[row, col] != currentRowInput)
            //{
            //    solutionMatch = false;
            //}
        }
        else if (currentDisplay.CurrentRoom == 3)
        {
            if (currentDisplay.CurrentWall == 1)
            {
                var zoomInObject = FindObjectOfType<ZoomInObject>();
                char num = zoomInObject.zoomedInImageName[zoomInObject.zoomedInImageName.Length - 1];
                Debug.Log("num:" + num);
                int next = num - '0';
                if (zoomInObject.zoomedInImageName != "Switches_screen_END")
                {
                    if (currentDisplay.InsertedPassword_W1 == solutionRoom4_1[num])
                    {
                        currentDisplay.InsertedPassword_W1 = "";
                        if (next != 4)
                        {
                            zoomInObject.zoomedInImageName = "Switches_screen_" + (next + 1);
                            onClickZoomReturn();
                        }
                        else
                        {
                            zoomInObject.zoomedInImageName = "Switches_screen_END";
                            currentDisplay.completedWalls.Add(currentDisplay.CurrentWall);
                            onClickZoomReturn();
                            currentDisplay.showImage("solved");
                        }


                    }
                    else solutionMatch = false;
                }
                else
                {
                    onClickZoomReturn();
                    currentDisplay.showImage("solved");
                }


            }
            else if (currentDisplay.CurrentWall == 2)
            {
                if (currentDisplay.completedWalls.Count == 3)
                {
                    Debug.Log(currentDisplay.InsertedPassword_W2);
                    if (currentDisplay.InsertedPassword_W2 == solutionRoom4_2)
                    {
                        var dialPadLights = GameObject.FindGameObjectsWithTag("DialPadLight");
                        foreach (var light in dialPadLights)
                        {
                            light.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Light_Green");
                        }
                        currentDisplay.onLevelComplete();
                    }
                    else
                    {
                        currentDisplay.InsertedPassword_W2 = "";
                        currentDisplay.Counter_W2 = 0;
                        var dialPadLights = GameObject.FindGameObjectsWithTag("DialPadLight");
                        foreach (var light in dialPadLights)
                        {
                            light.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("General/Light_OFF");
                        }
                    }
                }
                else onClickZoomReturn();
            }
            else if (currentDisplay.CurrentWall == 3)
            {
               
                Debug.Log(currentDisplay.InsertedPassword_W3);
                if (currentDisplay.InsertedPassword_W3 == solutionRoom4_3[currentDisplay.Current_screen_W3])
                {
                    currentDisplay.Current_screen_W3++;
                    Debug.Log("Wall3_Screen_wall_" + currentDisplay.Current_screen_W3);
                    currentDisplay.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Wall3_Screen_wall_" + currentDisplay.Current_screen_W3);
                    onClickZoomReturn();
                    currentDisplay.showImage("Screen_wall_" + currentDisplay.Current_screen_W3);

                }
                
            }
            else if (currentDisplay.CurrentWall == 4)
            {
                var zoomInObjects = FindObjectsOfType<ZoomInObject>();
                Debug.Log("ContinueWall4 ");
                ZoomInObject zoomInObject = null;
                foreach (var zoomObj in zoomInObjects)
                {
                    if (zoomObj.zoomedInImageName.Contains("screen"))
                        zoomInObject = zoomObj;
                }
                char num = zoomInObject.zoomedInImageName[zoomInObject.zoomedInImageName.Length - 1];
                int next = num - '0';

                if (zoomInObject.zoomedInImageName == "screen_morse_hints")  // TODO how to know which zoomed object is active???
                {
                    Debug.Log("FUUUUCK00 " + zoomInObject.zoomedInImageName);

                    onClickZoomReturn();
                }
                else if (zoomInObject.zoomedInImageName != "screen_Solution")
                {
                    Debug.Log("ContinueWall4_1 ");
                    if (zoomInObject.zoomedInImageName.Contains("screen_ABJURE_"))
                    {
                        Debug.Log("ContinueWall4_2 ");
                        if (next == 6)
                        {
                            //ActivateObjects();
                            zoomInObject.zoomedInImageName = "screen_VEX_0";
                            currentDisplay.showImage(zoomInObject.zoomedInImageName);
                            var screenInputs = GameObject.FindGameObjectsWithTag("ScreenInput");
                            foreach (var input in screenInputs)
                            {
                                input.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
                            }
                        }
                        else if (currentDisplay.InsertedPassword_W4 == solutionRoom4_4_1[num])
                        {
                            Debug.Log("ContinueWall4_3 ");
                            //if (next == 5)
                            //{
                            //    DeactivateObjects();                      TODO? WHY SETACTIVE(TRUE) NOT WORKING???

                            //}
                            currentDisplay.InsertedPassword_W4 = "";


                            zoomInObject.zoomedInImageName = "screen_ABJURE_" + (next + 1);
                            currentDisplay.showImage(zoomInObject.zoomedInImageName);
                            var screenInputs = GameObject.FindGameObjectsWithTag("ScreenInput");
                            foreach (var input in screenInputs)
                            {
                                input.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
                            }


                        }
                        else solutionMatch = false;
                    }
                    else if (zoomInObject.zoomedInImageName.Contains("screen_VEX_"))
                    {
                        if (next == 3)
                        {
                            zoomInObject.zoomedInImageName = "screen_ZEPHYR_0";
                            currentDisplay.showImage(zoomInObject.zoomedInImageName);
                            var screenInputs = GameObject.FindGameObjectsWithTag("ScreenInput");
                            foreach (var input in screenInputs)
                            {
                                input.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
                            }
                        }
                        else if (currentDisplay.InsertedPassword_W4 == solutionRoom4_4_2[num])
                        {
                            currentDisplay.InsertedPassword_W4 = "";


                            zoomInObject.zoomedInImageName = "screen_VEX_" + (next + 1);
                            currentDisplay.showImage(zoomInObject.zoomedInImageName);
                            var screenInputs = GameObject.FindGameObjectsWithTag("ScreenInput");
                            foreach (var input in screenInputs)
                            {
                                input.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
                            }

                        }
                        else solutionMatch = false;
                    }
                    else if (zoomInObject.zoomedInImageName.Contains("screen_ZEPHYR_"))
                    {
                        if (next == 6)
                        {
                            zoomInObject.zoomedInImageName = "screen_Solution";
                            currentDisplay.completedWalls.Add(currentDisplay.CurrentWall);
                            currentDisplay.showImage(zoomInObject.zoomedInImageName);
                            var screenInputs = GameObject.FindGameObjectsWithTag("ScreenInput");
                            foreach (var input in screenInputs)
                            {
                                input.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
                                input.SetActive(false);
                            }
                        }
                        else if (currentDisplay.InsertedPassword_W4 == solutionRoom4_4_3[num])
                        {
                            currentDisplay.InsertedPassword_W4 = "";


                            zoomInObject.zoomedInImageName = "screen_ZEPHYR_" + (next + 1);
                            currentDisplay.showImage(zoomInObject.zoomedInImageName);
                            var screenInputs = GameObject.FindGameObjectsWithTag("ScreenInput");
                            foreach (var input in screenInputs)
                            {
                                input.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("None");
                            }

                        }
                        else solutionMatch = false;
                    }
                }
                else
                {
                    onClickZoomReturn();
                    currentDisplay.showImage("solved");
                }
            }
        }
        //else if (currentDisplay.CurrentRoom == 4)
        //{
        //    if (solutionRoom4[row, col] != currentRowInput)
        //    {
        //        solutionMatch = false;
        //    }
        //}

        if (currentDisplay.CurrentRoom != 3)
        {
            if (solutionMatch)
            {
                Debug.Log("Solution matched");

                currentDisplay.onLevelComplete();
            }
            else
            {
                Debug.Log("Solution Not matched");
            }
        }
    }
    

    public void onClickCheck()
    {
        Debug.Log("kukam");
    }

}
