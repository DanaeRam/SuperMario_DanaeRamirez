// Dalia Danae Ramírez Rodríguez

using UnityEngine;

public class MuevePersonaje : MonoBehaviour
{
    // Parámetros de movimiento y salto
    public float velocidad = 5f;
    public float fuerzaSalto = 8f;

    // Componentes y estado
    private Rigidbody2D rb;
    private Animator animator;
    private bool enSuelo;

    void Start()
    {
        // Obtener referencias a Rigidbody y Animator
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float movimiento = Input.GetAxis("Horizontal");

        // Movimiento horizontal
        rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y);

        // Voltear sprite según dirección
        if (movimiento > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movimiento < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
        }

        // Actualizar parámetros del Animator
        animator.SetFloat("velocidad", Mathf.Abs(movimiento));
        animator.SetBool("enSuelo", enSuelo);
    }

    // Detectar contacto con el suelo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    // Detectar salida del suelo
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}
