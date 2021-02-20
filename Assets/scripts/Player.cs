using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int Money = 10000000;
    
    public int money
    {
        get
        {
            return Money;
        }
        set
        {
            Money = value;

        }
    }
}
