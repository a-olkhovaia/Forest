using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 0.5f;       // �������� ����� ��������
    public float destroyDelay = 2f;       // ����� ������� ������ ��������� ��������� ����� �������

    private Rigidbody2D rb;
    private bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.bodyType = RigidbodyType2D.Kinematic;   // ������ ��������� Kinematic
        rb.gravityScale = 0;                       // ���������� ���������, ���� ��������� �� ������������
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
        rb.bodyType = RigidbodyType2D.Dynamic;  // ����������� ��������� �� Dynamic, ����� �������� ������
        rb.gravityScale = 1;                    // �������� ����������, ����� ��������� ������ ����
        Destroy(gameObject, destroyDelay);      // ���������� ��������� ����� destroyDelay ������
    }
}
