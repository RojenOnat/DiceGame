using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerEvents
{
   public static Action<int> ReadDiceValueEvent;

   public static Action OnPlayerMovementStartEvent;

   public static Action<ItemType, int> OnItemCollectPlayerInterractEvent;
   
   public static Action<ItemType, int> OnItemLoadFromDataEvent;

   public static Action OnPlayerDataUpdateEvent;
}
