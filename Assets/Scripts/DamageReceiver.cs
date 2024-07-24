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

        if (1 << collidedWith.gameObject.layer == character.playerLayerMask ||
            1 << collidedWith.gameObject.layer == character.enemyLayerMask)
        {
            Character damagedCharacter = collidedWith.GetComponent<Character>();
            damagedCharacter.characterStateMachine.ChangeState(damagedCharacter.hitState);
            Debug.Log(character.gameObject + " damaged : " + collidedWith);
        }
    }
}
