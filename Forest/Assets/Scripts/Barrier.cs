using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Останавливаем игрока
            Rigidbody2D playerRigidbody = other.GetComponent<Rigidbody2D>();

            if (playerRigidbody != null)
            {
                playerRigidbody.velocity = Vector2.zero; // Останавливаем движение
                Debug.Log("Игрок достиг барьера и остановился.");
            }
        }
    }
}
