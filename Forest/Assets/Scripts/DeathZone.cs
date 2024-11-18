using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, столкнулся ли персонаж
        if (other.CompareTag("Player"))
        {
            // Перезапускаем текущую сцену
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
