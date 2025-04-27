using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosstrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("boss").GetComponent<Behaviour>().enabled = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().enabled = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<bossfightcam>().enabled = true;
        }
    }
}
