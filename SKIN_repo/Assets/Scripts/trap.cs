using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trap : MonoBehaviour
{
    public GameObject lockedin;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            lockedin.SetActive(true);
        }

       
    }
}
