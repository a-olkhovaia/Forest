using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Если звезда касается игрока
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Игрок погиб! Перезапуск уровня...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезапуск сцены
    }
}
