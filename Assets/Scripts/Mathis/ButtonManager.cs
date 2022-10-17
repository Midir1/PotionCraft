using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Sprite sprite;
    CustomerClass customer;
    List<CustomerClass> customerTab = new List<CustomerClass>();
    CustomerClass pickedCustomer;
    int nb;
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

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider && hit.collider.gameObject.name.Contains("part"))
            {

                char lastChar = hit.collider.gameObject.transform.parent.name[hit.collider.gameObject.transform.parent.name.Length - 1];
                nb = lastChar - '0';
                pickedCustomer = customerTab[nb - 1];
            }
        }

    }

    public void test()
    {
        if (customerTab.Count < 5)
        {
                //deplacement des clients
                for (int i = 0; i < customerTab.Count; i++)
            {
                for (int j = 0; j < customerTab[i].nbPart; j++)
                {
                    //Destroy(customer.partDisplay[i]);
                    customerTab[i].pos[j].x += 3.5f;
                    customerTab[i].partDisplay[j].transform.position = new Vector3(customerTab[i].pos[j].x, customerTab[i].pos[j].y);
                }
            }
        
            //ajout et suppression
        
            customer = new CustomerClass();
            customerTab.Add(customer);
            customer.DiplayCustomer(customerTab.Count);
            
        }
        //if ()
        //{
        //    Debug.Log(pickedCustomer.partDisplay[0].transform.parent.name);
        //    for (int i = 0; i < customerTab[nb].nbPart; i++)
        //    {
        //        Destroy(customerTab[nb].partDisplay[i]);
        //    }
        //    //Debug.Log(customerTab[0].Paiement());
        //    customerTab.RemoveAt(nb);
            
        //}
        
    }
}
