using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int numeroSalti;
    public float velocitaMovimento;
    public float forzaSalto;
    public float velocitaScivolataSuMuro;
    public float raggioVerificaTerreno;
    public float distanzaVerificaMuro;
    public Transform verificaTerreno;
    public Transform verificaMuro;
    public LayerMask terreno;

    private int saltiRimasti;
    private bool isDirezioneCorretta = true;
    private bool isCamminando;
    private bool isToccaTerra;
    private bool isToccaMuro;
    private bool isScivolaSuMuro;
    private bool canSaltare;
    private float direzioneMovimento;

    private Rigidbody2D rb;
    private Animator anim;

    /* Unity */
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        saltiRimasti = numeroSalti;
    }

    void Update() {
        VerificaInput();
        VerificaDirezioneMovimento();
        AggiornaAnimazioni();
        VerificaSePossibileSaltare();
        VerificaScivolaSuMuro();
    }

    void FixedUpdate() {
        Cammino();
        VerificaZonaCircostante();
    }

    void OnDrawGizmos() {
        Gizmos.DrawWireSphere(verificaTerreno.position, raggioVerificaTerreno);
        Gizmos.DrawLine(
            verificaMuro.position,
            new Vector3(
                verificaMuro.position.x + distanzaVerificaMuro,
                verificaMuro.position.y,
                verificaMuro.position.z
            )
        );
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
        isToccaMuro = Physics2D.Raycast(verificaMuro.position, transform.right, distanzaVerificaMuro, terreno);
    }

    private void VerificaSePossibileSaltare() {
        if(isToccaTerra && rb.velocity.y <= 0) {
            saltiRimasti = numeroSalti;
        }
        if(saltiRimasti <= 0) {
            canSaltare = false;
        } else {
            canSaltare = true;
        }
    }

    private void VerificaScivolaSuMuro() {
        if(isToccaMuro && !isToccaTerra && rb.velocity.y < 0) {
            isScivolaSuMuro = true;
        } else {
            isScivolaSuMuro = false;
        }
    }

    private void AggiornaAnimazioni() {
        anim.SetBool("camminando", isCamminando);
        anim.SetBool("toccaTerra", isToccaTerra);
        anim.SetBool("scivolandoSuMuro", isScivolaSuMuro);
        anim.SetFloat("velocitaY", rb.velocity.y);
    }

    /* Azioni */

    private void Cammino() {
        if(isToccaTerra) {
            rb.velocity = new Vector2(velocitaMovimento * direzioneMovimento, rb.velocity.y);
        }

        if(isScivolaSuMuro) {
            if(rb.velocity.y < -velocitaScivolataSuMuro) {
                rb.velocity = new Vector2(rb.velocity.x, -velocitaScivolataSuMuro);
            }
        }
    }

    private void Rigira() {
        if(!isScivolaSuMuro) {
            isDirezioneCorretta = !isDirezioneCorretta;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

    private void Salto() {
        if(canSaltare) {
            rb.velocity = new Vector2(rb.velocity.x, forzaSalto);
            saltiRimasti--;
        }
    }
}
