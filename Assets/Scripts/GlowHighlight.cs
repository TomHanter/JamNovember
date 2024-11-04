using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowHighlight : MonoBehaviour
{
    Dictionary<Renderer, Material[]> glowMaterialDictionary = new Dictionary<Renderer, Material[]>();
    Dictionary<Renderer, Material[]> originalMaterialDictionary = new Dictionary<Renderer, Material[]>();

    Dictionary<Color, Material> cachedGlowMaterials = new Dictionary<Color, Material>();

    private Material _glowMaterial;

    private bool _isGlowing = false;

    private Color _validSpaceColor = Color.green;
    private Color _originalGlowColor;

    private void Awake()
    {
        PrepareMaterialDictionaries();
        _originalGlowColor = _glowMaterial.GetColor("_GlowColor");
    }

    private void PrepareMaterialDictionaries()
    {
        foreach (Renderer renderer in GetComponentsInChildren<Renderer>())
        {
            Material[] originalMaterials = renderer.materials;
            originalMaterialDictionary.Add(renderer, originalMaterials);

            Material[] newMaterials = new Material[renderer.materials.Length];

            for (int i = 0; i < originalMaterials.Length; i++)
            {
                Material mat = null;
                if (cachedGlowMaterials.TryGetValue(originalMaterials[i].color, out mat) == false)
                {
                    mat = new Material(_glowMaterial);
                    //By default, Unity considers a color with the property name name "_Color" to be the main color
                    mat.color = originalMaterials[i].color;
                    cachedGlowMaterials[mat.color] = mat;
                }
                newMaterials[i] = mat;
            }
            glowMaterialDictionary.Add(renderer, newMaterials);
        }
    }

    internal void HighlightValidPath()
    {
        if (_isGlowing == false)
            return;
        foreach (Renderer renderer in glowMaterialDictionary.Keys)
        {
            foreach (Material item in glowMaterialDictionary[renderer])
            {
                item.SetColor("_GlowColor", _validSpaceColor);
            }
        }
    }

    internal void ResetGlowHighlight()
    {
        foreach (Renderer renderer in glowMaterialDictionary.Keys)
        {
            foreach (Material item in glowMaterialDictionary[renderer])
            {
                item.SetColor("_GlowColor", _originalGlowColor);
            }
        }
    }

    public void ToggleGlow()
    {
        if (_isGlowing == false)
        {
            ResetGlowHighlight();
            foreach (Renderer renderer in originalMaterialDictionary.Keys)
            {
                renderer.materials = glowMaterialDictionary[renderer];
            }
        }
        else
        {
            foreach (Renderer renderer in originalMaterialDictionary.Keys)
            {
                renderer.materials = originalMaterialDictionary[renderer];
            }
        }
        _isGlowing = !_isGlowing;
    }

    public void ToggleGlow(bool state)
    {
        if (_isGlowing == state)
            return;
        _isGlowing = !state;
        ToggleGlow();
    }
}
