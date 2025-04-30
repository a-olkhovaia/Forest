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
            GameObject.FindGameObjectWithTag("boss").GetComponent<behaviour>().enabled = true;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().enabled = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<bossfightcam>().enabled = true;
            GameObject.FindGameObjectWithTag("hpbar").transform.localPosition = new Vector3(1.58f, 4.43f, 10);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PF>().bossfight = true;
        }
    }
}
