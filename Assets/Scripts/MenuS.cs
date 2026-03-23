// Dalia Danae Ramírez Rodríguez

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuS : MonoBehaviour
{
    // Paneles y elementos de UI
    public GameObject panelAyuda;
    public GameObject panelCreditos;
    public RectTransform textoCreditos;
    public float velocidadCreditos = 50f;

    // Estado de créditos
    private bool creditosActivos = false;

    void Start()
    {
        // Ocultar paneles al inicio
        if (panelAyuda != null) panelAyuda.SetActive(false);
        if (panelCreditos != null) panelCreditos.SetActive(false);
    }

    void Update()
    {
        // Animación de créditos si están activos
        if (creditosActivos && textoCreditos != null)
        {
            textoCreditos.anchoredPosition += Vector2.up * velocidadCreditos * Time.deltaTime;

            // Reiniciar posición cuando llegan al límite
            if (textoCreditos.anchoredPosition.y > 600)
            {
                textoCreditos.anchoredPosition = new Vector2(0, -200);
            }
        }
    }

    // Métodos para cambiar de escena
    public void AbrirJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void RegresarMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    // Métodos que permite mostrar/ocultar ayuda
    public void AbrirAyuda()
    {
        if (panelAyuda != null) panelAyuda.SetActive(true);
    }

    public void CerrarAyuda()
    {
        if (panelAyuda != null) panelAyuda.SetActive(false);
    }

    // Métodos que pemite mostrar/ocultar créditos
    public void AbrirCreditos()
    {
        Debug.Log("Abrir créditos");

        if (panelCreditos == null)
        {
            Debug.LogError("panelCreditos no está asignado en el Inspector.");
            return;
        }

        panelCreditos.SetActive(true);
        creditosActivos = true;

        // Reiniciar posición del texto
        if (textoCreditos != null)
            textoCreditos.anchoredPosition = new Vector2(0, -200);
    }

    public void CerrarCreditos()
    {
        if (panelCreditos != null) panelCreditos.SetActive(false);
        creditosActivos = false;
    }

    // Método para cerrar el juego
    public void CerrarJuego()
    {
        Debug.Log("Cerrando juego...");
        Application.Quit();
    }
}
