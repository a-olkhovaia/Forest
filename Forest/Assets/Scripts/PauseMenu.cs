using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;  // ������ � �������� �����
    private bool isPaused = false;  // ������ ���� (����� ��� ���)

    void Start()
    {
        // ������ ������ ����� ��� ������� ���� � ������� ���������� �����
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;  // ���������, ��� ���� �� �� ����� ��� ������
    }

    void Update()
    {
        // �������� ������� ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();  // ���� ���� �� �����, ���������� ����
            }
            else
            {
                Pause();  // ���� ���� �� �� �����, ������ �� �����
            }
        }
    }

    // �������� ���� �����
    void Pause()
    {
        pauseMenuUI.SetActive(true);  // ���������� ������ �����
        Time.timeScale = 0f;          // ������������� ������� �������
        isPaused = true;
    }

    // ���������� ���� � ���������� �����
    void Resume()
    {
        pauseMenuUI.SetActive(false);  // ��������� ������ �����
        Time.timeScale = 1f;           // ���������� ������� �������� ����
        isPaused = false;
    }

    // ������� ��� ������ � ������� ����
    public void LoadMainMenu()
    {
        // �������������� ������� ��� �������� � ����
        Time.timeScale = 1f; // ���������, ��� ����� �� ����������� ��� ������ � ����
        SceneManager.LoadScene("MainMenu");  // �������� ����� �������� ����
    }

    // ������� ��� �������� ������ ������
    public void LoadLevel(string levelName)
    {
        // �������������� ������� ��� �������� ������
        Time.timeScale = 1f;  // ���������, ��� ���� ���������� ��������
        SceneManager.LoadScene(levelName);  // �������� ���������� ������
    }
}
