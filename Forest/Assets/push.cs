using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour
{
    public bool triggered = false;
    public bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() { }
    
    public void fallstr()
    {
        if (!triggered)
        {
            triggered = true;
            transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(30, 0, 0), Time.deltaTime);
        }
    }
}
