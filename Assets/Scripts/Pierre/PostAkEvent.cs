using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostAkEvent : MonoBehaviour
{
    [SerializeField] bool postOnDisable = false;
    [SerializeField] bool postOnStart = false;
    [SerializeField] bool postOnDestroy = false;

    public AK.Wwise.Event eventSound;
    public void PostEvent()
    {
        eventSound.Post(gameObject);
    }
    private void Start()
    {
        if (postOnStart)
        {
            eventSound.Post(gameObject);
        }
    }
    private void OnDisable()
    {
        if (postOnDisable)
        {
            eventSound.Post(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (postOnDestroy)
        {
            eventSound.Post(gameObject);
        }
    }
}
