using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimGif : MonoBehaviour
{
    [SerializeField]private Texture2D[] _frame;
    private float _framePerSecond = 2f;

    private RawImage image = null;
    private Renderer render = null;

    void Awake()
    {
        image = GetComponent<RawImage>();
        render = GetComponent<Renderer>();
    }

    void Update()
    {
        float index = Time.time * _framePerSecond;
        index = index % _frame.Length;

        if (render != null)
        {
            render.material.mainTexture = _frame[(int)index];
        }
        else
        {
            image.texture = _frame[(int)index];
        }
    }
}
