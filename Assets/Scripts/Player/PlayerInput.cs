using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private UnitManager _unitManager;
    public UnityEvent<Vector3> PointerClick;

    private bool _isClickable = true;

    void Update()
    {
        DetectMouseClick();
    }

    private void DetectMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && _unitManager.PlayersTurn)
        {
            Vector3 mousePos = Input.mousePosition;
            PointerClick?.Invoke(mousePos);
        }
    }

}
