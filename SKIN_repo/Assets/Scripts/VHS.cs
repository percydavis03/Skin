using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHS : MonoBehaviour
{
    public GameObject vhs;
    public GameObject screen;
    private bool hasTape;

    private void Awake()
    {
        hasTape = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("vhs"))
        {
            //vhs.SetActive(true);
            hasTape = true;
        }
        if (other.gameObject.CompareTag("tv") && hasTape == true)
        {
            screen.SetActive(true);
            hasTape = false;
        }
    }
}
