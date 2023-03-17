using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using CommonUsages = UnityEngine.XR.CommonUsages;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class PruebaMandos : MonoBehaviour
{
    private List<UnityEngine.XR.InputDevice> gameControllers;
    private List<UnityEngine.XR.InputDevice> dispositivosDetectados;
    public TMPro.TextMeshPro textoJuego;
    public GameObject mensajePuntos;

    // Bool
    private bool primaryTouch;
    private bool secondaryTouch;
    private bool thumbrest;
    private bool primaryButton;
    private bool secondaryButton;
    private bool triggerButton;
    private bool gripButton;
    private bool primary2DAxisClick;
    private bool primary2DAxisTouch;
    private bool isTracked;

    // Vector 3
    private Vector3 centerEyeAcceleration;
    private Vector3 centerEyeAngularAcceleration;
    private Vector3 centerEyeAngularVelocity;
    private Vector3 centerEyePosition;
    private Vector3 centerEyeVelocity;
    private Vector3 colorCameraAcceleration;

    private Vector3 devicePosition;
    private Vector3 deviceVelocity;
    private Vector3 deviceAngularVelocity;
    private Vector3 deviceAcceleration;
    private Vector3 deviceAngularAcceleration;

    // Vector 2
    private Vector2 primary2DAxis;

    // Float
    private float batteryLevel;
    private float trigger;
    private float grip;

    // Quaternion
    private Quaternion centerEyeRotation;
    private Quaternion deviceRotation;

    // InputTrackingState
    private InputTrackingState trackingState;

    // Start is called before the first frame update
    void Start()
    {
        dispositivosDetectados = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(dispositivosDetectados);
    }

    public void MuestraBatteryLevel() {
        Debug.Log("BatteryLevel: " + this.batteryLevel);
        mensajePuntos.GetComponent<TextMeshPro>().text = "Nivel de batería: " + this.batteryLevel;
    }

    public void MuestracenterEyeAcceleration() {
        Debug.Log("A: " + this.centerEyeAcceleration);
    }
    
    public void MuestracenterEyeAngularAcceleration() {
        Debug.Log("A: " + this.centerEyeAngularAcceleration);
    } 
    
    public void MuestracenterEyeAngularVelocity() {
        Debug.Log("A: " + this.centerEyeAngularVelocity);
    }
    
    public void MuestracenterEyePosition() {
        Debug.Log("A: " + this.centerEyePosition);
    }
    
    public void MuestracenterEyeRotation() {
        Debug.Log("A: " + this.centerEyeRotation);
    }
    
    public void MuestracenterEyeVelocity() {
        Debug.Log("A: " + this.centerEyeVelocity);
    }
    
    public void MuestracolorCameraAcceleration() {
        Debug.Log("A: " + this.colorCameraAcceleration);
    }

    public void MuestraPrimary2DAxis() {
        Debug.Log("Primary2DAxis: " + this.primary2DAxis);
    }

    public void MuestraprimaryButton() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.primaryButton;
    }
    
    public void MuestrasecondaryButton() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Secondary Button: " + this.secondaryButton;
    }

    public void MuestraprimaryTouch() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.primaryTouch;
    }
    
    public void MuestrasecondaryTouch() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.secondaryTouch;
    }
    
    public void Muestratrigger() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.trigger;
    }
    
    public void Muestragrip() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.grip;
    }
    
    public void MuestratriggerButton() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.triggerButton;
    }
    
    public void MuestragripButton() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.gripButton;
    }

    // IndexTouch Obsoleto
    // ThumbTouch Obsoleto

    public void Muestraprimary2DAxisClick() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.primary2DAxisClick;
    }

    public void Muestraprimary2DAxisTouch() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.primary2DAxisTouch;
    }

    // Thumbrest Obsoleto
    public void MuestraThumbRest() {
        Debug.Log("Thumbrest = " + this.thumbrest);
    }

    public void MuestraisTracked() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.isTracked;
    }
    
    public void MuestratrackingState() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.trackingState;
    }

    public void MuestradevicePosition() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.devicePosition;
    }

    public void MuestradeviceRotation() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.deviceRotation;
    }

    public void MuestradeviceVelocity() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.deviceVelocity;
    }

    public void MuestradeviceAngularVelocity() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.deviceAngularVelocity;
    }

    public void MuestradeviceAcceleration() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.deviceAcceleration;
    }

    public void MuestradeviceAngularAcceleration() {
        mensajePuntos.GetComponent<TextMeshPro>().text = "Primary Button: " + this.deviceAngularAcceleration;
    }

    public void MuestraDispositivos() {
        var text = ""; 
        foreach(var device in dispositivosDetectados) {
            text += (string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
        }
        mensajePuntos.GetComponent<TextMeshPro>().text = text;
    }

    public void MuestraCaracteristicas() {
        var text = "";
        var inputFeatures = new List<UnityEngine.XR.InputFeatureUsage>();

        var device = dispositivosDetectados[2];
        if (device.TryGetFeatureUsages(inputFeatures)) {
            foreach (var feature in inputFeatures) {
                text += string.Format("Feature '{0}'", feature.name);
            }
        }

        mensajePuntos.GetComponent<TextMeshPro>().text = text;
    }

    // Update is called once per frame
    void Update() {
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.primaryButton, out primaryButton);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.secondaryButton, out secondaryButton);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxis);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.primaryTouch, out primaryTouch);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.secondaryTouch, out secondaryTouch);

        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.trigger, out trigger);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.grip, out grip);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.triggerButton, out triggerButton);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.gripButton, out gripButton);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.primary2DAxisClick, out primary2DAxisClick);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out primary2DAxisTouch);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.isTracked, out isTracked);

        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.trackingState, out trackingState);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.devicePosition, out devicePosition);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.deviceRotation, out deviceRotation);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.deviceVelocity, out deviceVelocity);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.deviceAngularVelocity, out deviceAngularVelocity);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.deviceAcceleration, out deviceAcceleration);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.deviceAngularAcceleration, out deviceAngularAcceleration);


        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.deviceVelocity, out deviceVelocity);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.thumbrest, out thumbrest);
    }

    
}
