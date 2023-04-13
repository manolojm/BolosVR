using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TrigExit : MonoBehaviour
{
    public static TrigExit instance;
    [HideInInspector]
    public InfoBola currentCollider;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } 
    }

    private void OnDisable() {
        currentCollider.OnExit.Invoke();
    }
}
