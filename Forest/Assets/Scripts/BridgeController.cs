using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public GameObject bridge;         // ����, ������� �����������
    public float extendSpeed = 2f;     // �������� ����������
    public float bridgeLength = 5f;    // �����, �� ������� ���� �����������

    private Vector3 initialPosition;   // ��������� ������� �����
    private Vector3 targetPosition;    // �������, �� ������� ���� ������ �����������
    private bool isExtending = false;  // ���� ��� ���������� �����
    private bool isRetracting = false; // ���� ��� ���������� �����

    void Start()
    {
        initialPosition = bridge.transform.position;
        targetPosition = initialPosition + Vector3.right * bridgeLength;
        bridge.SetActive(true);  // ��������, ��� ���� �����
    }

    void Update()
    {
        if (isExtending)
        {
            bridge.transform.position = Vector3.MoveTowards(bridge.transform.position, targetPosition, extendSpeed * Time.deltaTime);

            if (bridge.transform.position == targetPosition)
            {
                isExtending = false;
            }
        }

        if (isRetracting)
        {
            bridge.transform.position = Vector3.MoveTowards(bridge.transform.position, initialPosition, extendSpeed * Time.deltaTime);

            if (bridge.transform.position == initialPosition)
            {
                isRetracting = false;
            }
        }
    }

    public void StartExtending()
    {
        isExtending = true;
        isRetracting = false;
    }

    public void StartRetracting()
    {
        isRetracting = true;
        isExtending = false;
    }
}