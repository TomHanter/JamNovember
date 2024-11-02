using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WhatCell : MonoBehaviour
{
    private UIPanel _uiPanel;

    private void Awake()
    {
        _uiPanel = Camera.main.GetComponent<UIPanel>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "LavaCell":
                HealPlayer(collision.gameObject);
                break;

            case "WaterCell":
                Die(collision.gameObject);
                break;

            case "FireCell":
                //HealPlayer(collision.gameObject);
                break;

            case "GrassCell":
                TakeDamage(collision.gameObject);
                break;

            case "BorderCell":
                StopPlayer(collision.gameObject);
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
    private void TakeDamage(GameObject enemy)
    {
        Debug.Log("damage received");
        // Здесь можно добавить логику для врага, например, уменьшение здоровья
    }

    // Обработчик столкновения с препятствием
    private void StopPlayer(GameObject obstacle)
    {
        Debug.Log("player stop");
        // Логика для обработки столкновения с препятствием
    }

    // Обработчик столкновения с усилением
    private void HealPlayer(GameObject powerUp)
    {
        Debug.Log("hp heal");
        // Логика для обработки усиления, например, увеличение силы или скорости
    }

    // Обработчик столкновения с усилением
    private void Die(GameObject powerUp)
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
