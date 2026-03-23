using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuS : MonoBehaviour
{
    public GameObject panelAyuda;
    public GameObject panelCreditos;
    public RectTransform textoCreditos;
    public float velocidadCreditos = 50f;

    private bool creditosActivos = false;

    void Start()
    {
        if (panelAyuda != null) panelAyuda.SetActive(false);
        if (panelCreditos != null) panelCreditos.SetActive(false);
    }

    void Update()
    {
        if (creditosActivos && textoCreditos != null)
        {
            textoCreditos.anchoredPosition += Vector2.up * velocidadCreditos * Time.deltaTime;

            if (textoCreditos.anchoredPosition.y > 600)
            {
                textoCreditos.anchoredPosition = new Vector2(0, -200);
            }
        }
    }

    public void AbrirJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void AbrirAyuda()
    {
        if (panelAyuda != null) panelAyuda.SetActive(true);
    }

    public void CerrarAyuda()
    {
        if (panelAyuda != null) panelAyuda.SetActive(false);
    }

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

        if (textoCreditos != null)
            textoCreditos.anchoredPosition = new Vector2(0, -200);
    }

    public void CerrarCreditos()
    {
        if (panelCreditos != null) panelCreditos.SetActive(false);
        creditosActivos = false;
    }

    public void CerrarJuego()
    {
        Debug.Log("Cerrando juego...");
        Application.Quit();
    }

    public void RegresarMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}