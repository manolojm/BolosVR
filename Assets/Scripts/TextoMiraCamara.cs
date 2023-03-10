using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoMiraCamara : MonoBehaviour
{

    public Camera cameraToLookAt;
    // Start is called before the first frame update
    void Start()
    {
        cameraToLookAt = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.LookRotation(cameraToLookAt.transform.forward);
    }
}
