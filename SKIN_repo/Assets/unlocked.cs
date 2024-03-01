using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlocked : MonoBehaviour
{
    public GameObject door;

    void Awake()
    {
        door.SetActive(false);
    }
}
