using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DeadZone : MonoBehaviour {
    
    //event to StatsManager
    public delegate void BabyHitDelegate();
    public event BabyHitDelegate OnBabyHitEvent;

    private void OnTriggerEnter2D(Collider2D other) {
        Baby baby = other.gameObject.GetComponent<Baby>();
        if (baby!=null) {
            Destroy(baby.gameObject);
            OnBabyHitEvent?.Invoke();
            AudioManager.GetInstance().PlayHitSfx();
        }
    }
}
