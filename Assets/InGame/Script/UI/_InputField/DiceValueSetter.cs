using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DiceValueSetter : MonoBehaviour,IInitializable,IAvailability
{
    //public TextMeshProUGUI DiceCounterTmp;
    public TMP_InputField DiceCounterTmp;

    private StringToIntConverter _converter;
    private IntController _intController;

    private void OnEnable()
    {
        UIEvents.SetUIClickableEvent += SetAvailability;
        Initialize();
    }

    public void SetInputDoneOnClick(int buttonId)
    {
        string s = DiceCounterTmp.text;
        
        int diceValue = _converter.ConvertStringToInt(s);
        if (diceValue > 6)
        {
            Debug.LogAssertion("Incorrect Input!");
            return;
        }
        Debug.Log($"Current dice value: {diceValue}"); 
        
        DiceEvents.SetCenterOfMassByDiceIDEvent.Invoke(buttonId,diceValue);
        PlayerEvents.ReadDiceValueEvent?.Invoke(diceValue);
    }

    public void Initialize()
    {
        _converter = new StringToIntConverter();
        _intController = new IntController();
    }

    public void SetAvailability()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(true);

            }
            
        }
    }
    
    
    private void OnDisable()
    { 
        UIEvents.SetUIClickableEvent -= SetAvailability;
    }

}
