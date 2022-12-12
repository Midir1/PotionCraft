using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentpos : MonoBehaviour
{
   private float lastPos;
    void Start()
    {
        lastPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastPos != transform.position.x)
        {
            lastPos = transform.position.x;
            Debug.Log(lastPos);
        }
    }
}
