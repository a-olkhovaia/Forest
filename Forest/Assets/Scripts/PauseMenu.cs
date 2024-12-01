using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;  // Панель с кнопками паузы
    private bool isPaused = false;  // Статус игры (пауза или нет)

    void Start()
    {
        // Скрыть панель паузы при запуске игры и вернуть нормальное время
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;  // Убедитесь, что игра не на паузе при старте
    }

    void Update()
    {
        // Проверка нажатия ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();  // Если игра на паузе, продолжаем игру
            }
            else
            {
                Pause();  // Если игра не на паузе, ставим на паузу
            }
        }
    }

    // Включаем меню паузы
    void Pause()
    {
        pauseMenuUI.SetActive(true);  // Активируем панель паузы
        Time.timeScale = 0f;          // Останавливаем игровой процесс
        isPaused = true;
    }

    // Возвращаем игру в нормальный режим
    void Resume()
    {
        pauseMenuUI.SetActive(false);  // Отключаем панель паузы
        Time.timeScale = 1f;           // Возвращаем обычную скорость игры
        isPaused = false;
    }

    // Функция для выхода в главное меню
    public void LoadMainMenu()
    {
        // Восстановление времени при переходе в меню
        Time.timeScale = 1f; // Убедитесь, что время не остановлено при выходе в меню
        SceneManager.LoadScene("MainMenu");  // Загрузка сцены главного меню
    }

    // Функция для загрузки нового уровня
    public void LoadLevel(string levelName)
    {
        // Восстановление времени при загрузке уровня
        Time.timeScale = 1f;  // Убедитесь, что игра продолжает работать
        SceneManager.LoadScene(levelName);  // Загрузка выбранного уровня
    }
}
