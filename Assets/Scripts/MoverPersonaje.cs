using UnityEngine;

public class MuevePersonaje : MonoBehaviour
{
    public float velocidad = 5f;
    public float fuerzaSalto = 8f;

    private Rigidbody2D rb;
    private Animator animator;
    private bool enSuelo;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float movimiento = Input.GetAxis("Horizontal");

        // Movimiento horizontal
        rb.linearVelocity = new Vector2(movimiento * velocidad, rb.linearVelocity.y);

        // Voltear a Mario según la dirección
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

        // Actualizar Animator
        animator.SetFloat("velocidad", Mathf.Abs(movimiento));
        animator.SetBool("enSuelo", enSuelo);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = false;
        }
    }
}