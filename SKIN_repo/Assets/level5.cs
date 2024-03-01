using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level5 : MonoBehaviour
{
    public AudioSource squish;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            squish.Play();
            Invoke("asds", 2);
        }
    }
    private void asds()
    {
        SceneManager.LoadScene("Level5", LoadSceneMode.Single);
    }
}
