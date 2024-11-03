using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCell : MonoBehaviour
{
    private TileMapClick tileMapClick;

    void OnEnable()
    {
        // Find and subscribe to the OnPlayerMoved event
        tileMapClick = FindObjectOfType<TileMapClick>();
        if (tileMapClick != null)
        {
            tileMapClick.OnPlayerMoved += HandlePlayerMoved;
        }
        else
        {
            Debug.LogWarning("TileMapClick component not found in the scene.");
        }
    }

    void OnDisable()
    {
        // Unsubscribe from the OnPlayerMoved event
        if (tileMapClick != null)
        {
            tileMapClick.OnPlayerMoved -= HandlePlayerMoved;
        }
    }

    private void HandlePlayerMoved(Vector3 newPosition)
    {
        // Output information to the console
        Debug.Log("Player is moving to position: " + newPosition);
    }
}
