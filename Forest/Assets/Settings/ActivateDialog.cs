using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class ActivateDialog : MonoBehaviour
{
    [SerializeField] private GameObject DialogCanvas;
    [SerializeField] private GameObject Button;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DialogCanvas.SetActive(true);
            Button.SetActive(true);
        }
        var rb = other.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);

    }
}
