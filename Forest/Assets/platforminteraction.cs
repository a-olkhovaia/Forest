using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

public class platforminteraction : MonoBehaviour
{
    BoxCollider2D bx;
    updown abc;
    updowncords bc;
    // Start is called before the first frame update
    void Start()
    {
        bx = GetComponent<BoxCollider2D>();
        abc = GetComponentInParent<updown>();
        bc = GetComponentInParent<updowncords>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            abc.playeronplatform = true;
            bc.playeronplatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            abc.playeronplatform = false;
            bc.playeronplatform = false;
        }
    }
}
