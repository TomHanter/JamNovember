using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HexCoordinates : MonoBehaviour
{
    [Header("Offset coordinates")]
    [SerializeField] private Vector3Int _offsetCoordinates;

    public static float xOffset = 1f, yOffset = 1, zOffset = 0.75f;

    internal Vector3Int GetHexCoords()
        => _offsetCoordinates;

    private void Awake()
    {
        _offsetCoordinates = ConvertPositionToOffset(transform.position);
    }

    public static Vector3Int ConvertPositionToOffset(Vector3 position)
    {
        int x = Mathf.CeilToInt((float)Math.Round(position.x / xOffset, 3));
        int y = Mathf.RoundToInt(position.y / yOffset);
        int z = Mathf.RoundToInt(position.z / zOffset);
        return new Vector3Int(x, y, z);
    }
}
