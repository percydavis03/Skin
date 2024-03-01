using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    public GameObject theScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            theScreen.SetActive(true);
            
        }
        else if (other.gameObject.CompareTag("PlayerwithFlashlight"))
        {
            theScreen.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            theScreen.SetActive(false);

        }
        else if (other.gameObject.CompareTag("PlayerwithFlashlight"))
        {
            theScreen.SetActive(false);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
