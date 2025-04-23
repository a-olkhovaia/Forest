using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 3f; // �������� ��������
    public float height = 2f; // ������ �������

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // ���������� ��������� �������
    }

    void Update()
    {
        // ������� ��������� �����-����
        transform.position = startPos + new Vector3(0, Mathf.PingPong(Time.time * speed, height) - height / 2, 0);
    }
}
