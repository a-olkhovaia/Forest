using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviour : MonoBehaviour
{
    GameObject player;
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
        Flip();
        if (x == transform.localPosition.x) transform.localPosition = new Vector2(x, transform.localPosition.y + 0.0001f);
        x = transform.localPosition.x;
    }
    private void FixedUpdate()
    {
        if (player.transform.localPosition.x < transform.localPosition.x)
            rb.velocity = new Vector2(rb.velocity.x - speedchange, rb.velocity.y);
        else rb.velocity = new Vector2(rb.velocity.x + speedchange, rb.velocity.y);
    }
    void Flip()
    {
        if (rb.velocity.x > 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (rb.velocity.x < 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
