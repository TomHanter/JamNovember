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
                HealPlayer(collision.gameObject);
                break;

            case "WaterCell":// смерть
                Die();
                break;

            case "LavaCell":
                HealPlayer();
                break;

            case "FireCell":// изменяемый блок?
                //HealPlayer(collision.gameObject);
                break;

            case "GrassCell":// нейтральный блок меняется на лава блок + получения урона
                TakeDamage(collision.gameObject);
                _changeMesh.ChangerMeshGex();
                break;

            case "BorderCell"://????
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
    private void TakeDamage()
    {
        Debug.Log($"hp {hp}");
        Debug.Log("damage received");
        hp--;
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
        Debug.Log($"hp {hp}");
        Debug.Log("hp heal");
        hp += 3;
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
