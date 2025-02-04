using UnityEngine;
using UnityEngine.SceneManagement;  // Para cambiar de escena

public class FinalizarNivel : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Player"))
        {
            
            Debug.Log("Level Finished!");

            
            SceneManager.LoadScene("FinalBoss");
        }
    }
}
