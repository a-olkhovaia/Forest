using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviour : MonoBehaviour
{
    GameObject player;
    public float speedchange;
    Rigidbody2D rb;
    float x;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
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
        if (Mathf.Abs(rb.velocity.x) > 1) anim.SetBool("isrunning", true);
        else anim.SetBool("isrunning", false);
        bosscam();
    }
    void Flip()
    {
        if (rb.velocity.x > 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (rb.velocity.x < 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    void bosscam()
    {
        Vector3 cameraToObject = transform.position - Camera.main.transform.position;
        float distance = -Vector3.Project(cameraToObject, Camera.main.transform.forward).z;

        Vector3 leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        float x_left = leftBot.x;
        float x_right = rightTop.x;
        float y_top = rightTop.y;
        float y_bot = leftBot.y;

        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
        clampedPos.y = Mathf.Clamp(clampedPos.y, y_bot, y_top);
        transform.position = clampedPos;
    }
}
