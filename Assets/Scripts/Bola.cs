using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{

    private float giroH, giroY;
    private Rigidbody rb;
    public GameObject punto;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //giroH = Input.GetAxis("Horizontal");
        //giroY = Input.GetAxis("Vertical");
        //rb.AddForce(giroH, 0, giroY);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Fuera")) {
            rb.velocity *= 0;
            transform.position = punto.transform.position; ;

            Invoke("LlamarPonerbolos", 3f);
        }
    }

    private void LlamarPonerbolos() {
        CrearBolos.instance.PonerBolos();
    }
}
