using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Animator miPuerta;

    public void OpenDoor() {
        miPuerta.Play("PuertaAbrir");
    }

    public void CloseDoor() {
        miPuerta.Play("PuertaCerrar");
    }
}
