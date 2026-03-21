using UnityEngine;

public class SigueCamara : MonoBehaviour
{
    public Transform objetivo;
    public float suavizado = 5f;
    public float offsetX = 2f;

    void LateUpdate()
    {
        if (objetivo != null)
        {
            Vector3 nuevaPosicion = new Vector3(
                objetivo.position.x + offsetX,
                transform.position.y,
                transform.position.z
            );

            transform.position = Vector3.Lerp(transform.position, nuevaPosicion, suavizado * Time.deltaTime);
        }
    }
}