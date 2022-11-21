using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Shop,
    Grimoire,
    Game,
}

public class GameManager : MonoBehaviour
{
    #region Attributes

    [SerializeField] uint maxMoney = 999999;
    [SerializeField] uint currentMoney = 1000;
    public CauldronScript[] cauldron = { new CauldronScript(), new CauldronScript(), new CauldronScript() };
    public TipBoxScript tipBox = new TipBoxScript();
    public bool[] potionBp = { false, false, false, false };
    public State currentState = State.Shop;

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
