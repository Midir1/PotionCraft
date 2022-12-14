using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PotionBp
{
    Heart,
    Champ,
    Clean,
    Drunkard,
    Gamer,
    Graphic,
    Horned,
    Luminescence,
    Sleep,
    Spicy,
    Strawberry,
    Sea,
    Toad,
    PotionBpNb
}

public enum ShopState
{
    BANK,
    SHOP
}

public struct CauldronShop
{
    public bool isAvailable;
    public bool upgradeSpeed;
    public bool upgradeTime;
}
public class GameManager : MonoBehaviour
{
    #region Attributes

    [SerializeField] uint maxMoney = 99999;
    [SerializeField] uint currentMoney = 8000;
    public CauldronShop[] cauldron = new CauldronShop[3];
    public ShopState shopState = ShopState.SHOP;
    public bool tipIsAvailable = false;
    public bool bellIsAvailable = false;
    public bool[] Bp = new bool[(int)PotionBp.PotionBpNb];
    public int[] potionPrice = new int[(int)PotionBp.PotionBpNb];
    public bool tutoState = true;
    #endregion

    #region getters/setters
    public uint CurrentMoney { get => currentMoney; }
    public uint MaxMoney { get => maxMoney; }

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("@GameManager");
                DontDestroyOnLoad(go);
                instance = go.AddComponent<GameManager>();
            }
            return instance;
        }
    }
    #endregion
    
    private void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            cauldron[i].isAvailable = false;
            cauldron[i].upgradeSpeed = false;
            cauldron[i].upgradeTime = false;
        }
        cauldron[0].isAvailable = true;
        for (int i = 0; i < (int)PotionBp.PotionBpNb; i++)
            Bp[i] = false;
        Bp[(int)PotionBp.Heart] = true;
        Bp[(int)PotionBp.Sleep] = true;
        Bp[(int)PotionBp.Gamer] = true;
        potionPrice[(int)PotionBp.Clean] = 100;
        potionPrice[(int)PotionBp.Drunkard] = 100;
        potionPrice[(int)PotionBp.Luminescence] = 250;
        potionPrice[(int)PotionBp.Champ] = 250;
        potionPrice[(int)PotionBp.Horned] = 500;
        potionPrice[(int)PotionBp.Spicy] = 500;
        potionPrice[(int)PotionBp.Sea] = 750;
        potionPrice[(int)PotionBp.Strawberry] = 750;
        potionPrice[(int)PotionBp.Toad] = 1000;
        potionPrice[(int)PotionBp.Graphic] = 1500;
        potionPrice[(int)PotionBp.Heart] = 100;
        potionPrice[(int)PotionBp.Gamer] = 100;
        potionPrice[(int)PotionBp.Sleep] = 100;


    }

    /// <summary>
    /// money to add to wallet
    /// </summary>
    /// <param name="money">money to add to wallet, absolute value</param>
    public void AddMoney(uint money)
    {
        currentMoney += money;
        if (currentMoney > maxMoney)
            currentMoney = maxMoney;

    }
    /// <summary>
    /// money to withdraw from wallet
    /// </summary>
    /// <param name="money">money to withdraw from wallet, absolute value</param>
    public void RemoveMoney(uint money)
    {
        currentMoney -= money;
        if (currentMoney < 0)
            currentMoney = 0;

    }
}
