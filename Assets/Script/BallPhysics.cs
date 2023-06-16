using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
[RequireComponent(typeof(Rigidbody))]
public class BallPhysics : MonoBehaviour
{
   private Rigidbody _rigidbody;
   public InputActionProperty SelectValue;
   public XRNodeState hand;
   
   public void ShutBall()
   {
      Vector3 acceleration = new Vector3();
      hand.TryGetAcceleration(out acceleration);
      Vector3 force = _rigidbody.mass * acceleration;
      _rigidbody.AddForce(force);
   }
}