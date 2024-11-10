using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
// using static UnityEditor.Experimental.GraphView.GraphView;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private GameObject _unit;

    public LayerMask SelectionMask;
    public HexGrid HexGrid;

    public UnityEvent<GameObject> OnUnitSelected;
    public UnityEvent<GameObject> TerrainSelected;

    List<Vector3Int> neighbors = new List<Vector3Int>();

    private void Awake()
    {
        if (_mainCamera == null)
            _mainCamera = Camera.main;
    }

    public void HandleClick(Vector3 mousePosition)
    {
        GameObject result;
        if (FindTarget(mousePosition, out result))
        {
            OnUnitSelected?.Invoke(_unit);

            TerrainSelected?.Invoke(result);
            //_animator.SetBool("isWalk", true);
            //Debug.Log("tile");
            //if (UnitSelected(result))
            //{
            //    Debug.Log("unit");
            //    OnUnitSelected?.Invoke(result);
            //}
            //else
            //{
            //}
            HexGrid.FindAllHex();
        }
    }

    private bool UnitSelected(GameObject result)
    {
        return result.GetComponent<Unit>() != null;

    }

    private bool FindTarget(Vector3 mousePosition, out GameObject result)
    {
        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out hit, 100, SelectionMask))
        {
            result = hit.collider.gameObject;
            return true;
        }
        result = null;
        return false;
    }
}