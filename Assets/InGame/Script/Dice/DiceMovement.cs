using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceMovement
{
   private Rigidbody _diceRigidbody;

   public bool IsMovementDone { get; set; }

   private List<Transform> _diceCenterOfMassPositionList;

   public DiceMovement(Rigidbody _diceRb,List<Transform> positionsList)
   {
      _diceCenterOfMassPositionList = new List<Transform>();
      
      _diceRigidbody = _diceRb;

      _diceCenterOfMassPositionList = positionsList;
   }

   /// <summary>
   /// Set dice force to rigidbody
   /// </summary>
   /// <param name="direction"></param>
   /// <param name="force"></param>
   /// <param name="forceMode"></param>
   public void SetDiceForce(Vector3 direction, float force, ForceMode forceMode)
   {
      _diceRigidbody.AddForce(direction * force , forceMode );
      IsMovementDone = false;
   }

   /// <summary>
   /// Set dice angular velocity
   /// </summary>
   /// <param name="direction"></param>
   /// <param name="force"></param>
   public void SetDiceAngularVelocity(Vector3 direction, float force)
   {
      _diceRigidbody.angularVelocity = direction * force;
   }
   
   
   /// <summary>
   /// It gives the magnitude of the velocity in the Rigidbody.
   /// </summary>
   /// <returns></returns>
   public float GetCurrentVelocityMagnitude() => _diceRigidbody.velocity.magnitude;


   /// <summary>
   /// The `center of mass` value of the Rigidbody is reassigned based on the given index of the list.
   /// </summary>
   /// <param name="index"></param>
   public void SetCenterOffMass(int index)
   {
      _diceRigidbody.centerOfMass = _diceCenterOfMassPositionList[index].localPosition;
   }
}


