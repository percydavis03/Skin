using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlightscript : MonoBehaviour
{
    public GameObject thislight;
    public GameObject Instruction;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            thislight.SetActive(false);
            Instruction.SetActive(true);
            Invoke("Pancake", 5);
        }
    }
    

    private void Pancake()
    {
        Instruction.SetActive(false);
    }
}
