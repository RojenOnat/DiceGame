using System;
using System.Collections;
using System.Collections.Generic;
using InGame.Script.EventHolder;
using UnityEngine;


public class TileParent : MonoBehaviour
{
    public int TileIndex { get; set; }
    public GameObject HoldedItem { get; set; }
    
    public int ItemCount { get; set; }

    private void OnEnable()
    {
        TileEvents.CollectTheTileHoldedItemEvent += CollectTheTileHoldedItem;
    }

    private void CollectTheTileHoldedItem(int tileIndex)
    {
        if(tileIndex != TileIndex) return;

        if (HoldedItem != null)
        {
            HoldedItem.GetComponent<ItemBase>().OnItemCollect();
            HoldedItem.SetActive(false);
        }
    }

    private void OnDisable()
    {
        TileEvents.CollectTheTileHoldedItemEvent -= CollectTheTileHoldedItem;
    }
}
