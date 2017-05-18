using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[AddComponentMenu("Scripts/Player/PlayerAnimations")]
public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public bool GetAnimRunning()
    {
        return _animator.GetBool("IsRunning");
    }

    public void SetAnimRunning(bool _state)
    {
        _animator.SetBool("IsRunning", _state);
    }

}
