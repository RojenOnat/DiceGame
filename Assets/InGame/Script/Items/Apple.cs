using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : ItemBase
{
    public override void SetItemCountTMP()
    {
        base.SetItemCountTMP();
    }

    public override void OnItemCollect()
    {
        PlayerEvents.OnItemCollectPlayerInterractEvent?.Invoke(ItemType.Apple,ItemAmount);
    }
}
