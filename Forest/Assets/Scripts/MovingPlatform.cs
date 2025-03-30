using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 3f; // Скорость движения
    public float height = 2f; // Высота подъёма

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // Запоминаем стартовую позицию
    }

    void Update()
    {
        // Двигаем платформу вверх-вниз
        transform.position = startPos + new Vector3(0, Mathf.PingPong(Time.time * speed, height) - height / 2, 0);
    }
}
