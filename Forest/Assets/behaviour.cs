using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviour : MonoBehaviour
{
    GameObject player;
    public float movspeed;
    public float speedchange;
    Rigidbody2D rb;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.localPosition.x < transform.localPosition.x)
            movspeed -= speedchange;
        else movspeed += speedchange;
        rb.velocity = new Vector2(movspeed, rb.velocity.y);
        Flip();
        if (x == transform.localPosition.x) transform.localPosition = new Vector2(x, transform.localPosition.y + 0.0001f);
        x = transform.localPosition.x;
    }
    void Flip()
    {
        if (movspeed > 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (movspeed < 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
