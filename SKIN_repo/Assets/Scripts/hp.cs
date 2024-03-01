using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Pool;


public class hp : MonoBehaviour
{
    //public TextMeshProUGUI health_counter;
    private int healthpoints;
    private bool hittable;
    public AudioSource veins;

    private void Start()
    {
        hittable = false;
        
    }
    private void Awake()
    {
        healthpoints = 3;
        hittable = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (hittable == false)
            {
                veins.Play();   
                hittable = true;
            }
            healthpoints--;
        }
    }
    private void Update()
    {
        if (hittable == true)
        {
            Invoke("Restart", 1);
        }
        if (healthpoints == 0)
        {
            //Restart();
        }
        
    }

    private void Restart()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    private void SeriousRestart()
    {
        SceneManager.LoadScene("Tutorial_", LoadSceneMode.Single);
    }
}
