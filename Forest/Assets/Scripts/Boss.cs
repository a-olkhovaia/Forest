using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public health Health;

    private void Update()
    {
        if (Health.hp <= 0) Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        Health.hp -= damage;
    }
}
