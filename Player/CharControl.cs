using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharControl : MonoBehaviour
{
    internal static int moneySouls;
    //основные харатеристики
    internal static float run;
    internal static int maxHp;
    internal static int hp;
    internal static float ShootSpeed;
    internal static int damage;
    internal static float ShootRate;
    //основные харатеристики

    //бафы/дебафы
    internal static float speedup;
    internal static int hpUp;
    internal static int Armor;

    internal static float damageup;
    internal static int Poison;
    internal static int Fire;
    internal static float Ice;
    internal static float multiShoot;

    internal static bool AutoShoot;
    internal static bool invisibility;
    internal static bool UnTouchable;
    //бафы/дебафы
    // инвентарь
    internal static List<GameObject> Inventory1Use;
    internal static List<GameObject> InventoryMoreUse;
    internal static List<GameObject> InventoryPassive;
    // инвентарь
    public Image HPBar;
    public Text HpCount;
    public int HpCurr;
    public int HpMaxCurr;
    public Text Money;
    private int MoneyCur;

    internal static bool NearNpc;
    internal static bool NearItem;
    internal static int PoisonDmg(int i, int PoisLvl)
    {
        i = i - PoisLvl;
        return i;
    }

    internal static int FireDmg(int i, int FireLvl)
    {

        return i;
    }

    private void Start()
    {
        HPBar.fillAmount = hp*1f / maxHp;
        HpCount.text = hp.ToString();
        HpCurr = hp;
        HpMaxCurr = maxHp;
        Money.text = moneySouls.ToString();
        MoneyCur = moneySouls;
    }
    private void Update()
    {
        if (hp != HpCurr)
        {
            if (hp <= maxHp)
            {
                HPBar.fillAmount = (hp * 1f / maxHp*1f);
                HpCount.text = hp.ToString();
            }
            
            HpCurr = hp;
        }
        if (maxHp != HpMaxCurr)
        {
            if (hp <= maxHp)
            {
                HPBar.fillAmount = hp * 1f / maxHp;
            }
            HpMaxCurr = maxHp;
        }
        if (moneySouls != MoneyCur)
        {
            Money.text = moneySouls.ToString();
            MoneyCur = moneySouls;
        }
    }
}
