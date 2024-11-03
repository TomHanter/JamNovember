using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    [SerializeField] private AudioSource _myFx;
    [SerializeField] private AudioClip _clickButtonFx;
    [SerializeField] private AudioClip _pressMouseFx;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickMousePlase();
        }
    }
    public void ClickMousePlase()
    {
        _myFx.PlayOneShot(_pressMouseFx);
    }

    public void ClickSound()
    {
        _myFx.PlayOneShot(_clickButtonFx);
    }
}
