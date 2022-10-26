using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.U2D;
using System.IO;

enum RACE
{
	PUMPKIN,
	MUSHROOM,
	DEVIL,
	SKELETON,
	RACENB
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
	public int nbPart;
	#endregion

	public CustomerClass ()
	{
		askedPotion = new Potion();

		int size = Random.Range(1, 4);

		timerMax = 20 * size;
		timer = timerMax;
		askedPotion.ingredient = new List<INGREDIENT>();

        for (int i = 0; i < size; i++)
		{
			askedPotion.ingredient.Add((INGREDIENT)Random.Range(0, (int)INGREDIENT.INGREDIENTNB));
		}

		askedPotion.rune = (RUNES)Random.Range(0, (int)RUNES.RUNENB);

		askedPotion.price = 100 + 10 * size + 10 * (int)askedPotion.rune;

		race = (RACE)Random.Range(0, (int)RACE.RACENB);

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


    public void DiplayCustomer()
	{
		string path;

        switch (race)
		{
            //case RACE.PUMPKIN:
            //    path = Pumpkin();
            //    break;
            //case RACE.MUSHROOM:
            //    path = Mushroom();
            //    break;
            //case RACE.DEVIL:
            //    path = Devil();
            //    break;
            //case RACE.SKELETON:
            //    path = Skeleton();
            //    break;
            default:
                path = Devil();
                break;
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

    public string Mushroom()
	{
        string path = "mushroom/";

        nbPart = 4;
        secondPath = new string[nbPart];
        partDisplay = new GameObject[nbPart];
        pos = new Vector2[nbPart];

        secondPath[0] = "cloth/corp";
        secondPath[1] = "eye/yeux";
        secondPath[2] = "mouth/bouche";
        secondPath[3] = "hair/cheveux";

        part = new int[nbPart];
        part[0] = Random.Range(1, 3);

        return path;
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
        secondPath[2] = "mouth/bouche";
        secondPath[3] = "hair/tige";
        secondPath[4] = "face/tete";

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
        part[0] = Random.Range(1, 3);

        return path;
    }

    public void Update()
	{
		timer -= Time.deltaTime;
	}

	#endregion
}