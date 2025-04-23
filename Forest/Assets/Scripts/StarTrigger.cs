using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ���� ������ �������� ������
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("����� �����! ���������� ������...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���������� �����
    }
}
