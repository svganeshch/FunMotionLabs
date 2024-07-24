using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void OnTriggerEnter(Collider collidedWith)
    {
        if (collidedWith == null) return;

        
        character.characterStateMachine.ChangeState(character.hitState);
        Debug.Log("damaged from : " + collidedWith);
    }
}
