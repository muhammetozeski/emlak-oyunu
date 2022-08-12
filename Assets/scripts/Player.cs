using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    [SerializeField] string Name;
    //money ↓
    [SerializeField] private TextMeshProUGUI MoneyUIText;
    private const string moneyText = "Money:\n";
    [SerializeField] private int Money = 10000000;
    public int money
    {
        get
        {
            return Money;
        }
        set
        {
            Money = value;
            MoneyUIText.text = moneyText + putDot(value);
        }
    }
    //money ↑

    string putDot(int price)//bu kodları bir kütüphane yapıp birleştir sonra
    {
        string i = "";
        int i2 = ("" + price).Length % 3;
        if (i2 != 0)
        {
            for (int i3 = 0; i3 < i2; i3++)
            {
                i += ("" + price)[i3];
            }
            i += ".";
        }
        int i4 = 1;
        for (; i2 < ("" + price).Length; i2++, i4++)
        {
            i += ("" + price)[i2];
            if (i4 == 3 && i2 != ("" + price).Length - 1)
            {
                i += ".";
                i4 = 0;
            }
        }
        return i;
    }
}
