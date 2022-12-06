using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int maxIngredients;

    public List<Item> ingredients;

    public bool isBrewing;
    public bool isBurning;

    [SerializeField] private List<Recipe> recipes;
    [SerializeField] private List<GameObject> potions;
    [SerializeField] private Transform potionParent;
    [SerializeField] private GameObject drawPanel;
    [SerializeField] private GameObject inputManager;
    [SerializeField] private float upgradeBrewingSpeed;
    [SerializeField] private float upgradeBurningSpeed;
    [SerializeField] private int timeToBurn;
    [SerializeField] private Image hourglass;
    [SerializeField] private List<Sprite> hourglassSprites;

    private int potionIndex = -1;
    private float timerBrewing;
    private float timerBurning;
    private int cauldronIndex = -1;
    private int nbChild = 0;

    private GameManager manager;

    private void Start()
    {
        switch (this.name)
        {
            case "Red Cauldron": cauldronIndex = 0; break;
            case "Blue Cauldron": cauldronIndex = 1; break;
            case "Green Cauldron": cauldronIndex = 2; break;
        }

        manager = GameManager.Instance;

        //Reset craft potion
        for (int i = 0; i < recipes.Count; i++)
        {
            recipes[i].isActive = manager.Bp[i];
        }

        nbChild = transform.childCount;
    }

    private void Update()
    {
        if (potionIndex != -1 && isBrewing)
        {
            timerBrewing += Time.deltaTime;
            int isCauldronUpgraded = Convert.ToInt32(GameManager.Instance.cauldron[cauldronIndex].upgradeTime);

            if (timerBrewing > (recipes[potionIndex].timeToWait - upgradeBrewingSpeed * isCauldronUpgraded)) CraftPotion();
        }

        //Reset if potion is dragged
        if (transform.childCount <= nbChild)
        {
            isBurning = false;
            hourglass.sprite = hourglassSprites[0];
            timerBurning = 0;
        }

        if (isBurning)
        {
            timerBurning += Time.deltaTime;
            int isCauldronUpgraded = Convert.ToInt32(GameManager.Instance.cauldron[cauldronIndex].upgradeSpeed);

            if (isCauldronUpgraded == 1)
            {
                if ((int)timerBurning > 0)
                {
                    hourglass.sprite = hourglassSprites[timeToBurn + (int)upgradeBurningSpeed / ((int)timerBurning % 5)];
                }
                else
                {
                    hourglass.sprite = hourglassSprites[0];
                }
            }
            else
            {
                if ((int)timerBurning > 0 && (int)timerBurning < timeToBurn)
                {
                    hourglass.sprite = hourglassSprites[(int)timerBurning / (timeToBurn / 4)];
                }
                else
                {
                    hourglass.sprite = hourglassSprites[0];
                }
            }

            if (timerBurning > (timeToBurn - upgradeBurningSpeed * isCauldronUpgraded)) BurnPotion();
        }
    }

    //Recipes and Potions Needs to be in the same order in the inspector to give the provided result
    public void CheckPotionExist()
    {
        for (var i = 0; i < recipes.Count; i++)
        {
            var recipe = recipes[i];

            Item recipeIngredient1 = recipe.ingredients[0];
            Item recipeIngredient2 = recipe.ingredients[1];
            Item recipeIngredient3 = recipe.ingredients[2];

            for (var index = 0; index < recipe.ingredients.Count; index++)
            {
                if (ingredients[index] == recipeIngredient1) recipeIngredient1 = null;
                else if (ingredients[index] == recipeIngredient2) recipeIngredient2 = null;
                else if (ingredients[index] == recipeIngredient3) recipeIngredient3 = null;
                else break;

                if (!recipe.isActive) break;

                if (index == recipe.ingredients.Count - 1)
                {
                    drawPanel.SetActive(true);
                    inputManager.SetActive(true);

                    InputPaternRecognition inputPaternRecognition = inputManager.GetComponent<InputPaternRecognition>();
                    inputPaternRecognition.SetPatern(recipe.rune);

                    inputPaternRecognition.inventory = this;

                    potionIndex = i;

                    return;
                }
            }
        }

        ingredients.Clear();
    }

    public void BeginCraftPotion()
    {
        drawPanel.SetActive(false);
        inputManager.SetActive(false);

        isBrewing = true;
    }

    private void CraftPotion()
    {
        isBrewing = false;
        isBurning = true;
        timerBrewing = 0.0f;

        ingredients.Clear();
        potions[potionIndex].GetComponent<BoxCollider2D>().size = new Vector2(100, 100);
        Instantiate(potions[potionIndex], potionParent);

        potionIndex = -1;
    }

    private void BurnPotion()
    {
        Transform burnedPotion = transform.GetChild(nbChild);
        isBurning = false;
        timerBurning = 0.0f;
        hourglass.sprite = hourglassSprites[4];
        Destroy(burnedPotion.gameObject);
    }
}