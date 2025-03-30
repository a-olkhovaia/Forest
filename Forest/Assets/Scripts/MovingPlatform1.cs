using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform1 : MonoBehaviour
{
    // Параметры, которые можно настроить через Unity Inspector
    public float minSpeed = 1f; // Минимальная скорость движения платформы
    public float maxSpeed = 5f; // Максимальная скорость движения платформы
    public float width = 5f; // Ширина движения платформы (максимальное расстояние)

    private Vector3 startPos; // Начальная позиция платформы
    private float speed; // Скорость платформы
    private bool moveRight; // Направление движения платформы (вправо или влево)

    void Start()
    {
        // Устанавливаем начальную позицию
        startPos = transform.position;

        // Присваиваем случайную скорость в пределах диапазона
        speed = Random.Range(minSpeed, maxSpeed);

        // Случайным образом выбираем направление движения
        moveRight = Random.value > 0.5f;

        // Выводим сообщение в консоль для проверки
        Debug.Log($"Платформа {gameObject.name} начнет движение с скоростью {speed} в направлении {(moveRight ? "вправо" : "влево")}.");
    }

    void Update()
    {
        // Двигаем платформу в случайном направлении и с разной скоростью
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
