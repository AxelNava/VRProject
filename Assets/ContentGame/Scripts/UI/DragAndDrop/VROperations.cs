using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewBehaviourScript : MonoBehaviour
{
    public UnityEvent onEnter;
    public UnityEvent onExit;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
       // TrigExit.instance.currentCollider = GetComponent<VR>();
    }
}
