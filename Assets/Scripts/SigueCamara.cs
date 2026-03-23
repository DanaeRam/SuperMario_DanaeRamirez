// Dalia Danae Ramírez Rodríguez

using UnityEngine;

public class SigueCamara : MonoBehaviour
{
    // Para que la camara siga al personaje al moverse
    public Transform objetivo;
    public float suavizado = 5f;
    public float offsetX = 2f;

    void LateUpdate()
    {
        // Seguir a Mario con desplazamiento en X
        if (objetivo != null)
        {
            Vector3 nuevaPosicion = new Vector3(
                objetivo.position.x + offsetX,
                transform.position.y,
                transform.position.z
            );

            // Movimiento suave hacia la nueva posición
            transform.position = Vector3.Lerp(
                transform.position,
                nuevaPosicion,
                suavizado * Time.deltaTime
            );
        }
    }
}
