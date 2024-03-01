using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerout : MonoBehaviour
{
    public AudioSource off;
    public GameObject cage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            off.Play();
            cage.SetActive(true);
        }
    }
}
