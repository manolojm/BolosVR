using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;

public class Manos : MonoBehaviour {
    private List<UnityEngine.XR.InputDevice> gameControllers;
    Animator animator;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        gameControllers = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(UnityEngine.XR.InputDeviceCharacteristics.Right, gameControllers);
    }

    // Update is called once per frame
    void Update() {
        bool cierraMano = false;
        if (gameControllers.Count > 0) {

            if (gameControllers[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out cierraMano)) {
                // Apertura
                animator.SetBool("coger", cierraMano);
            } else {
                // Cierre
                animator.SetBool("coger", cierraMano);
            }
        }
    }
}