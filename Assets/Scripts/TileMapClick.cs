using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapClick : MonoBehaviour
{
    public Transform Player;

    private Tilemap map;
    private Vector3 targetPosition;
    private Camera mainCamera;

    void Start()
    {
        map = GetComponent<Tilemap>();
        mainCamera = Camera.main;
        targetPosition = transform.position;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.z));

            Vector3Int clickCellPosition = map.WorldToCell(clickWorldPosition);


            targetPosition = map.CellToWorld(clickCellPosition);
            targetPosition.y = transform.position.y;

            Debug.Log(clickCellPosition);
        }
    }
}
