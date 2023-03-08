using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(InputActionProperty))]
public abstract class RequeredInputActions
{
   public InputActionProperty Trigger;
   public InputActionProperty Grip;
   public InputActionProperty Stick;
   public InputActionProperty ButtonUp;
   public InputActionProperty ButtonDown;
}