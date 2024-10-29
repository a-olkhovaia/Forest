using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updown : MonoBehaviour
{

    public float speed = 1;
    public float moveY = 5;
    public float moveX = 5;
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
        if (moveY != 0) Yspeed = moveY / (moveX + moveY);
        else Yspeed = 1;
        if (moveX != 0) Xspeed = moveX / (moveX + moveY);
        else Xspeed = 1;
        if (moveY > 0)
        {
            if (playeronplatform == true && transform.position.y <= moveY + y0)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y +  Time.deltaTime * speed * Yspeed);

            }
            if (playeronplatform == false && transform.position.y >= y0)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y -  Time.deltaTime * speed * Yspeed);
            }
        }
        else
        {
            if (playeronplatform == true && transform.position.y >= moveY + y0)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * speed * Yspeed);
            }
            if (playeronplatform == false && transform.position.y <= y0)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * speed * Yspeed);
            }
        }
        if (moveX > 0)
        {
            if (playeronplatform == true && transform.position.x <= moveX + x0)
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
            if (playeronplatform == true && transform.position.x >= moveX + x0)
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

