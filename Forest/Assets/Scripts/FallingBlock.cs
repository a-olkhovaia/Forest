using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    private Rigidbody2D rb;  // ������ �� Rigidbody2D �����
    private bool isFalling = false; // ������ �������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static; // ���������� ���� �� ���������
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���������, �������� �� ����� ��������
        if (collision.gameObject.CompareTag("Player") && !isFalling)
        {
            isFalling = true;
            rb.bodyType = RigidbodyType2D.Dynamic; // ��������� ����� ������
            rb.AddForce(new Vector2(Random.Range(-1f, 1f), 0f) * 10f, ForceMode2D.Impulse); // ��������� ��������� ����������
        }
    }
}
