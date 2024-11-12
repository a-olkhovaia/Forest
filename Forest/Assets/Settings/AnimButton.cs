using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimButton : MonoBehaviour
{
    [SerializeField] private Transform rt;
    [SerializeField] private float speed;


    private void Update()
    {
        rt.position = Vector3.Lerp(rt.position, rt.position, speed * Time.deltaTime);
    }

    private void Lerp()
    {
    }
}
