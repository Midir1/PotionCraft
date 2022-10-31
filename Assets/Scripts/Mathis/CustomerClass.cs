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

enum HERO
{
    MERCHANT,
    WARIOR,
    SUCCUBUS,
    HERONB
}

//temporaire en attendant la classe
enum INGREDIENT
{
	ROUGE,
	VERT,
	BLEU,
    INGREDIENTNB
}


enum RUNES
{
	RUNE1,
	RUNE2,
	RUNE3,
	RUNE4,
	RUNE5,
	RUNE6,
	RUNENB
}

struct Potion
{
	public List<INGREDIENT> ingredient;
    public RUNES rune;
    public int price;
}

public class CustomerClass 
{
	#region Fields
	private float timerMax;
	public float timer;
	Potion askedPotion;
	
	//Skin random du perso
	private int[] part;
	public GameObject[] partDisplay;
	private string[] secondPath;
    public Sprite sprite;
	public Vector2[] pos = new Vector2[5];
	private RACE race;
	private HERO hero;
	public int nbPart;


    bool isAngry;

	#endregion

	public CustomerClass ()
	{
        isAngry = false;

		askedPotion = new Potion();

		int potionSize = Random.Range(1, 4);

		timerMax = 4 * potionSize;
		timer = timerMax;
		askedPotion.ingredient = new List<INGREDIENT>();

        for (int i = 0; i < potionSize; i++)
		{
			askedPotion.ingredient.Add((INGREDIENT)Random.Range(0, (int)INGREDIENT.INGREDIENTNB));
		}

		askedPotion.rune = (RUNES)Random.Range(0, (int)RUNES.RUNENB);

		askedPotion.price = 100 + 10 * potionSize + 10 * (int)askedPotion.rune;
        //if (Random.Range(1,11) != 0)
        //{
        //    hero = (HERO)Random.Range(0, (int)HERO.HERONB);
        //    race = RACE.RACENB;
        //}
        //else
        {
            race = (RACE)Random.Range(0, (int)RACE.RACENB);
        }
    }


	#region Methods
	public int Paiement()
	{
		//renvoie le prix d'acar de la potion confectionné

		float timePrice = (float)askedPotion.price * 0.4f;

		float timeLeft = timer / timerMax;

		timePrice = timePrice * timeLeft;
		
		float priceLeft = (float)askedPotion.price * 0.3f;
		//compare potion créer et demander

		int result = (int)timePrice + (int)priceLeft * 2;
        
		return result;
	}


    public void DiplayDemon(int p0, int p1, int p2, int p3)
    {
        string path = Devil();

        part[0] = p0;
        part[1] = p1;
        part[2] = p2;
        part[3] = p3;

        GameObject parent = new GameObject();
        parent.transform.position = new Vector2(pos[0].x, pos[0].y);
        parent.name = "Customer";

        for (int i = 0; i < nbPart; i++)
        {
            pos[i].x = 0;
            pos[i].y = 0;
            partDisplay[i] = new GameObject("part" + i);
            SpriteRenderer spriteRenderer = partDisplay[i].AddComponent<SpriteRenderer>();
            BoxCollider2D collide = partDisplay[i].AddComponent<BoxCollider2D>();

            sprite = Resources.Load<Sprite>(string.Concat(path, secondPath[i], part[i]));
            partDisplay[i].transform.position = new Vector2(pos[i].x, pos[i].y);
            spriteRenderer.sprite = sprite;

            Vector2 S = spriteRenderer.sprite.bounds.size;
            collide.size = S;

            partDisplay[i].transform.parent = parent.transform;

        }
    }


    public void DiplaySkeleton(int p0, int p1, int p2, int p3)
    {
        string path = Skeleton();

        part[0] = p0;
        part[1] = p1;
        part[2] = p2;
        part[3] = p3;

        GameObject parent = new GameObject();
        parent.transform.position = new Vector2(pos[0].x, pos[0].y);
        parent.name = "Customer";

        for (int i = 0; i < nbPart; i++)
        {
            pos[i].x = 0;
            pos[i].y = -3;
            partDisplay[i] = new GameObject("part" + i);
            SpriteRenderer spriteRenderer = partDisplay[i].AddComponent<SpriteRenderer>();
            BoxCollider2D collide = partDisplay[i].AddComponent<BoxCollider2D>();

            sprite = Resources.Load<Sprite>(string.Concat(path, secondPath[i], part[i]));
            partDisplay[i].transform.position = new Vector2(pos[i].x, pos[i].y);
            spriteRenderer.sprite = sprite;

            Vector2 S = spriteRenderer.sprite.bounds.size;
            collide.size = S;

            partDisplay[i].transform.parent = parent.transform;

        }
    }

    public void DiplayPumpkin(int p0, int p1, int p2, int p3, int p4)
    {
        string path = Pumpkin();

        part[0] = p0;
        part[1] = p1;
        part[2] = p2;
        part[3] = p3;
        part[4] = p4;

        GameObject parent = new GameObject();
        parent.transform.position = new Vector2(pos[0].x, pos[0].y);
        parent.name = "Customer";

        for (int i = 0; i < nbPart; i++)
        {
            pos[i].x = 0;
            pos[i].y = 3;
            partDisplay[i] = new GameObject("part" + i);
            SpriteRenderer spriteRenderer = partDisplay[i].AddComponent<SpriteRenderer>();
            BoxCollider2D collide = partDisplay[i].AddComponent<BoxCollider2D>();

            sprite = Resources.Load<Sprite>(string.Concat(path, secondPath[i], part[i]));
            partDisplay[i].transform.position = new Vector2(pos[i].x, pos[i].y);
            spriteRenderer.sprite = sprite;

            Vector2 S = spriteRenderer.sprite.bounds.size;
            collide.size = S;

            partDisplay[i].transform.parent = parent.transform;

        }

    }


    public void DiplayCustomer()
	{
		string path;

        if (race == RACE.RACENB)
        {
            switch (hero)
            {
                case HERO.MERCHANT:
                    path = "OC/minotaur";
                    break;
                case HERO.WARIOR:   
                    path = "OC/warior";
                    break;
                case HERO.SUCCUBUS:
                    path = "OC/succubus";
                    break;
                default:
                    path = "";
                    break;
            }

            nbPart = 1;

            secondPath = new string[nbPart];
            partDisplay = new GameObject[nbPart];
            pos = new Vector2[nbPart];
            part = new int[nbPart];

            part[0] = 0;
            secondPath[0] = "";
            pos[0] = new Vector2 (1,3);

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

        }

        for (int i = 1; i < nbPart; i++)
        {
            part[i] = Random.Range(1, 5);
        }
        GameObject parent = new GameObject();
        parent.transform.position = new Vector2(pos[0].x, pos[0].y);
        parent.name = "Customer";

        for (int i = 0; i < nbPart; i++)
        {
            pos[i].x = 1;
            pos[i].y = 3;
            partDisplay[i] = new GameObject("part" + i);
            SpriteRenderer spriteRenderer = partDisplay[i].AddComponent<SpriteRenderer>();
            BoxCollider2D collide = partDisplay[i].AddComponent<BoxCollider2D>();

            sprite = Resources.Load<Sprite>(string.Concat(path, secondPath[i], part[i]));
            partDisplay[i].transform.position = new Vector2(pos[i].x, pos[i].y);
            spriteRenderer.sprite = sprite;
            spriteRenderer.sortingOrder = 5;

            Vector2 S = spriteRenderer.sprite.bounds.size;
            collide.size = S;

            partDisplay[i].transform.parent = parent.transform;

        }
        
    }

    public void Angry()
    {
        string eye = partDisplay[1].GetComponent<SpriteRenderer>().sprite.name;

        string path;

        switch (race)
        {
            case RACE.PUMPKIN:
                path = "pumpkin/eye/yeux_mechant";
                break;
            case RACE.DEVIL:
                path = "demon/eye/yeux_mechant";
                break;
            case RACE.SKELETON:
                path = "skeleton/eye/yeux_mechant";
                break;
            default:
                path = "";
                break;
        }

        path += eye[eye.Length - 1];


        Sprite s = Resources.Load<Sprite>(path);

        partDisplay[1].GetComponent<SpriteRenderer>().sprite = s;

        if (race == RACE.PUMPKIN)
        {
            string mouth = partDisplay[4].GetComponent<SpriteRenderer>().sprite.name;


            s = Resources.Load<Sprite>("pumpkin/mouth/bouche_mechant" + mouth[mouth.Length -1]);

            partDisplay[4].GetComponent<SpriteRenderer>().sprite = s;

        }
        isAngry = true;
    }

    public string Skeleton()
    {
        string path = "skeleton/";

        nbPart = 4;
        secondPath = new string[nbPart];
        partDisplay = new GameObject[nbPart];
        pos = new Vector2[nbPart];

        secondPath[0] = "cloth/costume";
        secondPath[1] = "eye/yeux";
        secondPath[2] = "face/tete";
        secondPath[3] = "hair/chapeau";

        part = new int[nbPart];
        part[0] = Random.Range(1, 5);

        return path;
    }

    public string Pumpkin()
	{
		string path = "pumpkin/";

        nbPart = 5;
        secondPath = new string[nbPart];
        partDisplay = new GameObject[nbPart];
        pos = new Vector2[nbPart];

        secondPath[0] = "cloth/tenu";
        secondPath[1] = "eye/yeux";
        secondPath[2] = "face/tete";
        secondPath[3] = "hair/chapeaux";
        secondPath[4] = "mouth/bouche";

        part = new int[nbPart];
        part[0] = Random.Range(1, 3);

        return path;
    }

    public string Devil()
    {
        string path = "demon/";

        nbPart = 4;
        secondPath = new string[nbPart];
        partDisplay = new GameObject[nbPart];
        pos = new Vector2[nbPart];

        secondPath[0] = "cloth/tenus";
        secondPath[1] = "eye/yeux";
        secondPath[2] = "face/tete";
        secondPath[3] = "hair/cheveux";

        part = new int[nbPart];
        part[0] = Random.Range(1, 5);

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