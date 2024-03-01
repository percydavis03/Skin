using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    public int hitpoints;

    private void Start()
    {
        hitpoints = Unkillable.Instance.hp;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("freak"))
        {
            Hit.OnHit(this);

            hitpoints--;
            print("awowow");
        }
    }
    
}
