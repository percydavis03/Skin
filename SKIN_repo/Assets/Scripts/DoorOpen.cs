using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorOpen : MonoBehaviour
{
    public GameObject Instruction;
    public GameObject LightInstruction;
    private Animator AnimObject;
    public BoxCollider ThisTrigger;
    //public AudioSource DoorOpenSound;
    public bool Action = false;

    void Start()
    {
        Instruction.SetActive(false);
        AnimObject = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "PlayerwithFlashlight")
        {
            Instruction.SetActive(true);
            Action = true;
            Debug.Log("poop");
            if (LightInstruction.activeInHierarchy == true)
            {
                LightInstruction.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        Instruction.SetActive(false);
        Action = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                Instruction.SetActive(false);
                AnimObject.SetBool("isOpen", true);
                ThisTrigger.enabled = false;
                //DoorOpenSound.Play();
                Action = false;
            }
        }

    }
}