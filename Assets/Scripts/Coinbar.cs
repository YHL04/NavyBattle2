using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coinbar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxCoin(int coin)
    {
        slider.maxValue = coin;
        slider.value = 0;
    }

    public void SetCoin(int coin)
    {
        slider.value = coin;
    }
}
