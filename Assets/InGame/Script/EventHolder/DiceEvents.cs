using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// It holds events related to the dice.
/// </summary>
public static class DiceEvents
{
    public static Action RollingDiceEvent { get; set; }
    
    public static Action<int,int> SetCenterOfMassByDiceIDEvent { get; set; }

    public static Action DiceMovementListener;
}
