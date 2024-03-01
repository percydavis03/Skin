using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroythis : MonoBehaviour
{
    public GameObject thisthis;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           thisthis.SetActive(false);
        }
    }
}
