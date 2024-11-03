
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapClick : MonoBehaviour
{
    [SerializeField] private Transform _player;
    public delegate void PlayerMovedEventHandler(Vector3 newPosition);
    public event PlayerMovedEventHandler OnPlayerMoved;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var gameObject = hit.collider.gameObject;
                var rb = gameObject.GetComponent<Rigidbody>();

                Collider collider = rb.GetComponent<Collider>();
                if (rb != null && gameObject.tag != "BorderCell")
                {
                    Vector3 center = collider.bounds.center;
                    center.y += 0.3f;
                    _player.transform.position = center;
                    OnPlayerMoved?.Invoke(center);
                }
            }
        }
    }
}

