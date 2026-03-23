// Dalia Danae Ramírez Rodríguez

using UnityEngine;

public class PatrullaGoomba : MonoBehaviour
{
    // Parámetros de movimiento y límites
    public float velocidad = 2f;
    public float limiteIzquierdo = -2f;
    public float limiteDerecho = 2f;

    // Dirección actual
    private bool moviendoDerecha = true;

    void Update()
    {
        // Movimiento hacia la derecha
        if (moviendoDerecha)
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);

            // Cambiar dirección al llegar al límite derecho
            if (transform.position.x >= limiteDerecho)
            {
                moviendoDerecha = false;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        // Movimiento hacia la izquierda
        else
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);

            // Cambiar dirección al llegar al límite izquierdo
            if (transform.position.x <= limiteIzquierdo)
            {
                moviendoDerecha = true;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
