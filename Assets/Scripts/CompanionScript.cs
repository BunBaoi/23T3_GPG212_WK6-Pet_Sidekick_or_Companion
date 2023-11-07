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

    [Header("Crosshair")]
    public Image crossHair;
    public Sprite onLookUI;

    [Header("UI Menu")]
    public bool UiSwitch;
    public RingMenu MainMenuPreFab;
    protected RingMenu MainMenuInstance;

    public ControllerMode Mode;

    private void Start()
    {
        SetMode(ControllerMode.Play);
    }

    private void Update()
    {


        dest = player.position;
        ai.destination = dest;

        // Animation
        //if (!ai.pathPending)
        //{
        //    if(ai.remainingDistance <= ai.stoppingDistance)
        //    {
        //        companionAni.ResetTrigger("walk");
        //        companionAni.SetTrigger("idle");
        //    }
        //}
        //else
        //{
        //    companionAni.ResetTrigger("idle");
        //    companionAni.SetTrigger("walk");
        //}

        if (Mode == ControllerMode.Menu)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SetMode(ControllerMode.Play);
                Debug.Log(Mode);

            }

            
        }
    }

    // Menu on companion
    public void OnMouseOver()
    {
        crossHair.sprite = onLookUI;
        crossHair.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);

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
    }

    public void OnMouseExit()
    {
        crossHair.sprite = onLookUI;
        crossHair.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);

    }

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
}
