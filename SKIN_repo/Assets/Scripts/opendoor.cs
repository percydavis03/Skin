using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class opendoor : MonoBehaviour
{
   //public PlayerInputActions playerControls;
    //private InputAction interact;

    public bool InRange;

    private Animator rubyAnimator;
    private void Start()
    {
        InRange = false;
        rubyAnimator = GetComponent<Animator>();
        //playerControls = new PlayerInputActions();
    }
    private void OnEnable()
    {
        
        //interact = playerControls.Player.Interact;
        //interact.Enable();
    }

    private void OnDisable()
    {
       
        //interact.Disable();
    }

    private void LateUpdate()
    {
        /*if (interact.IsPressed())
        {
            print("open");
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //rubyAnimator.SetBool("isRunning", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            InRange = false;
        }
    }
}
