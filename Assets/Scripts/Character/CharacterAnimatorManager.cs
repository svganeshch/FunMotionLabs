using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterAnimatorManager : MonoBehaviour
{
    Character character;

    public DamageHandler[] damageHandlers;

    private int previousActionHash;

    private static readonly int attack1 = Animator.StringToHash("punch_body");

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
        previousActionHash = animationClipHash;

        character.animator.CrossFade(animationClipHash, character.animationFadeTime);

        character.applyRootMotion = applyRootMotion;
        character.canRotate = canRotate;
        character.canMove = canMove;
    }

    public void PlayAttackAnimation()
    {
        PlayCharacterActionAnimation(attack1);
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
}
