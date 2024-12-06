using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceParent : MonoBehaviour,IInitializable
{
    private DiceMovement _diceMovement;

    [Tooltip("The Rigidbody of dice")]
    public Rigidbody DiceRigidbody;

    [Tooltip("The throwing force it has while rolling the dice.")]
    public float DiceForce;
    
    [Tooltip("The throwing force it has while rolling the dice.")]
    public float DiceAngularForce;

    private bool _controlTHeDiceVelocity = false;

    [SerializeField]private DiceIDHolder _diceIDHolder;

    public List<Transform> CenterOffMassPositionList;

    private void Awake()
    {
        Initialize();
    }   

    private void OnEnable()
    {
        DiceEvents.RollingDiceEvent += RollDice;
        DiceEvents.SetCenterOfMassByDiceIDEvent += MasSetterListener;
    }

    private void MasSetterListener(int diceId, int value)
    {
        if (!_diceIDHolder.IsIDMathced(diceId))  return;
        
        //Since we are using a list, we take one less than the entered value.
        int temp = value - 1;
        
        //Debug.Log($"Dice Id : {diceId} , readed value from event : {value}");
        _diceMovement.SetCenterOffMass(temp);
    }

    private void RollDice()
    {
        _diceMovement.SetDiceForce(direction: Vector3.up , force: DiceForce , forceMode: ForceMode.Acceleration);
        _diceMovement.SetDiceAngularVelocity(direction: Vector3.one, force: DiceAngularForce);

        StartCoroutine(DelayForMovementCheck());
        StartCoroutine(DiceMovementChecker());
       // Debug.Log("Rolling Dice");
    }
    
    private void OnDisable()
    {
        DiceEvents.RollingDiceEvent -= RollDice;
        DiceEvents.SetCenterOfMassByDiceIDEvent -= MasSetterListener;

    }


    public void Initialize()
    {
        _diceMovement = new DiceMovement(_diceRb: DiceRigidbody,CenterOffMassPositionList);

    }

    private IEnumerator DelayForMovementCheck()
    {
        yield return new WaitForSeconds(0.2f);
        
        _controlTHeDiceVelocity = true;
    }

    private IEnumerator DiceMovementChecker()
    {
        yield return new WaitUntil(() => _controlTHeDiceVelocity);
        
        while (_diceMovement.GetCurrentVelocityMagnitude() > 0)
        {

            yield return null;
        }
        
        DiceEvents.DiceMovementListener?.Invoke();
        
        //Reset the dice bool status.
        _controlTHeDiceVelocity = false;
        _diceMovement.IsMovementDone = true;
        
    }
}



[System.Serializable]
public class DiceIDHolder
{
    public int CurrentDiceID;

    public bool IsIDMathced(int id) => CurrentDiceID == id ? true : false;
}
