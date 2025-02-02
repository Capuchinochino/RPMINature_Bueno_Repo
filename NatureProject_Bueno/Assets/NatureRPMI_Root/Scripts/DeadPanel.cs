using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelMuerte : MonoBehaviour
{
    public GameObject panelMuerte;

    // Funci�n para mostrar el panel de muerte
    public void ActivarPanelMuerte()
    {
        panelMuerte.SetActive(true);
        Time.timeScale = 0f; // Pausa el juego
    }

    public void ReintentarNivel()
    {
        Time.timeScale = 1f; // Reanuda el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void IrAlMenuPrincipal()
    {
        Time.timeScale = 1f; // Reanuda el juego
        SceneManager.LoadScene("MainMenu");
    }
}
