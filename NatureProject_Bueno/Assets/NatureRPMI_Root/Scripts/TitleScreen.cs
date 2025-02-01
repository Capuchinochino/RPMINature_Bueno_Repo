using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaTitulo : MonoBehaviour
{
   
    public void IniciarJuego()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SalirJuego()
    {
        Application.Quit(); 
        Debug.Log("Salir del juego"); 
    }
}
