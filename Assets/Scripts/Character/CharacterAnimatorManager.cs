using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterAnimatorManager : MonoBehaviour
{
    Character character;

    public static readonly int walkF_hash = Animator.StringToHash("walking_F");

    protected virtual void Awake()
    {
        character = GetComponent<Character>();
    }

    public void SetAnimatorParameters(float horizontalInput, float verticalInput, bool applyRootMotion = false)
    {
        if (character.applyRootMotion) character.animator.applyRootMotion = applyRootMotion;

        character.animator.SetFloat("SpeedX", horizontalInput, character.speedDampTime, Time.deltaTime);
        character.animator.SetFloat("SpeedY", verticalInput, character.speedDampTime, Time.deltaTime);
    }
}
