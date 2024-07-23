using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetActionFlags : StateMachineBehaviour
{
    Character character;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (character == null)
        {
            character = animator.GetComponent<Character>();
        }

        character.canMove = true;
        character.canRotate = true;
        character.applyRootMotion = false;

        character.characterStateMachine.ChangeState(character.idleState);
    }
}
