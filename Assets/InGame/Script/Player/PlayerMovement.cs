using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
   private Transform _movedTransform;
   public bool _isMovementEnd { get; set; }
   public bool _isMovementStart { get; set; }
   
   public PlayerMovement(Transform movedObject)
   {
      _isMovementStart = false;
      _isMovementEnd = false;
      _movedTransform = movedObject;
   }

   public void OnMoveByTransform(Vector3 position)
   {
      _isMovementStart = true;
      _movedTransform.position = position;
   }

   public bool IsMovementDone(Vector3 position) => _movedTransform.position == position ? true : false;
   

}
