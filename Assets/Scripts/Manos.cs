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
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(UnityEngine.XR.InputDeviceCharacteristics.Left, gameControllers);

        foreach (var device in gameControllers) {
            Debug.Log(string.Format("Device name '{0}' has char '{1}'", device.name, device.characteristics.ToString()));
        }
    }

    // Update is called once per frame
    void Update() {
        bool cierraMano;
        if (gameControllers[0].TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out cierraMano)) {
            // Apertura
            animator.SetBool("coger", true);
        } else {
            // Cierre
            animator.SetBool("coger", false);
        }
    }
}