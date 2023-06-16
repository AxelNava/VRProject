using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class HandGrabPose : MonoBehaviour
{
   public HandData rightHandPose;
   private Vector3 startingHandPosition;
   private Vector3 finalHandPosition;
   private Quaternion startHandrotation;
   private Quaternion finalHandRotation;

   private Quaternion[] startingFingerRotations;
   private Quaternion[] finalFingerRotations;

   private void Start()
   {
      XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
      grabInteractable.selectEntered.AddListener(SetUpPose);
      grabInteractable.selectExited.AddListener(UnsetPose);
      rightHandPose.gameObject.SetActive(false);
   }

   public void SetUpPose(BaseInteractionEventArgs args)
   {
      if (args.interactorObject is XRDirectInteractor)
      {
         HandData handData = args.interactorObject.transform.GetComponentInChildren<HandData>();
         handData.animator.enabled = false;
         SetHandDataValues(handData, rightHandPose);
         SetHandData(handData, finalHandPosition, finalHandRotation, finalFingerRotations);
      }
   }

   public void SetHandDataValues(HandData h1, HandData h2)
   {
      Vector3 localPosition = h1.root.localPosition;
      Vector3 localScale = h1.root.localScale;
      startingHandPosition = new Vector3(localPosition.x / localScale.x,
         localPosition.y / localScale.y,
         localPosition.z / localScale.z);

      Vector3 localPositionFinal = h2.root.localPosition;
      Vector3 localScaleFinal = h2.root.localScale;
      finalHandPosition = new Vector3(localPositionFinal.x / localScaleFinal.x,
         localPositionFinal.y / localScaleFinal.y,
         localPositionFinal.z / localScaleFinal.z);


      startHandrotation = h1.root.localRotation;
      finalHandRotation = h2.root.localRotation;

      startingFingerRotations = new Quaternion[h1.fingerBonesTransform.Length];
      finalFingerRotations = new Quaternion[h1.fingerBonesTransform.Length];

      for (var i = 0; i < startingFingerRotations.Length; i++)
      {
         startingFingerRotations[i] = h1.fingerBonesTransform[i].localRotation;
         finalFingerRotations[i] = h2.fingerBonesTransform[i].localRotation;
      }
   }

   public void SetHandData(HandData h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesQuaternion)
   {
      h.root.localPosition = newPosition;
      h.root.localRotation = newRotation;
      for (int i = 0; i < newBonesQuaternion.Length; i++)
      {
         h.fingerBonesTransform[i].localRotation = newBonesQuaternion[i];
      }
   }

   public void UnsetPose(BaseInteractionEventArgs args)
   {
      if (args.interactorObject is XRDirectInteractor)
      {
         HandData handData = args.interactorObject.transform.GetComponentInChildren<HandData>();
         handData.animator.enabled = true;
         
         SetHandData(handData, startingHandPosition, startHandrotation, startingFingerRotations);
      }
   }
}