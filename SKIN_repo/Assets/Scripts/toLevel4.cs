using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class toLevel4 : MonoBehaviour
{
    public Image fadeImage;
    private bool pERMISSION;
    private bool isLevel1;

    private void Awake()
    {
        pERMISSION = true;

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeScreen());
        }

    }

    private IEnumerator FadeScreen()
    {
        float elasped = 0f;
        float duration = 1f;

        while (elasped < duration && pERMISSION == true)
        {
            float t = Mathf.Clamp01(elasped / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.black, t);
            //Time.timeScale = 1f - t;//Slow down time
            elasped += Time.unscaledDeltaTime;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        Invoke("Leave", 2);
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
        SceneManager.LoadScene("Level4", LoadSceneMode.Single);
    }
}
