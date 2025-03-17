using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public GameObject bridge;         // Мост, который выдвигается
    public float extendSpeed = 2f;     // Скорость выдвижения
    public float bridgeLength = 5f;    // Длина, на которую мост выдвигается

    private Vector3 initialPosition;   // Начальная позиция моста
    private Vector3 targetPosition;    // Позиция, до которой мост должен выдвигаться
    private bool isExtending = false;  // Флаг для выдвижения моста
    private bool isRetracting = false; // Флаг для задвигания моста

    void Start()
    {
        initialPosition = bridge.transform.position;
        targetPosition = initialPosition + Vector3.right * bridgeLength;
        bridge.SetActive(true);  // Убедимся, что мост видим
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