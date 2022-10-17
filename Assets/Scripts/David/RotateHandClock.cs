using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHandClock : MonoBehaviour
{
    //public GameObject handClock;
    public List<GameObject> handClocksObject;
    public int rotationSpeed = 1000;

    void Update()
    {
        for (int i = 0; i < handClocksObject.Count; i++)
        {
            handClocksObject[i].transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
    }
}
