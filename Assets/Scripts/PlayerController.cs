using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocitaMovimento;
    public float forzaSalto;
    public float raggioVerificaTerreno;
    public Transform verificaTerreno;
    public LayerMask terreno;

    private bool isDirezioneCorretta = true;
    private bool isCamminando;
    private bool isToccaTerra;
    private bool canSaltare;
    private float direzioneMovimento;

    private Rigidbody2D rb;
    private Animator anim;

    /* Unity */
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        VerificaInput();
        VerificaDirezioneMovimento();
        AggiornaAnimazioni();
        VerificaSePossibileSaltare();
    }

    void FixedUpdate() {
        Cammino();
        VerificaZonaCircostante();
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(verificaTerreno.position, raggioVerificaTerreno);
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

        if(rb.velocity.x != 0) {
            isCamminando = true;
        } else {
            isCamminando = false;
        }
    }

    private void VerificaZonaCircostante() {
        isToccaTerra = Physics2D.OverlapCircle(verificaTerreno.position, raggioVerificaTerreno, terreno);
    }

    private void VerificaSePossibileSaltare() {
        if(isToccaTerra && rb.velocity.y <= 0) {
            canSaltare = true;
        } else {
            canSaltare = false;
        }
    }

    private void AggiornaAnimazioni() {
        anim.SetBool("camminando", isCamminando);
    }

    /* Azioni */

    private void Cammino() {
        rb.velocity = new Vector2(velocitaMovimento * direzioneMovimento, rb.velocity.y);
    }

    private void Rigira() {
        isDirezioneCorretta = !isDirezioneCorretta;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void Salto() {
        if(canSaltare) {
            rb.velocity = new Vector2(rb.velocity.x, forzaSalto);
        }
    }
}
