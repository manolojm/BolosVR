using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using CommonUsages = UnityEngine.XR.CommonUsages;

public class PruebaMandos : MonoBehaviour
{
    private List<UnityEngine.XR.InputDevice> gameControllers;
    private List<UnityEngine.XR.InputDevice> dispositivosDetectados;
    public TMPro.TextMeshPro textoJuego;
    private bool primaryTouch;
    private bool thumbrest;
    private Vector3 deviceVelocity;
    private Vector2 primary2DAxis;
    public float batteryLevel;

    // Start is called before the first frame update
    void Start()
    {
        dispositivosDetectados = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevices(dispositivosDetectados);
    }

    public void MuestraBatteryLevel() {
        Debug.Log("BatteryLevel: " + this.batteryLevel);
    }

    public void MuestraPrimary2DAxis() {
        Debug.Log("Primary2DAxis: " + this.primary2DAxis);
    }

    public void MuestraDispositivos() {
        textoJuego.text = ""; 
        foreach(var device in dispositivosDetectados) {
            textoJuego.text += (string.Format("Device found with name '{0}' and role '{1}'", device.name, device.role.ToString()));
        }
    }

    public void MuestraCaracteristicas() {
        textoJuego.text = "";
        var inputFeatures = new List<UnityEngine.XR.InputFeatureUsage>();

        var device = dispositivosDetectados[2];
        if (device.TryGetFeatureUsages(inputFeatures)) {
            foreach (var feature in inputFeatures) {
                Debug.Log(string.Format("Feature '{0}'", feature.name));
            }
        }
    }

    // Update is called once per frame
    void Update() {
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxis);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.primaryTouch, out primaryTouch);
        dispositivosDetectados[2].TryGetFeatureValue(CommonUsages.deviceVelocity, out deviceVelocity);
        dispositivosDetectados[2].TryGetFeatureValue(UnityEngine.XR.CommonUsages.thumbrest, out thumbrest);
    }

    public void muestraThumbRest() {
        Debug.Log("Thumbrest = " + this.thumbrest);
    }
}
