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
    public GameObject mensajeInstrucciones;
    public AudioSource audioPleno;
    public AudioSource audioFondo;

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

        Instantiate(audioFondo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IniciaPartida() {
        PonerBolos();
    }

    public void PonerBolos() {
        Debug.Log("Poner bolos");

        if (ronda1) {
            Debug.Log("Ronda1");
            mensajeInstrucciones.GetComponent<TextMeshPro>().text = "Segundo lanzamiento";
            //DestruirBolosCaidos();
        } else {
            Debug.Log("Ronda2");
            mensajeInstrucciones.GetComponent<TextMeshPro>().text = "Primer lanzamiento";
            Invoke("DestruirBolosTodos", 1f);
            Invoke("CrearBolosNuevos", 2f);
        }

        mensajePuntos.GetComponent<TextMeshPro>().text = "Puntos: " + puntos;
    }

    // Destruir solo los bolos caidos
    public void DestruirBolosCaidos() {
        Debug.Log("Destruir bolos caidos");
        fallen = 0;
        bolosOld = GameObject.FindGameObjectsWithTag("Bolo");
        foreach (GameObject bolo in bolosOld) {

            if (bolo.transform.up.y < threshold) {
                fallen++;
                Destroy(bolo);
            }
        }
        puntos += fallen;

        // Para probar: Vector3(7.21351814,-2.9364419,31.1258316)
        // Si hace pleno, se salta la ronda 2
        if (fallen == 10) {
            ronda1 = false;
            Instantiate(audioPleno);

        } else {
            if (ronda1) {
                ronda1 = false;
                
            } else {
                ronda1 = true; 
            }  
        }

        Invoke("PonerBolos", 2f);
    }

    // Destruir todos los bolos
    public void DestruirBolosTodos() {
        Debug.Log("Destruir todos los bolos");
        fallen = 0;
        bolosOld = GameObject.FindGameObjectsWithTag("Bolo");
        foreach (GameObject bolo in bolosOld) {
            fallen++;
            Destroy(bolo);
        }
    }

    // Crear nuevos bolos
    public void CrearBolosNuevos() {
        Debug.Log("Crear todos los bolos");
        bolos = GameObject.FindGameObjectsWithTag("BoloSpawn");
        foreach (GameObject bolo in bolos) {
            GameObject nuevoBolo = Instantiate(boloPrefab, bolo.transform.position, bolo.transform.rotation);
            nuevoBolo.SetActive(true);
        }
    }
}
