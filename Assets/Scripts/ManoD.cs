using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManoD : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision) {
        animator.Play("ManoD");
        Debug.Log("mano1");
    }

    private void OnCollisionExit(Collision collision) {
        animator.Play("ManoDcierre");
    }
}
