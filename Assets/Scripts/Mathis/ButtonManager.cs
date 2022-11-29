using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] Transform customerParent;
    CustomerClass customer;
    List<CustomerClass> customerTab = new List<CustomerClass>();
    CustomerClass pickedCustomer;
    //List<CustomerClass> customerTab2 = new List<CustomerClass>();
    //List<CustomerClass> customerTab3 = new List<CustomerClass>();
    // Start is called before the first frame update
    float timer = 8f;
    bool startDay = false;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < customerTab.Count; i++)
        {
            customerTab[i].Update(i);
        }

        timer += Time.deltaTime;
        Debug.Log(timer  + "   " + startDay);
        if (startDay)
        {
            SpawnCustomer();
        }

        //for (int i = 0; i < customerTab2.Count; i++)
        //{
        //    customerTab2[i].Update();
        //}

        //for (int i = 0; i < customerTab3.Count; i++)
        //{
        //    customerTab3[i].Update();
        //}

        //deplacement des clients
        //for (int i = 0; i < customerTab.Count; i++)
        //{
        //    for (int j = 0; j < customerTab[i].nbPart; j++)
        //    {
        //        customerTab[i].pos[j].x = 2f * (i - 1);
        //        customerTab[i].partDisplay[j].transform.position = new Vector3(customerTab[i].pos[j].x, customerTab[i].pos[j].y);
        //    }
        //}
        //for (int i = 0; i < customerTab2.Count; i++)
        //{
        //    for (int j = 0; j < customerTab2[i].nbPart; j++)
        //    {
        //        customerTab2[i].pos[j].x = 2f * (i - 1);
        //        customerTab2[i].partDisplay[j].transform.position = new Vector3(customerTab2[i].pos[j].x, customerTab2[i].pos[j].y);
        //    }
        //}
        //for (int i = 0; i < customerTab3.Count; i++)
        //{
        //    for (int j = 0; j < customerTab3[i].nbPart; j++)
        //    {
        //        customerTab3[i].pos[j].x = 2f * (i - 1);
        //        customerTab3[i].partDisplay[j].transform.position = new Vector3(customerTab3[i].pos[j].x, customerTab3[i].pos[j].y);
        //    }
        //}
    }

    public void OpenShop()
    {
        startDay = !startDay;
    }

    public void SpawnCustomer()
    {
        if (timer > 8.0f)
        {
            timer = 0f;
            if (customerTab.Count < 3)
            {
                // ajout
                customer = new CustomerClass();
                customerTab.Add(customer);
                customer.DisplayCustomer(customerParent);
                CustomerMove();
                //for (int i = 0; i < 4; i++)
                //{
                //    for (int j = 0; j < 4; j++)
                //    {
                //        for (int k = 0; k < 4; k++)
                //        {
                //            for (int l = 0; l < 4; l++)
                //            {
                //                customer = new CustomerClass();
                //                customerTab.Add(customer);
                //                customer.DiplayDemon(i + 1, j + 1, k + 1, l + 1);

                //                customer = new CustomerClass();
                //                customerTab3.Add(customer);
                //                customer.DiplaySkeleton(i + 1, j + 1, k + 1, l + 1);

                //                for (int m = 0; m < 4; m++)
                //                {
                //                    customer = new CustomerClass();
                //                    customerTab2.Add(customer);
                //                    customer.DiplayPumpkin(i + 1, j + 1, k + 1, l + 1, m + 1);
                //                }
                //            }
                //        }
                //    }
                //}
            }
        }
    }

    public void CustomerMove()
    {
        for (int i = 0; i < customerTab.Count; i++)
        {
            //for (int j = 0; j < customerTab[i].nbPart; j++)
            //{
                //if (i-1 >= 0)
                //{
                //    if (customerTab[i-1].hero == HERO.MERCHANT)
                //    {
                //        customerTab[i].pos[j].x = 3 * (-(i - 0.7f + i * 1.5f));
                //        customerTab[i].partDisplay[j].transform.position = new Vector3(customerTab[i].pos[j].x, customerTab[i].pos[j].y);
                //    }
                //    else
                //    {
                //        customerTab[i].pos[j].x = -(i - 0.7f + i * 1f);
                //        customerTab[i].partDisplay[j].transform.position = new Vector3(customerTab[i].pos[j].x, customerTab[i].pos[j].y);
                //    }
                //}
                //else
                {
                    customerTab[i].pos.x = -(i - 0.7f + i * 1.5f);
                    customerTab[i].parent.transform.position = new Vector3(customerTab[i].pos.x, customerTab[i].pos.y);
                    customerTab[i].parent.GetComponent<RectTransform>().localScale = new Vector3(296 * Mathf.Cos(i), 296 * Mathf.Cos(i));
                    customerTab[i].anim.SetInteger("Pos", i);

                }
            //}
        }
    }

    public void EraseCustomer(Transform parent, int potionIndex)
    {

        int nb = 0;

        for (int i = 0; i < customerTab.Count; i++)
        {
            if (parent == customerTab[i].partDisplay[0].transform.parent)
            {
                pickedCustomer = customerTab[i];
                nb = i;
            }

        }



        if (potionIndex == (int)pickedCustomer.askedPotion_Customer.name)
        {
            Debug.Log(pickedCustomer.Paiement());
        }
        else
        {
            Debug.Log(0);
        }


        for (int i = 0; i < pickedCustomer.nbPart; i++)
        {
            Destroy(pickedCustomer.partDisplay[i]);
        }
        Destroy(parent.gameObject);
        customerTab.RemoveAt(nb);
        CustomerMove();
    }
        
    

}

