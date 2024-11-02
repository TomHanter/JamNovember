using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatCell : MonoBehaviour
{
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

            default:
                HandleDefaultCollision(collision.gameObject);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "LavaCell":
                HealPlayer(other.gameObject);
                break;

            case "WaterCell":
                Die(other.gameObject);
                break;

            case "FireCell":
                //HealPlayer(collision.gameObject);
                break;

            case "GrassCell":
                TakeDamage(other.gameObject);
                break;

            case "BorderCell":
                StopPlayer(other.gameObject);
                break;

            default:
                HandleDefaultCollision(other.gameObject);
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
        // Логика для обработки усиления, например, увеличение силы или скорости
    }

    private void HandleDefaultCollision(GameObject other)
    {
        Debug.Log("Collision with undefind collider");
        // Логика для неизвестных объектов
    }
}
