using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeypadPassword : MonoBehaviour
{
    [SerializeField] private TMP_Text ans;

    public GameObject player;
    public GameObject keypadObject;

    //public TextMeshPro textObject;
    public string correctanswer = "162";

    public AudioSource button;
    public AudioSource wrong;
    public AudioSource correct;


    public void NumberPressed( int number)
    {
        ans.text = number.ToString();
        //button.Play();
    }

   public void EnterCode()
    {
        if (ans.text == correctanswer)
        {
            correct.Play();
            ans.text = "Acess Granted";
        }

        else
        {
            wrong.Play();
            ans.text = "Access Denied";
        }
    }

    public void Clear()
    {
        ans.text = "";
        button.Play();
    }

    public void ExitKeypad()
    {
        keypadObject.SetActive(false);
        
        //find a way to disable movement
    }
   
    void Update()
    {
        if (ans.text == "correct")
        {
            print("correct");
        }

        if (keypadObject.activeInHierarchy)
        {
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
