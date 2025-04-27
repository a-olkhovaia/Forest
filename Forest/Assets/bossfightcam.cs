using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossfightcam : MonoBehaviour
{
    // Start is called before the first frame update
    public float destx;
    public float desty;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(destx,desty, transform.position.z),3 * Time.deltaTime);
    }
}
