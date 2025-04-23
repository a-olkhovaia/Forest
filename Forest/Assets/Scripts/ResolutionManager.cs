using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    // Ссылки на кнопки
    public Button resolution1080pButton;
    public Button resolution720pButton;
    public Button resolution480pButton;

    // Разрешения экрана
    private void Start()
    {
        // Добавляем обработчики событий для кнопок
        resolution1080pButton.onClick.AddListener(() => SetResolution(1920, 1080));
        resolution720pButton.onClick.AddListener(() => SetResolution(1280, 720));
        resolution480pButton.onClick.AddListener(() => SetResolution(640, 480));
    }

    // Метод для изменения разрешения
    private void SetResolution(int width, int height)
    {
        Debug.Log($"Изменение разрешения на {width}x{height}");
        Screen.SetResolution(width, height, true);
    }
}
