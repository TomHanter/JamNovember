using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private HexGrid _hexGrid;
    [SerializeField] private MovementSystem _movementSystem;
    [SerializeField] private Unit _selectedUnit;
    private Hex _previouslySelectedHex;

    public bool PlayersTurn { get; private set; } = true;

    public void HandleUnitSelected(GameObject unit)
    {
        if (PlayersTurn == false)
            return;

        Unit unitReference = unit.GetComponent<Unit>();

        if (CheckIfTheSameUnitSelected(unitReference))
            return;

        PrepareUnitForMovement(unitReference);
    }

    private bool CheckIfTheSameUnitSelected(Unit unitReference)
    {
        if (this._selectedUnit == unitReference)
        {
            ClearOldSelection();
            return true;
        }
        return false;
    }

    public void HandleTerrainSelected(GameObject hexGO)
    {
        if (_selectedUnit == null || PlayersTurn == false)
        {
            return;
        }

        Hex selectedHex = hexGO.GetComponent<Hex>();

        if (HandleHexOutOfRange(selectedHex.HexCoords) || HandleSelectedHexIsUnitHex(selectedHex.HexCoords))
            return;
        HandleTargetHexSelected(selectedHex);
    }

    private void PrepareUnitForMovement(Unit unitReference)
    {
        if (this._selectedUnit != null)
        {
            ClearOldSelection();
        }

        this._selectedUnit = unitReference;
        this._selectedUnit.Select();
        _movementSystem.ShowRange(this._selectedUnit, this._hexGrid);
    }

    private void ClearOldSelection()
    {
        _previouslySelectedHex = null;
        this._selectedUnit.Deselect();
        _movementSystem.HideRange(this._hexGrid);
        this._selectedUnit = null;

    }

    private void HandleTargetHexSelected(Hex selectedHex)
    {
        if (_previouslySelectedHex == null || _previouslySelectedHex != selectedHex)
        {
            _previouslySelectedHex = selectedHex;
            _movementSystem.ShowPath(selectedHex.HexCoords, this._hexGrid);
        }
        else
        {
            _movementSystem.MoveUnit(_selectedUnit, this._hexGrid);
            PlayersTurn = false;
            _selectedUnit.MovementFinished += ResetTurn;
            ClearOldSelection();

        }
    }

    private bool HandleSelectedHexIsUnitHex(Vector3Int hexPosition)
    {
        if (hexPosition == _hexGrid.GetClosestHex(_selectedUnit.transform.position))
        {
            _selectedUnit.Deselect();
            ClearOldSelection();
            return true;
        }
        return false;
    }

    private bool HandleHexOutOfRange(Vector3Int hexPosition)
    {
        if (_movementSystem.IsHexInRange(hexPosition) == false)
        {
            Debug.Log("Hex Out of range!");
            return true;
        }
        return false;
    }

    private void ResetTurn(Unit selectedUnit)
    {
        selectedUnit.MovementFinished -= ResetTurn;
        PlayersTurn = true;
    }
}
