using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.U2D;
using System.IO;
using System;
enum RACE
{
	PUMPKIN,
	DEVIL,
	SKELETON,
	RACENB
}

public enum HERO
{
    MERCHANT,
    WARIOR,
    SUCCUBUS,
    HERONB
}

//temporaire en attendant la classe
public enum INGREDIENT_CUSTOMER
{
	ROUGE,
	VERT,
	BLEU,
    INGREDIENT_CUSTOMERNB
}


public enum RUNES
{
	RUNE1,
	RUNE2,
	RUNE3,
	RUNE4,
	RUNE5,
	RUNE6,
	RUNENB
}

public struct Potion_Customer
{
	public List<INGREDIENT_CUSTOMER> ing;
    public RUNES rune;
    public int price;
    public PotionBp name;
}

public class CustomerClass 
{
    #region Fields
    private float timerMax;
	public float timer;
	public Potion_Customer[] askedPotion_Customer;
	
	//Skin random du perso
	private int[] part;
	public GameObject[] partDisplay;
    public GameObject parent;
    private string[] secondPath;
    private Sprite sprite;
	public Vector2 pos;
	private RACE race;
	public HERO hero;
	public int nbPart;
    public Animator anim;
    private GameManager manager;
    public bool isAngry;
    public bool potionCanFall;
    public List<GameObject> potionGo;
    public List<GameObject> parchemin;
    public int nbPotion;

    #endregion

    public CustomerClass ()
	{
        manager = GameManager.Instance;

        isAngry = false;
        potionCanFall = false;
       


        int Potion_CustomerSize = UnityEngine.Random.Range(1, 4);

		timerMax = 4 * Potion_CustomerSize;
		timer = timerMax;

        if (UnityEngine.Random.Range(1, 11) == 1)
        {
            hero = (HERO)UnityEngine.Random.Range(0, (int)HERO.HERONB);
            race = RACE.RACENB;
        }
        else
        {
            race = (RACE)UnityEngine.Random.Range(0, (int)RACE.RACENB);
            hero = HERO.HERONB;
        }

        nbPotion = 1;

        if (hero == HERO.MERCHANT)
            nbPotion = 3;

        askedPotion_Customer = new Potion_Customer[nbPotion];

        for (int i = 0; i < nbPotion; i++)
        {
            askedPotion_Customer[i] = new Potion_Customer();
            int rng = 0;
            do
            {
                rng = UnityEngine.Random.Range(0, (int)PotionBp.PotionBpNb);
                askedPotion_Customer[i].name = (PotionBp)rng;
            } while (manager.Bp[rng] == false);

            askedPotion_Customer[i].ing = new List<INGREDIENT_CUSTOMER>();

            for (int j = 0; j < Potion_CustomerSize; j++)
            {
                askedPotion_Customer[i].ing.Add((INGREDIENT_CUSTOMER)UnityEngine.Random.Range(0, (int)INGREDIENT_CUSTOMER.INGREDIENT_CUSTOMERNB));
            }

            askedPotion_Customer[i].rune = (RUNES)UnityEngine.Random.Range(0, (int)RUNES.RUNENB);


            askedPotion_Customer[i].price = 100 + 10 * Potion_CustomerSize + 10 * (int)askedPotion_Customer[i].rune;
        }
       

    }


	#region Methods
	public int Paiement()
	{
        int result= 0;
        //renvoie le prix d'acar de la Potion_Customer confectionn�
        for (int i = 0; i < nbPotion; i++)
        {
            float timePrice = (float)askedPotion_Customer[i].price * 0.4f;

            float timeLeft = timer / timerMax;

            timePrice = timePrice * timeLeft;

            float priceLeft = (float)askedPotion_Customer[i].price * 0.3f;
            //compare Potion_Customer cr�er et demander

            result += (int)timePrice + (int)priceLeft * 2;
        }
		
        
		return result;
	}

    public void DisplayCustomer(Transform customerParent)
	{
		string path;

        if (race == RACE.RACENB)
        {
            switch (hero)
            {
                case HERO.MERCHANT:
                    path = "OC/tenu3";  
                    break;
                case HERO.WARIOR:   
                    path = "OC/tenu1";
                    break;
                case HERO.SUCCUBUS:
                    path = "OC/tenu2";
                    potionCanFall = true;
                    break;
                default:
                    path = "";
                    break;
            }

            nbPart = 1;

            secondPath = new string[nbPart];
            partDisplay = new GameObject[nbPart];
            part = new int[nbPart];

            part[0] = 0;
            secondPath[0] = "";

        }
        else
        {
            switch (race)
            {
                case RACE.PUMPKIN:
                    path = Pumpkin();
                    break;
                case RACE.DEVIL:
                    path = Devil();
                    break;
                case RACE.SKELETON:
                    path = Skeleton();
                    break;
                default:
                    path = Devil();
                    break;
            }

            for (int i = 0; i < nbPart; i++)
            {
                part[i] = UnityEngine.Random.Range(1, 5);
            }

        }

        
        parent = new GameObject("Customer", typeof(RectTransform));
        parent.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 1.8f);
        parent.GetComponent<RectTransform>().SetParent(customerParent);
        //anim = parent.AddComponent<Animator>();
        //anim.runtimeAnimatorController = Resources.Load("AnimationController/Customer") as RuntimeAnimatorController; ;
        //anim.SetInteger("Race", (int)race);

        float ratioH = (1920 / (float)Screen.height)* 1.5f;
        parent.transform.localScale *= ratioH; 
        parent.transform.SetSiblingIndex(0);
        for (int i = 0; i < nbPart; i++)
        {

            pos = new Vector2(1, 2);
            partDisplay[i] = new GameObject("part" + i, typeof(RectTransform));
            partDisplay[i].AddComponent<Rigidbody2D>().isKinematic = true;
            Image image = partDisplay[i].AddComponent<Image>();
            BoxCollider2D collide = partDisplay[i].AddComponent<BoxCollider2D>();
            collide.isTrigger = true;
            if (nbPart == 1)
            {
                if (hero == HERO.MERCHANT)
                {
                    pos = new Vector2(0.5f, 2);
                }
                else
                {
                    pos = new Vector2(1, 2);
                }
                
                sprite = Resources.Load<Sprite>(path);
            }
            else
            {
                sprite = Resources.Load<Sprite>(string.Concat(path, secondPath[i], part[i]));
            }

            image.sprite = sprite;
            Vector2 size = image.sprite.bounds.size;
            collide.size = size;
    
            partDisplay[i].GetComponent<RectTransform>().sizeDelta = size;
            Vector2 pivot = new Vector2(sprite.pivot.x / (size.x* sprite.pixelsPerUnit), sprite.pivot.y / (size.y* sprite.pixelsPerUnit));

            partDisplay[i].GetComponent<RectTransform>().pivot = pivot;
            partDisplay[i].GetComponent<RectTransform>().anchoredPosition = pos;
      
            partDisplay[i].GetComponent<RectTransform>().SetParent(parent.transform); 

        }

        parchemin = new List<GameObject>();
        potionGo = new List<GameObject>();

        //Diplay potion
        for (int i = 0; i < nbPotion; i++)
        {
            path = PathToPotion(i);
            parchemin.Add(new GameObject("parcho", typeof(RectTransform)));
            potionGo.Add(new GameObject("askedPotion", typeof(RectTransform)));
            Image bulleImage = parchemin[i].AddComponent<Image>();
            Image potionImage = potionGo[i].AddComponent<Image>();
            Sprite bulleSprite = Resources.Load<Sprite>("UI/Parcho");
            Sprite potionSprite = Resources.Load<Sprite>(path);

            bulleImage.sprite = bulleSprite;
            potionImage.sprite = potionSprite;



            Vector2 size = bulleSprite.bounds.size;
            parchemin[i].GetComponent<RectTransform>().sizeDelta = size;

            size = potionSprite.bounds.size;
            potionGo[i].GetComponent<RectTransform>().sizeDelta = size;



            potionGo[i].GetComponent<RectTransform>().localScale = new Vector3(0.3f, 0.3f, 0.3f);

            parchemin[i].transform.SetParent(parent.transform);
            potionGo[i].transform.SetParent(parent.transform);

            parchemin[i].transform.position = new Vector2(0 - nbPotion * 0.4f , 3.2f-i);
            potionGo[i].transform.position = new Vector2(0 - nbPotion * 0.4f, 3.2f-i);
        }
    }

    private string PathToPotion(int i)
    {
        string potionPath = "Potions/";
        switch (askedPotion_Customer[i].name)
        {
            case PotionBp.Horned:
                potionPath += "Horny_potion";
                break;
            case PotionBp.Heart:
                potionPath += "Love_potion";
                break;
            case PotionBp.Clean:
                potionPath += "Clean_potion";
                break;
            case PotionBp.Drunkard:
                potionPath += "Alcoolic_potion_300";
                break;
            case PotionBp.Gamer:
                potionPath += "Gamer_potion";
                break;
            case PotionBp.Graphic:
                potionPath += "Graph_Potion";
                break;
            case PotionBp.Luminescence:
                potionPath += "Luminescent_potion";
                break;
            case PotionBp.Champ:
                potionPath += "Sea_Potion";
                break;
            case PotionBp.Sleep:
                potionPath += "Sleep_potion";
                break;
            case PotionBp.Spicy:
                potionPath += "Spicy_potion";
                break;
            case PotionBp.Strawberry:
                potionPath += "Berry_potion";
                break;
            case PotionBp.Sea:
                potionPath += "Champotion";
                break;
            case PotionBp.Toad:
                potionPath += "Toad_potion";
                break;
            default:
                break;
        }
        return potionPath;
    }

    public void Angry()
    {
        string eye;
        int posEye = 3;
        string path;


        if (race == RACE.RACENB)
        {
            Potion_Customer tempPot;
            int rng = 0;
            string pathPot;
            switch (hero)
            {
                case HERO.MERCHANT:
                    path = "OC/tenu_mechant3";
                    break;
                case HERO.WARIOR:
                    path = "OC/tenu_mechant1-tourner";

                    tempPot = askedPotion_Customer[0];
                    do
                    {
                        rng = UnityEngine.Random.Range(0, (int)PotionBp.PotionBpNb);
                        askedPotion_Customer[0].name = (PotionBp)rng;
                    } while (manager.Bp[rng] == false || askedPotion_Customer[0].name == tempPot.name);

                    pathPot = PathToPotion(0);

                    potionGo[0].GetComponent<Image>().sprite = Resources.Load<Sprite>(pathPot);

                    break;
                case HERO.SUCCUBUS:
                    path = "OC/tenu_mechant2";
                    break;
                default:
                    path = "";
                    break;
            }
            Sprite s = Resources.Load<Sprite>(path);

            partDisplay[0].GetComponent<Image>().sprite = s;
        }
        else
        {
            switch (race)
            {
                case RACE.PUMPKIN:
                    path = "pumpkin/";
                    break;
                case RACE.DEVIL:
                    path = "demon/";
                    break;
                case RACE.SKELETON:
                    path = "skeleton/";
                    posEye = 2;
                    break;
                default:
                    path = "";
                    break;
            }

            path += "eye/yeux_mechant";
            eye = partDisplay[posEye].GetComponent<Image>().sprite.name;
            path += eye[eye.Length - 1];

            Sprite s = Resources.Load<Sprite>(path);

            partDisplay[posEye].GetComponent<Image>().sprite = s;

            if (race == RACE.PUMPKIN)
            {
                string mouth = partDisplay[4].GetComponent<Image>().sprite.name;


                s = Resources.Load<Sprite>("pumpkin/mouth/bouche_mechant" + mouth[mouth.Length - 1]);

                partDisplay[4].GetComponent<Image>().sprite = s;

            }
        }    
        isAngry = true;
    }

    public string Skeleton()
    {
        string path = "skeleton/";

        nbPart = 4;
        partDisplay = new GameObject[nbPart];

        secondPath = new string[nbPart];

        secondPath[0] = "cloth/tenu";
        secondPath[1] = "face/tete";
        secondPath[2] = "eye/yeux";
        secondPath[3] = "hair/cheveux";

        part = new int[nbPart];
        return path;
    }

    public string Pumpkin()
	{
		string path = "pumpkin/";

        nbPart = 5;
        partDisplay = new GameObject[nbPart];

        secondPath = new string[nbPart];

        secondPath[0] = "cloth/tenu";
        secondPath[1] = "hair/cheveux";
        secondPath[2] = "face/tete";
        secondPath[3] = "eye/yeux";
        secondPath[4] = "mouth/bouche";

        part = new int[nbPart];
        return path;
    }

    public string Devil()
    {
        string path = "demon/";

        nbPart = 4;
        partDisplay = new GameObject[nbPart];

        secondPath = new string[nbPart];

        secondPath[0] = "hair/cheveux";
        secondPath[1] = "cloth/tenu";
        secondPath[2] = "face/tete";
        secondPath[3] = "eye/yeux";

        part = new int[nbPart];
        return path;
    }

    public void Update(int pos)
	{
		timer -= Time.deltaTime;
        if (timer < timerMax*0.5 && !isAngry)
        {
            Angry();
        }
        
    }

	#endregion
}