using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Text balance;
    public Text[] price;
    public Button[] purchase;

    public static int[] upgradeCost = new int[] { 200, 100, 100 };
    public static int[] upgradeLevel = new int[] { 0, 0, 0 };
    public static int[] maxLevel = new int[] { 1, 10, 10 };

    private void Start()
    {
        UpdateMenu();
    }

    public void UpdateMenu()
    {
        balance.text = $"Balance: ${PlayerInfo.playerBalance}";
        for (int i = 0; i < price.Length; i++)
        {
            if (upgradeLevel[i] < maxLevel[i])
            {
                price[i].text = $"${upgradeCost[i]}";
            }
            else
            {
                price[i].text = "Max";
            }
        }
    }

    void PurchaseUpgrade(int upgrade)
    {
        if (PlayerInfo.playerBalance >= upgradeCost[upgrade] && upgradeLevel[upgrade] < maxLevel[upgrade])
        {
            PlayerInfo.playerBalance -= upgradeCost[upgrade];
            upgradeLevel[upgrade]++;
            if (upgradeLevel[upgrade] != maxLevel[upgrade])
            {
                upgradeCost[upgrade] += 100;
            }
        }

        UpdateMenu();
    }

    public void FullAuto()
    {
        PurchaseUpgrade(0);
    }

    public void Range()
    {
        PurchaseUpgrade(1);
    }

    public void FireRate()
    {
        PurchaseUpgrade(2);
    }
}
