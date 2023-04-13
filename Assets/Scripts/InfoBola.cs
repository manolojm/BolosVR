using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InfoBola : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    private void OnTriggerEnter(Collider other) {
        TrigExit.instance.currentCollider = GetComponent<InfoBola>();
        OnEnter.Invoke();
    }
}
