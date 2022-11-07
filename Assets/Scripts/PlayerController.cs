using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocitaMovimento;

    private float direzioneMovimento;

    private Rigidbody2D rb;

    /* Unity */
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        VerificaInput();
    }

    void FixedUpdate() {
        ApplicaMovimento();
    }

    /* Personali */

    private void VerificaInput() {
        direzioneMovimento = Input.GetAxisRaw("Horizontal");
    }

    private void ApplicaMovimento() {
        rb.velocity = new Vector2(velocitaMovimento * direzioneMovimento, rb.velocity.y);
    }
}
