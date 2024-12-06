using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : ItemBase
{
    public override void SetItemCountTMP()
    {
        //AmountHolderTMP.text = "Count:" + " " + ItemAmount.ToString("0");
        base.SetItemCountTMP();
    }
    
    public override void OnItemCollect()
    {
        PlayerEvents.OnItemCollectPlayerInterractEvent?.Invoke(ItemType.Pear,ItemAmount);
    }
}
