using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneDrawLine : MonoBehaviour
{
    int length;

    LineRenderer lr;



    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        length = 0;
        lr.loop = false;
        lr.positionCount = 0;
    }


    void Update()
    {
        
    }

    public void Braval()
    {
        Debug.Log("Rune Goujoub");
        Destroy(gameObject);
    }

    public void Fail()
    {
        Debug.Log("Rune No");
        Destroy(gameObject);
    }

    public void newLineVertex(Vector2 _pos)
    {

        lr.positionCount = lr.positionCount + 1;
        lr.SetPosition(length, _pos + (Vector2)transform.position);
        length++;
    }
}
