using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

public class WhatCell : MonoBehaviour
{
    [SerializeField] private TMP_Text _textHp;
    [SerializeField] private int _HpPlus = 5;
    [SerializeField] private int _hp = 3;
    private UIPanel _uiPanel;
    private HexogenChange _changeMesh;

    private void Awake()
    {
        _uiPanel = Camera.main.GetComponent<UIPanel>();
        _changeMesh = GetComponent<HexogenChange>();
        if (_changeMesh == null)
        {
            Debug.LogWarning("HexogenChange component not found on this object. Make sure to assign it.");
        }
    }
    private void Start()
    {
        _textHp.text = _hp.ToString();
    }

    void Update()
    {
        if (_hp <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "WaterCell":// смерть
                Die(collider.gameObject);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision");
        switch (collision.gameObject.tag)
        {
            case "LavaCell"://хп жизни
                collision.gameObject.tag = "FireCell";
                HealPlayer();
                break;

            case "FireCell":// изменяемый блок
                break;

            case "GrassCell":// нейтральный блок меняется на лава блок + получения урона
                TakeDamage();
                Debug.Log($"gameObject = {collision.gameObject}");
                _changeMesh.ReplaceObjectAtPosition(collision.gameObject);
                break;

            case "WinCell":
                WinPoint(collision.gameObject);
                break;

            case "LavaPlusHp":
                Destroy(collision.gameObject);
                break;

            default:
                HandleDefaultCollision(collision.gameObject);
                break;
        }
    }

    // Обработчик столкновения с врагом
    private void TakeDamage()
    {
        Debug.Log("damage received");
        _hp--;
        Debug.Log($"hp {_hp}");
        _textHp.text = _hp.ToString();
        // Здесь можно добавить логику для врага, например, уменьшение здоровья
    }

    // Обработчик столкновения с препятствием
    private void StopPlayer(GameObject obstacle)
    {
        Debug.Log("player stop");
        // Логика для обработки столкновения с препятствием
    }

    // Обработчик столкновения с усилением
    private void HealPlayer()
    {
        Debug.Log("hp heal");
        _hp += _HpPlus;
        _textHp.text = _hp.ToString();
        Debug.Log($"hp {_hp}");
        // Логика для обработки усиления, например, увеличение силы или скорости
    }

    // Обработчик столкновения с усилением
    private void Die(GameObject obj = null)
    {
        Debug.Log("player die");
        if (obj != null)
        {
            _uiPanel.Lose();
        }
        else
        {
            this.gameObject.SetActive(false);
            _uiPanel.Lose();
        }
        // Логика для обработки усиления, например, увеличение силы или скорости
    }

    private void WinPoint(GameObject powerUp)
    {
        Debug.Log("player win");
        _uiPanel.Win();
    }

    private void HandleDefaultCollision(GameObject other)
    {
        Debug.Log("Collision with undefind collider");
        // Логика для неизвестных объектов
    }
}
