using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
   
   [Tooltip("The number of dice in the game")]public int InGameDiceCount;

   private int _tempValue = 0;

   private void OnEnable()
   {
      DiceEvents.DiceMovementListener += DiceMovementEndListener;
   }

   public void DiceMovementEndListener()
   {
      _tempValue++;

      if (_tempValue == InGameDiceCount)
      {
         Debug.Log("All dice movement methods are successful");
         
         //Player can move after dice movement is done.
         PlayerEvents.OnPlayerMovementStartEvent?.Invoke();
         _tempValue = 0;
      }
   }
}
