using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    [SerializeField] Transform customerParent;
    CustomerClass customer;
    List<CustomerClass> customerTab = new List<CustomerClass>();
    CustomerClass pickedCustomer;

    [SerializeField]Image shopForeground;
    [SerializeField]Image doorImage;
    
    [SerializeField]Canvas grimoireCanvas;
    [SerializeField]List<GameObject> potions;
    [SerializeField]GameObject turnPage;
    [SerializeField]GameObject VFX;
    
    float timer = 8f;
    bool startDay = false;
    

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < customerTab.Count; i++)
        {
            customerTab[i].Update(i);
        }

        timer += Time.deltaTime;

        if (GameManager.Instance.tutoState)
        {
            if (StateManager.Instance.CurrentState == 2 && !StateManager.Instance.spawnClient)
            {
                startDay = true;
                StateManager.Instance.spawnClient = true;
            }
        }

        if (startDay)
        {
            SpawnCustomer();
            if (GameManager.Instance.tutoState)
                startDay = false;
        }

    }
    public void OpenShop()
    {

        startDay = !startDay;
        if (!GameManager.Instance.tutoState)
        {
            if (startDay)
            {
                shopForeground.sprite = Resources.Load<Sprite>("background/Bot_1OpenAlpha");
                doorImage.sprite = Resources.Load<Sprite>("background/porte_ouverte");
                doorImage.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(-414, doorImage.GetComponent<RectTransform>().anchoredPosition3D.y);
            }
            else
            {
                shopForeground.sprite = Resources.Load<Sprite>("background/Bot_1CloseAlpha");
                doorImage.sprite = Resources.Load<Sprite>("background/porte");
                doorImage.GetComponent<RectTransform>().anchoredPosition3D = new Vector2(-332, doorImage.GetComponent<RectTransform>().anchoredPosition3D.y);
            }
        }
    }

    public void SpawnCustomer()
    {
        if (!GameManager.Instance.tutoState)
        {
            if (timer > 8.0f)
            {
                timer = 0f;
                if (customerTab.Count < 3)
                {
                    // ajout
                    customer = new CustomerClass();
                    customer.InitializeGrimoire(grimoireCanvas, potions, turnPage);
                    customerTab.Add(customer);
                    customer.DisplayCustomer(customerParent);
                    CustomerMove();

                }
            }
        }
        else
        {
            customer = new CustomerClass();
            customerTab.Add(customer);
            customer.DisplayCustomer(customerParent);
        }
    }

    public void CustomerMove()
    {
        for (int i = 0; i < customerTab.Count; i++)
        {
            {
                //customerTab[i].pos.x = -(i - 0.7f + i * 1.5f);
                //customerTab[i].parent.transform.position = new Vector3(customerTab[i].pos.x, customerTab[i].pos.y); 
                //Vector3 pos = customerTab[i].parent.GetComponent<RectTransform>().anchoredPosition3D;
                //customerTab[i].parent.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(pos.x,pos.y,0);
                //customerTab[i].parent.GetComponent<RectTransform>().localScale = new Vector3(296 * Mathf.Cos(i), 296 * Mathf.Cos(i));
                customerTab[i].anim.SetInteger("Pos", 3-i);
            }
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
            if (pickedCustomer.isAngry && pickedCustomer.hero == HERO.SUCCUBUS && pickedCustomer.potionCanFall == true)
            {
                Debug.Log("Potion tomber");
                pickedCustomer.potionCanFall = false;
            }
            else
            {
                bool wrongPot = true;

                for (int i = 0; i < pickedCustomer.parchemin.Count; i++)
                {

                    if (potionIndex == (int)pickedCustomer.askedPotion_Customer[i].name)
                    {
                        Debug.Log("Bonne potion");

                        if (pickedCustomer.Paiement() > 0)
                        {
                            GameManager.Instance.AddMoney(pickedCustomer.Paiement());
                            GameObject go = Instantiate(VFX, transform);

                            go.GetComponent<ParticleSystem>().Play();
                            Destroy(go, 1.0f);
                        }
                    
                        Destroy(pickedCustomer.parchemin[i]);
                        Destroy(pickedCustomer.potionGo[i]);
                        pickedCustomer.parchemin.RemoveAt(i);
                        pickedCustomer.potionGo.RemoveAt(i);
                        wrongPot = false;
                        break;
                    }
                }

                if (wrongPot)
                {
                    Debug.Log("Mauvaise Potion");
                    pickedCustomer.isAngry = true;
                }

                if (pickedCustomer.potionGo.Count == 0 || wrongPot)
                {
                    pickedCustomer.anim.SetInteger("Pos", 4);
                    for (int i = 0; i < pickedCustomer.nbPart; i++)
                    {
                    Destroy(pickedCustomer.partDisplay[i]) ;
                    }
                    Destroy(parent.gameObject);
                    customerTab.RemoveAt(nb);
                    
                    CustomerMove();
                }

            }
        
        
    }

    public void ButtonQuit()
    {

        if (GameManager.Instance.tutoState)
            StateManager.Instance.CurrentState++;

    }

}

