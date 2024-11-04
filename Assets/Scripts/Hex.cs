using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Hex : MonoBehaviour
{
    [SerializeField] private GlowHighlight _highlight;
    private HexCoordinates _hexCoordinates;

    [SerializeField] private HexType _hexType;

    public Vector3Int HexCoords => _hexCoordinates.GetHexCoords();

    public int GetCost()
        => _hexType switch
        {
            HexType.Difficult => 100,
            HexType.Default => 1,
            HexType.Road => 1,
            _ => throw new Exception($"Hex of type {_hexType} not supported")
        };

    public bool IsObstacle()
    {
        return this._hexType == HexType.Obstacle;
    }

    private void Awake()
    {
        _hexCoordinates = GetComponent<HexCoordinates>();
        _highlight = GetComponent<GlowHighlight>();
    }
    public void EnableHighlight()
    {
        //_highlight.ToggleGlow(true);
    }

    public void DisableHighlight()
    {
        //_highlight.ToggleGlow(false);
    }

    internal void ResetHighlight()
    {
        //_highlight.ResetGlowHighlight();
    }

    internal void HighlightPath()
    {
        //_highlight.HighlightValidPath();
    }
}

public enum HexType
{
    None,
    Default,
    Difficult,
    Road,
    Water,
    Obstacle
}