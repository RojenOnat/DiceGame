using System;using System.Collections;
using System.Collections.Generic;
using System.IO;
using InGame.Script.EventHolder;
using UnityEngine;
using UnityEngine.Serialization;

public class MapDataHolder : MonoBehaviour,IInitializable
{
    //It contains the tile data.
    public TileDataHolder TData;
    
    private readonly SaveSystem _saveSystem = new SaveSystem();
    
    //Map data JSON path
    private readonly string _jsonFilePath =  Path.Combine(Application.dataPath, "Resources/JSONData/" + "MapData" + ".json");

    //A container script to get prefabs.
    public PrefabContainer PContainer;
    
     private TileObjectHolder _tileobjectHolder;
    
    public void Initialize()
    {
        _tileobjectHolder = FindObjectOfType<TileObjectHolder>();
        
        
    }
    
    private void OnEnable()
    {
        TileEvents.CollectTheTileHoldedItemEvent += ReOrganizeTileDataFromEvent;
    }


    private void Awake()
    {
        Initialize();
        DataInit();
    }

    private void Start()
    {
        InstantiateTilesBasedOnData();
    }
    
    
    private void ReOrganizeTileDataFromEvent(int tileIndex)
    {
        //Debug.LogError(tileIndex);
        TData.CollectItemControl(tileIndex);
        
        _saveSystem.SaveData(TData,_jsonFilePath);
        
        //Debug.Log("Data Updated!");
    }
    
    private void DataInit()
    {
        //Existing saved data control.
        if (_saveSystem.ExistingFileControl(TData,_jsonFilePath))
        {
            TData = _saveSystem.LoadData(TData, _jsonFilePath);
        }
        else
        {
            _saveSystem.SaveData(TData,_jsonFilePath);
        }
    }

    private void CreateElements(TileParent tileParent,int dataListIndex,Vector3 tilePosition)
    {
        //Burayı daha düzenli yapabilirdim...

        switch (TData.ElementsDataList[dataListIndex].TileHoldedType)
        {
            case  ItemType.Apple:
                
                //Apple position.
                var _tempItemPos = new Vector3(0, 1, 0) + tilePosition;

                Apple apple = Instantiate(PContainer.ApplePrefab, _tempItemPos, Quaternion.identity).GetComponent<Apple>();
                apple.ItemAmount = TData.ElementsDataList[dataListIndex].ElementsAmount;
                apple.SetItemCountTMP();
                apple.IType = ItemType.Apple;
                
                tileParent.HoldedItem = apple.gameObject;
                //Debug.Log("Apple created!");
                break;
            
            case ItemType.Pear:
                //Pear position.
                _tempItemPos = new Vector3(0, 1, 0) + tilePosition;

                Pear pear = Instantiate(PContainer.PearPrefab, _tempItemPos, Quaternion.identity).GetComponent<Pear>();
                pear.ItemAmount = TData.ElementsDataList[dataListIndex].ElementsAmount;
                pear.SetItemCountTMP();
                pear.IType = ItemType.Pear;

                tileParent.HoldedItem = pear.gameObject;
                //Debug.Log("Pear created!");
                break;
            
            case ItemType.Strawberry:
                _tempItemPos = new Vector3(0, 1, 0) + tilePosition;

                Strawberry strawberry = Instantiate(PContainer.StrawberryPrefab, _tempItemPos, Quaternion.identity).GetComponent<Strawberry>();
                strawberry.ItemAmount = TData.ElementsDataList[dataListIndex].ElementsAmount;
                strawberry.SetItemCountTMP();
                strawberry.IType = ItemType.Strawberry;


                tileParent.HoldedItem = strawberry.gameObject;
                //Debug.Log("Strawberry created!");
                break;
            
            case ItemType.Empty:
                //Debug.Log("Empty tile created.");

                break;
        }
    }
    /// <summary>
    /// It creates the tile objects and other elements with the data coming from the source.
    /// </summary>
    private void InstantiateTilesBasedOnData()
    {
        //We are checking the number of elements in the Data list.
        if (TData.GetElementsDataListCount() == 0)
        {
            Debug.LogAssertion("There are no elements in the TData list. ");
            return;
        }

        for (int i = 0; i < TData.ElementsDataList.Count; i++)
        {
            
            //The creating tile object of positions.
            Vector3 _tilePos = new Vector3((i * 1.5f), 0, 0);
            
            //The creating tile object.
            GameObject tempTile = Instantiate(PContainer.TilePrefab, _tilePos, Quaternion.identity);
            
            //The temp item position.
            Vector3 _tempItemPos = Vector3.zero;
            
            //Add created tile to list
            _tileobjectHolder.AddTileToList(tempTile);
            
            //Set tile index
            tempTile.GetComponent<TileParent>().TileIndex = i;
            
            //We are checking if there was an incorrect input, and here we are performing the process of creating elements on the tile.
            if (TData.ElementsDataList[i].ElementsAmount>0)
            {
                #region Element Selection

                CreateElements(tempTile.GetComponent<TileParent>(),i, _tilePos);

                #endregion
            }
           
        }
        
    }

    private void OnDisable()
    {
            TileEvents.CollectTheTileHoldedItemEvent -= ReOrganizeTileDataFromEvent;
    }
}



/// <summary>
/// The object type that the tile will hold
/// </summary>
/*public enum TileElementsType
{
    Apple,
    Pear,
    Strawberry,
    Empty
}*/

/// <summary>
/// Data of the tile elemnts
/// </summary>
[System.Serializable]
public class ElementsTypeHolder
{
    //It holds the type of the element.
    public ItemType TileHoldedType;
    
    //Amount of element.
    public int ElementsAmount;

    //Check current type is empty or not.
    public bool IsTypeEmpty() => TileHoldedType == ItemType.Empty ? true : false;
}


/// <summary>
/// A class that holds the count and type of the elements.
/// </summary>
[System.Serializable]
public class TileDataHolder
{
    //A list that holds the number and type of all elements.
    public List<ElementsTypeHolder> ElementsDataList;

    public int GetElementsDataListCount() => ElementsDataList.Count;

    public void CollectItemControl(int indexOfTile)
    {
        if (ElementsDataList[indexOfTile].ElementsAmount>0)
        {
            ElementsDataList[indexOfTile].TileHoldedType = ItemType.Empty;
            ElementsDataList[indexOfTile].ElementsAmount = 0;
            
            Debug.Log("Object is collected.");
        }
    }
}

