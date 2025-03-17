using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float boostedJumpForce = 15f;  // Сила прыжка, когда персонаж на кнопке
    private float normalJumpForce;        // Обычная сила прыжка

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PF player = other.GetComponent<PF>();

            if (player != null)
            {
                normalJumpForce = player.jumpHeight;  // Сохраняем обычную силу прыжка
                player.jumpHeight = boostedJumpForce; // Устанавливаем усиленную силу прыжка
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PF player = other.GetComponent<PF>();

            if (player != null)
            {
                player.jumpHeight = normalJumpForce; // Возвращаем обычную силу прыжка
            }
        }
    }
}
