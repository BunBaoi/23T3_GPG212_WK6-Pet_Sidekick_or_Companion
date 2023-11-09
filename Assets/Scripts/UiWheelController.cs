using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiWheelController : MonoBehaviour
{
    public Animator ani;
    public bool uiWheelSelected = false;
    public Image selectedAction;
    public Sprite noImage;
    public static int statusID;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            uiWheelSelected = !uiWheelSelected;
        }

        if (uiWheelSelected)
        {
            ani.SetBool("OpenUiWheel", true);
        }
        else
        {
            ani.SetBool("OpenUiWheel", false);
        }


        // Call for function here;
        switch (statusID)
        {
            case 0: // nothing is selected
                selectedAction.sprite = noImage;
                break;
            case 1: // Follow
                Debug.Log("Follow");
                break;
            case 2: // Stop
                Debug.Log("Stop");
                break;
            case 3: // Go to
                Debug.Log("Go to");
                break;
            case 4: // Interact
                Debug.Log("Talk that talk");
                break;
        }
    }
}
