using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBlob : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool("isWalk", true);
    }
}
