using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectarTiro : MonoBehaviour
{
    //public Transform[] pins;
    public GameObject[] pins;
    float threshold = 0.4f;
    public int fallen = 0;
    public ArrayList posicionesBolos;
    //public Text Bro;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++) {
            //Debug.Log(pins[i].transform.position);
            //posicionesBolos[i] = pins[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.up.y < threshold) {
            //Bro.text = "CAIDO";
            //Debug.Log("bolo caido");
        } else {
            //Bro.text = "EN PIE";
            //Debug.Log("bolo no caido");
        }
    }

    /*void DetectarBolosCaidos() {
        foreach (Transform pin in pins) {
            if (pin.up.y < threshold) {
                Debug.Log(pin.up.y);
                fallen++;
            }
        }
    }*/

    IEnumerator DetectarBolosCaidos() {
        yield return new WaitForSeconds(3);
        pins = GameObject.FindGameObjectsWithTag("Pin");
        foreach (GameObject pin in pins){
            if (pin.transform.up.y < threshold) {
                fallen++;
                Destroy(pin);
            }
        }
    }


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Fuera")) {
            DetectarBolosCaidos();
        }
    }

    private void PonerBolos() {
        for (int i = 0; i < 3; i++) {
            //pins[i].x = posicionesBolos[i].x;
            //Debug.Log(posicionesBolos[i]);
        }
    }
}
