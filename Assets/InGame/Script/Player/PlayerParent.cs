using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using InGame.Script.EventHolder;
using UnityEngine;

public class PlayerParent : MonoBehaviour,IInitializable
{
    private PlayerMovement _playerMovement;

    private int _tempDiceValue;

    private TileObjectHolder _tileObjectHolder;

    private PlayerDataHolder _playerDataHolder;
    private SaveSystem _saveSystem;
    private UI_PlayerData PDataUI;
    private FindClosest _findClosest;
    
    //Player data JSON path
    private readonly string _jsonFilePath =  Path.Combine(Application.dataPath, "Resources/JSONData/" + "PlayerData" + ".json");
    public void Initialize()
    {
        _tileObjectHolder = FindObjectOfType<TileObjectHolder>();
        _findClosest = new FindClosest();
        _playerMovement = new PlayerMovement(this.transform);
        _playerDataHolder = new PlayerDataHolder();
        _saveSystem = new SaveSystem();
    }

    private void DataInit()
    {
        //Existing saved data control.
        if (_saveSystem.ExistingFileControl(_playerDataHolder,_jsonFilePath))
        {
            LoadPlayerData();
            _playerMovement.OnMoveByTransform(_playerDataHolder.SavedPosition);
        }
        else
        {
            _playerMovement.OnMoveByTransform(_playerDataHolder.SavedPosition + Vector3.up);
            SavePlayerData();
        }
        
        UpdateUIData();
        
    }
    
    private void SavePlayerData() => _saveSystem.SaveData(_playerDataHolder,_jsonFilePath);
    private void LoadPlayerData() =>  _playerDataHolder = _saveSystem.LoadData(_playerDataHolder, _jsonFilePath);

    private void SetItemCountFromEvent(ItemType type, int amount)
    {
        switch (type)
        {
            case ItemType.Apple:
                _playerDataHolder.SavedAppleCount += amount;
                break;
            
            case ItemType.Pear:
                _playerDataHolder.SavedPearCount += amount;
                break;
            
            case ItemType.Strawberry:
                _playerDataHolder.SavedStrawberryCount += amount;
                break;
        }
        SavePlayerData();
    }


    private void UpdateUIData()
    {
        PlayerEvents.OnItemLoadFromDataEvent(ItemType.Apple, _playerDataHolder.SavedAppleCount);
        PlayerEvents.OnItemLoadFromDataEvent(ItemType.Pear, _playerDataHolder.SavedPearCount);
        PlayerEvents.OnItemLoadFromDataEvent(ItemType.Strawberry, _playerDataHolder.SavedStrawberryCount);
    }
    private void OnEnable()
    {
        PlayerEvents.ReadDiceValueEvent += ReadDiceInput;
        PlayerEvents.OnPlayerMovementStartEvent += PlayerMovementStarter;
        PlayerEvents.OnPlayerDataUpdateEvent += SavePlayerData;
        PlayerEvents.OnItemCollectPlayerInterractEvent += SetItemCountFromEvent;
    }

    private void Start()
    {
        Initialize();
        DataInit();
    }
    
    private void ReadDiceInput(int value)
    {
        
        _tempDiceValue += value;
        _tempDiceValue = Mathf.Min(_tempDiceValue, 12);
        
        
        Debug.Log($"Dice total = {_tempDiceValue} ");
    }
    
    public bool IsTotalDiceInputGreaterThanTileCount(int tileListCount,int totalDiceInput) =>   totalDiceInput > tileListCount ? true : false;
  

    private void PlayerMovementStarter()
    {
        Debug.Log("The player's movement has started.");
        
        _playerMovement._isMovementStart = true;

        //Create new tile list.
        List<GameObject> _tempTileList = new List<GameObject>();
        
        //Set new tile list to created tile list.
        _tempTileList = _tileObjectHolder.CreatedTileList;
        
        //this is index of to target tile value.
        int targetIndex = 0;
        
        
        //calculate the total dice input for find the end position.
        var currentIndex = _findClosest.GetNearestObjectIndex(transform.position,_tileObjectHolder.CreatedTileList);

        var total = currentIndex + _tempDiceValue;
        
        if (IsTotalDiceInputGreaterThanTileCount(_tempTileList.Count,total))
        {
            targetIndex = (total) % (_tempTileList.Count);
        }
        else
        {
            if (_tempTileList.Count == total)
            {
                targetIndex = 0;
            }
            else
            {
                targetIndex = total;
            }
            
        }
        
        Debug.Log($"_tempdice: {_tempDiceValue} , _templist :{_tempTileList.Count} , targetIndex = {targetIndex} , total : {total}");

        Debug.LogError($"Current Near {currentIndex}");
        var goingPos = _tempTileList[targetIndex ].transform.position + Vector3.up;
        
       
        _playerMovement.OnMoveByTransform(goingPos);
        
        StartCoroutine(CheckMovement(goingPos,targetIndex));
        _tempDiceValue = 0;
    }

    IEnumerator CheckMovement(Vector3 pos,int tileIndex)
    {
        while (!_playerMovement.IsMovementDone(pos))
        {
            
            yield return null;
        }
        
        Debug.Log("Player movement is done!");

        _playerDataHolder.SavedPosition = transform.position;
        TileEvents.CollectTheTileHoldedItemEvent?.Invoke(tileIndex);
        SavePlayerData();
        UIEvents.SetUIClickableEvent?.Invoke();

    }
    
    private void OnDisable()
    {
        PlayerEvents.ReadDiceValueEvent -= ReadDiceInput;
        PlayerEvents.OnPlayerMovementStartEvent -= PlayerMovementStarter;
        PlayerEvents.OnPlayerDataUpdateEvent -= SavePlayerData;
        PlayerEvents.OnItemCollectPlayerInterractEvent -= SetItemCountFromEvent;

    }

}
