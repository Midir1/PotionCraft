using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Sprite sprite;
    CustomerClass customer;
    List<CustomerClass> customerTab = new List<CustomerClass>();
    CustomerClass pickedCustomer;
    // Start is called before the first frame update


    void Start()
    {
        sprite = Resources.Load<Sprite>("unknown");
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < customerTab.Count; i++)
        {
            customerTab[i].Update();
        }
        // suppression
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            int nb = 0;
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider && hit.collider.gameObject.name.Contains("part"))
            {

                for (int i = 0; i < customerTab.Count; i++)
                {
                    if (hit.collider.gameObject.transform.parent == customerTab[i].partDisplay[0].transform.parent)
                    {
                        pickedCustomer = customerTab[i];
                        nb = i;
                    }
                  
                }

                Debug.Log(pickedCustomer.Paiement());

                for (int i = 0; i < pickedCustomer.nbPart; i++)
                {
                    Destroy(pickedCustomer.partDisplay[i]);
                }
                Destroy(hit.collider.transform.parent.gameObject);
                customerTab.RemoveAt(nb);
           
            }
        }


        //deplacement des clients
        for (int i = 0; i < customerTab.Count; i++)
        {
            for (int j = 0; j < customerTab[i].nbPart; j++)
            {
                customerTab[i].pos[j].x = 3.5f * (i - 2);
                customerTab[i].partDisplay[j].transform.position = new Vector3(customerTab[i].pos[j].x, customerTab[i].pos[j].y);
            }
        }
    }

    public void test()
    {
        if (customerTab.Count < 5)
        {     
            //ajout 
            
            customer = new CustomerClass();
            customerTab.Add(customer);
            customer.DiplayCustomer();
        }
    }
}
