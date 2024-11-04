using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _delay = 2f;
    public UnityEvent<Vector3> PointerClick;

    private bool _isClickable = true;

    void Update()
    {
        DetectMouseClick();
    }

    private void DetectMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && _isClickable)
        {
            StartCoroutine(UpdateClick());
            //Debug.Log("click");
            Vector3 mousePos = Input.mousePosition;
            PointerClick?.Invoke(mousePos);
        }
    }

    private IEnumerator UpdateClick()
    {
        _isClickable = false;
        yield return new WaitForSeconds(_delay);
        _isClickable = true;
        //StartCoroutine(DetectMouseClick(endPosition));
    }
}
