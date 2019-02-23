using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    DisplayController currentDisplay;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayImage").GetComponent<DisplayController>();

    }

    // Update is called once per frame
    void Update()
    {
        //0 - for left button
        if (Input.GetMouseButtonDown(0)) {
            Vector2 rayPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayPosition, Vector2.zero, 100);

            if (hit && hit.transform.tag == "Interactable") {
                hit.transform.GetComponent<IInteractable>().Interact(currentDisplay);
            }
        }
    }
}
