using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostAkEvent : MonoBehaviour
{
    public AK.Wwise.Event eventSound;
    public void PostEvent()
    {
        eventSound.Post(gameObject);
    }
}