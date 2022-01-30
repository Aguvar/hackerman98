using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickSound : MonoBehaviour
{
    public AudioSource source;

    public AudioClip click;

    private void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            source.PlayOneShot(click);
        }
    }
}
