using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapClick : MonoBehaviour
{
    public Transform Player;

    void Start()
    {

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
                }
            }
        }
    }
}
