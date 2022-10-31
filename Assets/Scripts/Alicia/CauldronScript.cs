using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronScript : MonoBehaviour
{
    #region Attributes

    bool isAvailable = false;
    bool upgradeSpeed = false;
    bool upgradeTime = false;

    #endregion

    public bool UpgradeSpeed { get => upgradeSpeed; set => upgradeSpeed = value; }
    public bool UpgradeTime { get => upgradeTime; set => upgradeTime = value; }

    #region IsAvailableInGame
    public void CauldronIsAvailable()
    {
        isAvailable = true;
    }
    public void SpeedUpgradeIsAvailable()
    {
        upgradeSpeed = true;
    }
    public void TimeUpgradeIsAvailable()
    {
        upgradeTime = true;
    }
    #endregion
}
