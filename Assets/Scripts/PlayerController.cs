using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocitaMovimento;
    public float forzaSalto;

    private bool isDirezioneCorretta = true;
    private float direzioneMovimento;

    private Rigidbody2D rb;

    /* Unity */
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        VerificaInput();
        VerificaDirezioneMovimento();
    }

    void FixedUpdate() {
        ApplicaMovimento();
    }

    /* Personali */

    private void VerificaInput() {
        direzioneMovimento = Input.GetAxisRaw("Horizontal");
        if(Input.GetButtonDown("Jump")) {
            Salto();
        }
    }

    private void VerificaDirezioneMovimento() {
        if(isDirezioneCorretta && direzioneMovimento < 0) {
            Rigira();
        } else if(!isDirezioneCorretta && direzioneMovimento > 0) {
            Rigira();
        }
    }

    private void ApplicaMovimento() {
        rb.velocity = new Vector2(velocitaMovimento * direzioneMovimento, rb.velocity.y);
    }

    /* Azioni */

    private void Rigira() {
        isDirezioneCorretta = !isDirezioneCorretta;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void Salto() {
        rb.velocity = new Vector2(rb.velocity.x, forzaSalto);
    }
}
