using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    Collider attackCollider;

    private void Awake()
    {
        attackCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider collidedWith)
    {
        if (collidedWith == null) return;
        
        Debug.Log("collided with " + collidedWith);
    }

    public void StartDamage()
    {
        attackCollider.enabled = true;
    }

    public void StopDamage()
    {
        attackCollider.enabled = false;
    }
}
