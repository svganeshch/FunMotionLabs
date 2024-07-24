using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : State
{
    public HitState(Character _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (character == null) Debug.Log("char is null");

        character.characterAnimatorManager.PlayHitAction();
    }
}
