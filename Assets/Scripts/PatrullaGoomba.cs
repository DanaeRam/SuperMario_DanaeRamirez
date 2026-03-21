using UnityEngine;

public class PatrullaGoomba : MonoBehaviour
{
    public float velocidad = 2f;
    public float limiteIzquierdo = -2f;
    public float limiteDerecho = 2f;

    private bool moviendoDerecha = true;

    void Update()
    {
        if (moviendoDerecha)
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);

            if (transform.position.x >= limiteDerecho)
            {
                moviendoDerecha = false;
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);

            if (transform.position.x <= limiteIzquierdo)
            {
                moviendoDerecha = true;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}