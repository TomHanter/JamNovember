using UnityEngine;

public class AnimationBlob : MonoBehaviour
{
    private Animator _animator;
    private Vector3 _bufferPosition;

    private void Start()
    {
        _bufferPosition = transform.position;
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (this.transform.position != _bufferPosition)
        {
            _animator.SetBool("isWalk", true);
            _bufferPosition = this.transform.position;
        }
        else
        {
            _animator.SetBool("isWalk", false);
        }
    }
}

