using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushtrig : MonoBehaviour
{
    BoxCollider2D bx;
    Transform abc;
    public bool triggered = false;
    public bool trigger = false;
    private int timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        bx = GetComponent<BoxCollider2D>();
        abc = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!triggered && trigger)
        {
            this.transform.parent.localRotation = Quaternion.Lerp(this.transform.parent.localRotation, Quaternion.Euler(0, 0, -60), Time.deltaTime);
            timer++;
            if (timer > 1000) triggered = true;
        }
     }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            trigger = true;
        }
    }
}
