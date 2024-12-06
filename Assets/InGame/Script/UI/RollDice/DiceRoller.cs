using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour,IAvailability
{
   private void OnEnable()
   {
      UIEvents.SetUIClickableEvent += SetAvailability;
   }

   public void RollDiceOnClick()
   {
      DiceEvents.RollingDiceEvent?.Invoke();
      UIEvents.SetUIClickableEvent?.Invoke();
   }


   public void SetAvailability()
   {
      for (int i = 0; i < transform.childCount; i++)
      {
         if(transform.GetChild(i).gameObject.activeSelf) transform.GetChild(i).gameObject.SetActive(false);
         else
            transform.GetChild(i).gameObject.SetActive(true);
      }
   }

   private void OnDisable()
   {
      UIEvents.SetUIClickableEvent -= SetAvailability;
   }
}
