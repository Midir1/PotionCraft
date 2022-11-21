using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.U2D;
using System.IO;

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

public enum POTION_NAME
{
    CHAMP,
    LOVE,
    HEXA,
    SEA,
    NBPOTION
}

public struct Potion_Customer
{
	public List<INGREDIENT_CUSTOMER> ing;
    public RUNES rune;
    public int price;
    public POTION_NAME name;
}

public class CustomerClass 
{
    #region Fields
    private float timerMax;
	public float timer;
	public Potion_Customer askedPotion_Customer;
	
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
    Canvas canvas;


    private bool isAngry;
    
	#endregion

	public CustomerClass ()
	{

        canvas = GameObject.FindObjectOfType<Canvas>();
        isAngry = false;

		askedPotion_Customer = new Potion_Customer();

        askedPotion_Customer.name = (POTION_NAME)Random.Range(0, (int)POTION_NAME.NBPOTION);

        int Potion_CustomerSize = Random.Range(1, 4);

		timerMax = 4 * Potion_CustomerSize;
		timer = timerMax;
		askedPotion_Customer.ing = new List<INGREDIENT_CUSTOMER>();

        for (int i = 0; i < Potion_CustomerSize; i++)
		{
			askedPotion_Customer.ing.Add((INGREDIENT_CUSTOMER)Random.Range(0, (int)INGREDIENT_CUSTOMER.INGREDIENT_CUSTOMERNB));
		}

		askedPotion_Customer.rune = (RUNES)Random.Range(0, (int)RUNES.RUNENB);

        secondPath = new string[5];

        secondPath[0] = "cloth/tenu";
        secondPath[1] = "hair/cheveux";
        secondPath[2] = "face/tete";
        secondPath[3] = "eye/yeux";
        secondPath[4] = "mouth/bouche";


        askedPotion_Customer.price = 100 + 10 * Potion_CustomerSize + 10 * (int)askedPotion_Customer.rune;
        if (Random.Range(1, 11) == 1)
        {
            hero = (HERO)Random.Range(0, (int)HERO.HERONB);
            race = RACE.RACENB;
        }
        else
        {
            race = (RACE)Random.Range(0, (int)RACE.RACENB);
            hero = HERO.HERONB;
        }
    }


	#region Methods
	public int Paiement()
	{
		//renvoie le prix d'acar de la Potion_Customer confectionné

		float timePrice = (float)askedPotion_Customer.price * 0.4f;

		float timeLeft = timer / timerMax;

		timePrice = timePrice * timeLeft;
		
		float priceLeft = (float)askedPotion_Customer.price * 0.3f;
		//compare Potion_Customer créer et demander

		int result = (int)timePrice + (int)priceLeft * 2;
        
		return result;
	}


    //public void DisplayDemon(int p0, int p1, int p2, int p3)
    //{
    //    string path = Devil();

    //    part[0] = p0;
    //    part[1] = p1;
    //    part[2] = p2;
    //    part[3] = p3;

    //    GameObject parent = new GameObject();
    //    parent.transform.position = new Vector2(pos.x, pos.y);
    //    parent.name = "Customer";

    //    for (int i = 0; i < nbPart; i++)
    //    {
    //        pos.x = 0;
    //        pos.y = 0;
    //        partDisplay[i] = new GameObject("part" + i);
    //        SpriteRenderer spriteRenderer = partDisplay[i].AddComponent<SpriteRenderer>();
    //        BoxCollider2D collide = partDisplay[i].AddComponent<BoxCollider2D>();

    //        sprite = Resources.Load<Sprite>(string.Concat(path, secondPath[i], part[i]));
    //        partDisplay[i].transform.position = new Vector2(pos.x, pos.y);
    //        spriteRenderer.sprite = sprite;

    //        Vector2 S = spriteRenderer.sprite.bounds.size;
    //        collide.size = S;

    //        partDisplay[i].transform.parent = parent.transform;

    //    }
    //}


    //public void DisplaySkeleton(int p0, int p1, int p2, int p3)
    //{
    //    string path = Skeleton();

    //    part[0] = p0;
    //    part[1] = p1;
    //    part[2] = p2;
    //    part[3] = p3;

    //    GameObject parent = new GameObject();
    //    parent.transform.position = new Vector2(pos.x, pos.y);
    //    parent.name = "Customer";

    //    for (int i = 0; i < nbPart; i++)
    //    {
    //        pos.x = 0;
    //        pos.y = -5;
    //        partDisplay[i] = new GameObject("part" + i);
    //        SpriteRenderer spriteRenderer = partDisplay[i].AddComponent<SpriteRenderer>();
    //        BoxCollider2D collide = partDisplay[i].AddComponent<BoxCollider2D>();

    //        sprite = Resources.Load<Sprite>(string.Concat(path, secondPath[i], part[i]));
    //        partDisplay[i].transform.position = new Vector2(pos.x, pos.y);
    //        spriteRenderer.sprite = sprite;

    //        Vector2 S = spriteRenderer.sprite.bounds.size;
    //        collide.size = S;

    //        partDisplay[i].transform.parent = parent.transform;

    //    }
    //}

    //public void DisplayPumpkin(int p0, int p1, int p2, int p3, int p4)
    //{
    //    string path = Pumpkin();

    //    part[0] = p0;
    //    part[1] = p1;
    //    part[2] = p2;
    //    part[3] = p3;
    //    part[4] = p4;

    //    GameObject parent = new GameObject();
    //    parent.transform.position = new Vector2(pos.x, pos.y);
    //    parent.name = "Customer";

    //    for (int i = 0; i < nbPart; i++)
    //    {
    //        pos.x = 0;
    //        pos.y = 5;
    //        partDisplay[i] = new GameObject("part" + i);
    //        SpriteRenderer spriteRenderer = partDisplay[i].AddComponent<SpriteRenderer>();
    //        BoxCollider2D collide = partDisplay[i].AddComponent<BoxCollider2D>();

    //        sprite = Resources.Load<Sprite>(string.Concat(path, secondPath[i], part[i]));
    //        partDisplay[i].transform.position = new Vector2(pos.x, pos.y);
    //        spriteRenderer.sprite = sprite;

    //        Vector2 S = spriteRenderer.sprite.bounds.size;
    //        collide.size = S;

    //        partDisplay[i].transform.parent = parent.transform;

    //    }

    //}


    public void DisplayCustomer()
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
                part[i] = Random.Range(1, 5);
            }

        }

        
        parent = new GameObject("Customer", typeof(RectTransform));
        parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 1.8f);
        parent.GetComponent<RectTransform>().SetParent(canvas.transform);

        for (int i = 0; i < nbPart; i++)
        {

            pos = new Vector2(1, 2);
            partDisplay[i] = new GameObject("part" + i, typeof(RectTransform));
            Image image = partDisplay[i].AddComponent<Image>();
            BoxCollider2D collide = partDisplay[i].AddComponent<BoxCollider2D>();
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
        //Diplay potion

        if (hero != HERO.MERCHANT)
        {
            string potionPath = "Potions/";
            switch (askedPotion_Customer.name)
            {
                case POTION_NAME.CHAMP:
                    potionPath += "Champotion";
                    break;
                case POTION_NAME.LOVE:
                    potionPath += "LovePotion";
                    break;
                case POTION_NAME.HEXA:
                    potionPath += "Hexa_potion";
                    break;
                case POTION_NAME.SEA:
                    potionPath += "SeaPotion";
                    break;
                default:
                    break;
            }
            GameObject bulle = new GameObject("parcho", typeof(RectTransform));
            GameObject potion = new GameObject("askedPotion", typeof(RectTransform));
            Image bulleRenderer = bulle.AddComponent<Image>();
            Image potionRenderer = potion.AddComponent<Image>();
            Sprite bulleSprite = Resources.Load<Sprite>("UI/Parcho");
            Sprite potionSprite = Resources.Load<Sprite>(potionPath);



            bulleRenderer.sprite = bulleSprite;
            potionRenderer.sprite = potionSprite;

            Vector2 size = bulleSprite.bounds.size;
            bulle.GetComponent<RectTransform>().sizeDelta = size;

            size = potionSprite.bounds.size;
            potion.GetComponent<RectTransform>().sizeDelta = size;
   
            bulle.GetComponent<RectTransform>().anchoredPosition = new Vector2(-0.5f, 2);
            potion.GetComponent<RectTransform>().anchoredPosition = new Vector2(-0.5f, 2);

            bulle.transform.SetParent(parent.transform);
            potion.transform.SetParent(parent.transform);


        }
    }

    public void Angry()
    {
        string eye;

        string path;


        if (race == RACE.RACENB)
        {
            switch (hero)
            {
                case HERO.MERCHANT:
                    path = "OC/tenu_mechant3";
                    break;
                case HERO.WARIOR:
                    path = "OC/tenu_mechant1-tourner";
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
                    break;
                default:
                    path = "";
                    break;
            }

            path += "eye/yeux_mechant";
            eye = partDisplay[3].GetComponent<Image>().sprite.name;
            path += eye[eye.Length - 1];

            Sprite s = Resources.Load<Sprite>(path);

            partDisplay[3].GetComponent<Image>().sprite = s;

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

        part = new int[nbPart];
        return path;
    }

    public string Pumpkin()
	{
		string path = "pumpkin/";

        nbPart = 5;
        partDisplay = new GameObject[nbPart];

        part = new int[nbPart];
        return path;
    }

    public string Devil()
    {
        string path = "demon/";

        nbPart = 4;
        partDisplay = new GameObject[nbPart];

        part = new int[nbPart];
        return path;
    }

    public void Update()
	{
		timer -= Time.deltaTime;
        if (timer < timerMax*0.5 && !isAngry)
        {
            Angry();
        } 
    }

	#endregion
}