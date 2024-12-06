using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public abstract class ItemBase : MonoBehaviour
{
   public int ItemAmount;
   public TextMeshProUGUI AmountHolderTMP;
   public ItemType IType;
   public virtual void SetItemCountTMP()
   {
       AmountHolderTMP.text = "Count:" + " " + ItemAmount.ToString("0");
   }

   public abstract void OnItemCollect();


}
