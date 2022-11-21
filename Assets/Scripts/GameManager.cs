using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PotionBp
{
    Clean,
    Drunkard,
    Relaxation,
    Luminescence,
    Spicy,
    Horned,
    Super,
    Strawberry,
    Gamer,
    Graphic,
    Toad,
    Heart,
    Sleep,
    PotionBpNb
}
public class GameManager : MonoBehaviour
{
    #region Attributes

    [SerializeField] uint maxMoney = 99999;
    [SerializeField] uint currentMoney = 5000;
    public CauldronScript[] cauldron = { new CauldronScript(), new CauldronScript(), new CauldronScript() };
    public TipBoxScript tipBox = new TipBoxScript();
    public bool[] Bp = new bool[(int)PotionBp.PotionBpNb];
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

    private void Start()
    {
        cauldron[0].IsAvailable = true;
        for(int i = 0; i < (int)PotionBp.PotionBpNb; i++)
            Bp[i] = false;
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
