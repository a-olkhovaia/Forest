using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class updowncords : MonoBehaviour
{

    public float speed = 1;
    public float Yto = 5;
    public float Xto = 5;
    public bool playeronplatform = false;
    public float y0;
    public float x0;
    public float Yspeed = 0;
    public float Xspeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        y0 = transform.position.y;
        x0 = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Yto != y0) Yspeed = (Yto - y0) / ((Xto - x0) + (Yto - y0));
        else Yspeed = 1;
        if (Xto != x0) Xspeed = (Xto - x0) / ((Xto - x0) + (Yto - y0));
        else Xspeed = 1;
            if (Yto > y0)
        {

            if (playeronplatform == true && transform.position.y <= Yto)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * speed * Yspeed);

            }
            if (playeronplatform == false && transform.position.y >= y0)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * speed * Yspeed);
            }
        }
        else
        {
            if (playeronplatform == true && transform.position.y >= Yto)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * speed * Yspeed);
            }
            if (playeronplatform == false && transform.position.y <= y0)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * speed * Yspeed);
            }
        }
        if (Xto > x0)
        {
            if (playeronplatform == true && transform.position.x <= Xto)
            {
                transform.position = new Vector2(transform.position.x + Time.deltaTime * speed * Xspeed, transform.position.y);
            }
            if (playeronplatform == false && transform.position.x >= x0)
            {
                transform.position = new Vector2(transform.position.x - Time.deltaTime * speed * Xspeed, transform.position.y);
            }
        }
        else
        {
            if (playeronplatform == true && transform.position.x >= Xto)
            {
                transform.position = new Vector2(transform.position.x - Time.deltaTime * speed * Xspeed, transform.position.y);
            }
            if (playeronplatform == false && transform.position.x <= x0)
            {
                transform.position = new Vector2(transform.position.x + Time.deltaTime * speed * Xspeed, transform.position.y);
            }
        }
    }

}

