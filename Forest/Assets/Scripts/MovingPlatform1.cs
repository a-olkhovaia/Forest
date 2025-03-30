using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform1 : MonoBehaviour
{
    // ���������, ������� ����� ��������� ����� Unity Inspector
    public float minSpeed = 1f; // ����������� �������� �������� ���������
    public float maxSpeed = 5f; // ������������ �������� �������� ���������
    public float width = 5f; // ������ �������� ��������� (������������ ����������)

    private Vector3 startPos; // ��������� ������� ���������
    private float speed; // �������� ���������
    private bool moveRight; // ����������� �������� ��������� (������ ��� �����)

    void Start()
    {
        // ������������� ��������� �������
        startPos = transform.position;

        // ����������� ��������� �������� � �������� ���������
        speed = Random.Range(minSpeed, maxSpeed);

        // ��������� ������� �������� ����������� ��������
        moveRight = Random.value > 0.5f;

        // ������� ��������� � ������� ��� ��������
        Debug.Log($"��������� {gameObject.name} ������ �������� � ��������� {speed} � ����������� {(moveRight ? "������" : "�����")}.");
    }

    void Update()
    {
        // ������� ��������� � ��������� ����������� � � ������ ���������
        if (moveRight)
        {
            transform.position = startPos + new Vector3(Mathf.PingPong(Time.time * speed, width) - width / 2, 0, 0);
        }
        else
        {
            transform.position = startPos - new Vector3(Mathf.PingPong(Time.time * speed, width) - width / 2, 0, 0);
        }
    }
}
