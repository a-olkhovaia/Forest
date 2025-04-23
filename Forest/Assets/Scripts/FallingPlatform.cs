using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 0.5f;       // Задержка перед падением
    public float destroyDelay = 2f;       // Через сколько секунд платформа удаляется после падения

    private Rigidbody2D rb;
    private bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Kinematic;   // Делаем платформу Kinematic
        rb.gravityScale = 0;                       // Гравитация отключена, пока платформа не активируется
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && !isFalling)
        {
            isFalling = true;
            Invoke("StartFalling", fallDelay);
        }
    }

    void StartFalling()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;  // Переключаем платформу на Dynamic, чтобы включить физику
        rb.gravityScale = 1;                    // Включаем гравитацию, чтобы платформа падала вниз
        Destroy(gameObject, destroyDelay);      // Уничтожаем платформу через destroyDelay секунд
    }
}
