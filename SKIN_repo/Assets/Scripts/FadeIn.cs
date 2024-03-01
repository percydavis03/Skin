using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeIn : MonoBehaviour
{
    public Image fadeImage;

    private void Awake()
    {
        StartCoroutine(FadeScreen());
        print("fadeImage");
    }
    private IEnumerator FadeScreen()
    {
        float elasped = 0f;
        float duration = 2f;

        while (elasped < duration)
        {
            elasped += Time.deltaTime / duration;
            fadeImage.color = Color.Lerp(Color.black, Color.clear, elasped / duration);
            yield return null;
        }
    }
}
