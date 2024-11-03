using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WhatCell : MonoBehaviour
{
    private UIPanel _uiPanel;
    private HexogenChange _changeMesh;
    private int hp = 3;

    private void Awake()
    {
        _uiPanel = Camera.main.GetComponent<UIPanel>();
        _changeMesh = GetComponent<HexogenChange>();
        if (_changeMesh == null)
        {
            Debug.LogWarning("HexogenChange component not found on this object. Make sure to assign it.");
        }
    }

    void Update()
    {
        if (hp <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision");
        switch (collision.gameObject.tag)
        {
            case "LavaCell"://хп жизни?
                collision.gameObject.tag = "FireCell";
                HealPlayer();
                break;

            case "WaterCell":// смерть
                Die();
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

            default:
                HandleDefaultCollision(collision.gameObject);
                break;
        }
    }

    // Обработчик столкновения с врагом
    private void TakeDamage()
    {
        Debug.Log("damage received");
        hp--;
        Debug.Log($"hp {hp}");
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
        hp += 3;
        Debug.Log($"hp {hp}");
        // Логика для обработки усиления, например, увеличение силы или скорости
    }

    // Обработчик столкновения с усилением
    private void Die()
    {
        Debug.Log("player die");
        _uiPanel.Lose();
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
