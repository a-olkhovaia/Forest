using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float boostedJumpForce = 15f;  // ���� ������, ����� �������� �� ������
    private float normalJumpForce;        // ������� ���� ������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PF player = other.GetComponent<PF>();

            if (player != null)
            {
                normalJumpForce = player.jumpHeight;  // ��������� ������� ���� ������
                player.jumpHeight = boostedJumpForce; // ������������� ��������� ���� ������
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
                player.jumpHeight = normalJumpForce; // ���������� ������� ���� ������
            }
        }
    }
}
