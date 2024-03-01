using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorBat : MonoBehaviour
{
    public GameObject thisBat;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Destroy(thisBat);
        }
    }
}
