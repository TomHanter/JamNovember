using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexogenChange : MonoBehaviour
{
    [SerializeField] private MeshFilter _modelToChangeGrass;//grass
    [SerializeField] private Mesh _modelToUseChangeFire;//lava or fire


    public void ChangerMeshGex()
    {
        _modelToChangeGrass.mesh = _modelToUseChangeFire;
        gameObject.tag = "FireCell";
    }
}
