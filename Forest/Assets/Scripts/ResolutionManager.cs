using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    // ������ �� ������
    public Button resolution1080pButton;
    public Button resolution720pButton;
    public Button resolution480pButton;

    // ���������� ������
    private void Start()
    {
        // ��������� ����������� ������� ��� ������
        resolution1080pButton.onClick.AddListener(() => SetResolution(1920, 1080));
        resolution720pButton.onClick.AddListener(() => SetResolution(1280, 720));
        resolution480pButton.onClick.AddListener(() => SetResolution(640, 480));
    }

    // ����� ��� ��������� ����������
    private void SetResolution(int width, int height)
    {
        Debug.Log($"��������� ���������� �� {width}x{height}");
        Screen.SetResolution(width, height, true);
    }
}
