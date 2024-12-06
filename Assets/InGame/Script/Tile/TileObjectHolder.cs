using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObjectHolder : MonoBehaviour
{
   public List<GameObject> CreatedTileList;


   public void AddTileToList(GameObject tile) => CreatedTileList.Add(tile);
}


