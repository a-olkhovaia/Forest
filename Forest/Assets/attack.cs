using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class attack : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> touch;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        attackboss();
    }

    public void attackboss()
    {

        if (Input.GetKeyDown(KeyCode.X)) { 
        foreach (var x in touch)
        {
                if (x.gameObject.CompareTag("boss")) x.GetComponent<health>().hit();
                GetComponentInParent<Animator>().Play("attack");
            } 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        touch.Add(collision.gameObject);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touch.Remove(collision.gameObject);
    }
}
