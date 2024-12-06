using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PlayerData : MonoBehaviour,IInitializable
{
    public TextMeshProUGUI AppleDataTMP;
    public TextMeshProUGUI PearDataTMP;
    public TextMeshProUGUI StrawberryDataTMP;

    private int _temp = 0;

    private StringToIntConverter _converter;

    private void OnEnable()
    {
        PlayerEvents.OnItemCollectPlayerInterractEvent += SetAllTMPEventListener;
        PlayerEvents.OnItemLoadFromDataEvent += LoadDataFromEvent;
        
        Initialize();
    }

    private void LoadDataFromEvent(ItemType type, int amount)
    {
        SetAllTMPEventListener(type, amount);
    }
    
    private void SetAllTMPEventListener(ItemType type, int amount)
    {

        switch (type)
        {
            case ItemType.Apple:
                Calculator(AppleDataTMP,amount);
                break;
            
            case ItemType.Pear:
                Calculator(PearDataTMP,amount);
                break;
            
            case ItemType.Strawberry:
                Calculator(StrawberryDataTMP,amount);
                break;
        }
    }
   

    private void Calculator(TextMeshProUGUI s, int amount)
    {
        var current = _converter.ConvertStringToInt(s.text);
        var total = current + amount;

        s.text = total.ToString("0");
    }

    public void Initialize()
    {
        _converter = new StringToIntConverter();
    }

    private void OnDisable()
    {
        PlayerEvents.OnItemCollectPlayerInterractEvent -= SetAllTMPEventListener;
    }
}
