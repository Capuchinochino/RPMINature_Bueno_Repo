using UnityEngine;
using UnityEngine.SceneManagement;  // Para cambiar de escena

public class FinalizarNivel1 : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            Debug.Log("Level Finished!");


            SceneManager.LoadScene("Level2");
        }
    }
}
