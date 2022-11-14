using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentpos : MonoBehaviour
{
   private float lastPos;
    void Start()
    {
        lastPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(lastPos != transform.position.y)
        {
            lastPos = transform.position.y;
            Debug.Log(lastPos);
        }
    }
}
