using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public health Health;

    private void Update()
    {
        if (Health.hp <= 0)
        {
            SceneManager.LoadScene("FinishScene1");
        }
    }

    public void TakeDamage(int damage)
    {
        Health.hp -= damage;
    }
}
