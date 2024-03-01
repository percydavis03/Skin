
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;



public class Scenechange : MonoBehaviour
{
    public Image fadeImage;
    private bool pERMISSION;
    private bool isLevel1;

    private void Awake()
    {
        pERMISSION = true;
        isLevel1 = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player" ))
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
        if (other.gameObject.CompareTag("PlayerwithFlashlight"))
        {
           StartCoroutine(FadeScreen());
        }
        if (other.gameObject.CompareTag("lvl1"))
        {
            isLevel1 |= true;
        }
    }

    private IEnumerator FadeScreen()
    {
        float elasped = 0f;
        float duration = 0.5f;

        while (elasped < duration && pERMISSION == true)
        {
            float t = Mathf.Clamp01(elasped / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.black, t);
            Time.timeScale = 1f - t;//Slow down time
            elasped += Time.unscaledDeltaTime;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        Leave();
        elasped = 0f;

        while (elasped < duration && pERMISSION == true)
        {
            float t = Mathf.Clamp01(elasped / duration);
            fadeImage.color = Color.Lerp(Color.black, Color.clear, t);
            elasped += Time.unscaledDeltaTime;
            yield return null;
            Time.timeScale = 1f;
            pERMISSION = false;
        }
    }

    private void Leave()
    {
        if (isLevel1 == false)
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
        else if (isLevel1 == true)
        {
            SceneManager.LoadScene("Level2", LoadSceneMode.Single);
        }
        
    }
}
