using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MonsterCollision : MonoBehaviour
{
    // Функция, вызываемая при столкновении с другими коллайдерами
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверка, что столкновение произошло с персонажем
        if (collision.gameObject.CompareTag("Player")) 
        {
            // Перезагружаем текущую сцену
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
