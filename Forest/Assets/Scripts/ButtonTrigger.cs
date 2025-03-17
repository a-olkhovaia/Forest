using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public BridgeController bridgeController;
    private int objectsOnButton = 0; // ������� �������� �� ������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MovableObject"))
        {
            objectsOnButton++;
            bridgeController.StartExtending(); // �������� ���������� �����
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("MovableObject"))
        {
            objectsOnButton--;

            if (objectsOnButton <= 0)
            {
                bridgeController.StartRetracting(); // �������� ���������� �����
            }
        }
    }
}
