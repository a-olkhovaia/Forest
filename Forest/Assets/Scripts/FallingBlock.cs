using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    private Rigidbody2D rb;  // Ссылка на Rigidbody2D блока
    private bool isFalling = false; // Статус падения

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static; // Изначально блок не двигается
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверяем, касается ли блока персонаж
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            isFalling = true;
            rb.bodyType = RigidbodyType2D.Dynamic; // Разрешаем блоку упасть
            rb.AddForce(new Vector2(Random.Range(-1f, 1f), 0f) * 10f, ForceMode2D.Impulse); // Добавляем случайное отклонение
        }
    }
}
