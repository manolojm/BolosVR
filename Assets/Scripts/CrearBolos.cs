using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrearBolos : MonoBehaviour
{
    public static CrearBolos instance {
        get; private set;
    }

    public GameObject boloPrefab;
    public GameObject[] bolos;
    public GameObject[] bolosOld;

    private float threshold;
    public int fallen;
    public int puntos;
    public Boolean ronda1;
    public GameObject mensajePuntos;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        fallen = 0;
        puntos = 0;
        threshold = 0.9f;
        ronda1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciaPartida() {
        PonerBolos();
    }

    public void PonerBolos() {
        
        if (ronda1) {
            Debug.Log("Ronda1");
            DestruirBolosCaidos();
        } else {
            Debug.Log("Ronda2");
            DestruirBolosTodos();
            Invoke("CrearBolosNuevos", 2f);
        }

        mensajePuntos.GetComponent<TextMeshPro>().text = "Puntos: " + puntos;
    }

    // Destruir solo los bolos caidos
    public void DestruirBolosCaidos() {
        fallen = 0;
        bolosOld = GameObject.FindGameObjectsWithTag("Bolo");
        foreach (GameObject bolo in bolosOld) {

            if (bolo.transform.up.y < threshold) {
                fallen++;
                Destroy(bolo);
            }
        }
        puntos += fallen;

        // Si hace pleno, se salta la ronda 2
        if (fallen == 10) {
            ronda1 = true;
        } else {
            ronda1 = false;
        } 
    }

    // Destruir todos los bolos
    public void DestruirBolosTodos() {
        fallen = 0;
        bolosOld = GameObject.FindGameObjectsWithTag("Bolo");
        foreach (GameObject bolo in bolosOld) {
            fallen++;
            Destroy(bolo);
        }
        puntos += fallen;
        ronda1 = true;

    }

    // Crear nuevos bolos
    public void CrearBolosNuevos() {
        bolos = GameObject.FindGameObjectsWithTag("BoloSpawn");
        foreach (GameObject bolo in bolos) {
            GameObject nuevoBolo = Instantiate(boloPrefab, bolo.transform.position, bolo.transform.rotation);
            nuevoBolo.SetActive(true);
        }
    }
}
