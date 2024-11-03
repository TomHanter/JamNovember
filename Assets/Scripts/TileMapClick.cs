using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapClick : MonoBehaviour
{
    Tilemap TileMap;

    [SerializeField]private Transform Player;
    [SerializeField]private Transform Hex1;
    [SerializeField]private Transform Hex2;

    float allowedDistance;

    public delegate void PlayerMovedEventHandler(Vector3 newPosition);
    public event PlayerMovedEventHandler OnPlayerMoved;

    void Start()
    {
        //allowedDistance = (Hex1.transform.position - Hex2.position).magnitude;
        //TileMap();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                var gameObject = hit.collider.gameObject;

                var rb = gameObject.GetComponent<Rigidbody>();
                Collider collider = rb.GetComponent<Collider>();
                if(rb != null)
                {
                    Vector3 center = collider.bounds.center;
                    center.y += 0.3f;
                    Player.transform.position = center;
                    OnPlayerMoved?.Invoke(center);
                }
            }
        }
    }
}