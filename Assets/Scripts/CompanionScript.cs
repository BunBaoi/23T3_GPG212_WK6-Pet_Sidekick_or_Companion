using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class CompanionScript : MonoBehaviour
{

    [Header("AI Companion")]
    public NavMeshAgent ai;
    public Transform player;
    public Animator companionAni;
    Vector3 dest;

    public enum State
    {
        follow,
        idle,
        going,
        talking
    }

    public State state;


    [Header("Crosshair")]
    public Image crossHair;
    public Sprite onLookUI;

    [Header("UI Menu")]
    public UiWheelController uiWheelController;

    //public ControllerMode Mode;
    public Transform goal;

    public void Start()
    {
        //SetMode(ControllerMode.Play);
        state = State.going;

    }

    void Update()
    {

        /*
         Animation
        if (!ai.pathPending)
        {
            if(ai.remainingDistance <= ai.stoppingDistance)
            {
                companionAni.ResetTrigger("walk");
                companionAni.SetTrigger("idle");
            }
        }
        else
        {
            companionAni.ResetTrigger("idle");
            companionAni.SetTrigger("walk");
        }

        if (Mode == ControllerMode.Menu)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SetMode(ControllerMode.Play);
                Debug.Log(Mode);

            }

            
        }
        */

        switch(state)
        {
            case State.follow:

                dest = player.position;
                ai.destination = dest;

                Debug.Log("Following");
                break;
            case State.idle:

                Debug.Log("Idling");
                break;
            case State.going:

                //ai.SetDestination(goal.position);
                ai.destination = goal.position;
                Debug.Log("Going");
                break;
            case State.talking:

                Debug.Log("Talking");
                break;
        }


    }

    // Menu on companion
    public void OnMouseOver()
    {
        crossHair.sprite = onLookUI;
        crossHair.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

        if (Input.GetKeyDown(KeyCode.E))
        {
            //UiWheelController.
            uiWheelController.uiWheelSelected = !uiWheelController.uiWheelSelected;
            //UiSwitch = true;
        }



        /*
        if (Mode == ControllerMode.Play)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                SetMode(ControllerMode.Menu);
                Debug.Log(Mode);

                MainMenuInstance = Instantiate(MainMenuPreFab, FindAnyObjectByType<Canvas>().transform);
                MainMenuInstance.callback = MenuClick;
            }

        }
        */
    }

    public void OnMouseExit()
    {
        crossHair.sprite = onLookUI;
        crossHair.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);

    }
    /*
    private void MenuClick(string path)
    {
        Debug.Log(path);
        var paths = path.Split('/');

        SetMode(ControllerMode.Play);
    }

    public void SetMode(ControllerMode mode)
    {
        Mode = mode;
        //if (mode != ControllerMode.Menu && MainMenuInstance != null)
        //    Destroy(MainMenuInstance);


        if (mode == ControllerMode.Menu)
            Destroy(MainMenuInstance);

        switch (mode)
        {
            // Unlock Mouse
            case ControllerMode.Menu:
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;

            // Lock Mouse
            case ControllerMode.Play:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
        }
    }

    public enum ControllerMode
    {
        Play,
        Menu,
    }
    */
}
