using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Cycle : MonoBehaviour
{
    [SerializeField] private ButtonManager buttonManager;
    [SerializeField] private ScrollRect scroll;
    [SerializeField] private float cycleTimer;
    
    private Image doorImage;

    private bool day;
    private float timer;

    private void Start()
    {
        doorImage = GetComponent<Image>();
    }

    private void Update()
    {
        if(day) timer += Time.deltaTime;
        
        EndCycle();
    }

    [UsedImplicitly]
    public void BeginCycle()
    {
        doorImage.raycastTarget = false;
        day = true;
        GameBackgrounds.Day = true;
    }

    private void EndCycle()
    {
        if (timer > cycleTimer)
        {
            GameBackgrounds.Day = false;
            day = false;
            timer = 0f;

            GameObject[] customers = GameObject.FindGameObjectsWithTag("Customer");

            foreach (var customer in customers)
            {
                buttonManager.EraseCustomer(customer.transform, -1);
            }

            scroll.enabled = true;
            
            buttonManager.OpenShop();
            doorImage.raycastTarget = true;
        }
    }
}
