using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterAnimatorManager : MonoBehaviour
{
    Character character;

    public DamageHandler[] damageHandlers;

    private int previousAttackActionHash;
    private int nextAttackActionHash;

    private int previousDodgeActionHash;
    private int nextDodgeActionHash;

    private static readonly int attack1 = Animator.StringToHash("punch_body");
    private static readonly int attack2 = Animator.StringToHash("punch_cross");
    private static readonly int attack3 = Animator.StringToHash("hook_body_short");

    private static readonly int dodge = Animator.StringToHash("dodge");
    private static readonly int block = Animator.StringToHash("block_F");

    private static readonly int hit_body = Animator.StringToHash("hit_body");

    protected virtual void Awake()
    {
        character = GetComponent<Character>();
        damageHandlers = GetComponentsInChildren<DamageHandler>();
    }

    public void SetAnimatorParameters(float horizontalInput, float verticalInput, bool applyRootMotion = false)
    {
        character.applyRootMotion = applyRootMotion;

        character.animator.SetFloat("SpeedX", horizontalInput, character.speedDampTime, Time.deltaTime);
        character.animator.SetFloat("SpeedY", verticalInput, character.speedDampTime, Time.deltaTime);
    }

    protected virtual void PlayCharacterActionAnimation(
        int animationClipHash,
        bool canRotate = false,
        bool canMove = false,
        bool applyRootMotion = true)
    {
        

        character.animator.CrossFade(animationClipHash, character.animationFadeTime);

        character.applyRootMotion = applyRootMotion;
        character.canRotate = canRotate;
        character.canMove = canMove;
    }

    public void PlayAttackAnimation(bool canCombo)
    {
        nextAttackActionHash = attack1;

        if (canCombo)
        {
            if (previousAttackActionHash == attack1)
                nextAttackActionHash = attack2;
            else if (previousAttackActionHash == attack2)
                nextAttackActionHash = attack3;
            else if (previousAttackActionHash == attack3)
                nextAttackActionHash = attack1;
        }
        previousAttackActionHash = nextAttackActionHash;

        PlayCharacterActionAnimation(nextAttackActionHash, true, true);
    }

    public void PlayDodgeAnimation()
    {
        nextDodgeActionHash = block;

        //if (previousDodgeActionHash == dodge)
        //    nextDodgeActionHash = block;
        //else if (previousDodgeActionHash == block)
        //    nextDodgeActionHash = dodge;

        //previousDodgeActionHash = nextDodgeActionHash;

        PlayCharacterActionAnimation(nextDodgeActionHash);
    }

    public void PlayHitAction()
    {
        PlayCharacterActionAnimation(hit_body);
    }

    // Animation events
    public void StartDamage()
    {
        foreach (var handler in damageHandlers)
        {
            handler.StartDamage();
        }
    }

    public void StopDamage()
    {
        foreach (var handler in damageHandlers)
        {
            handler.StopDamage();
        }
    }

    public void EnableCombo()
    {
        character.canCombo = true;
    }

    public void DisableCombo()
    {
        character.canCombo = false;
    }
}
