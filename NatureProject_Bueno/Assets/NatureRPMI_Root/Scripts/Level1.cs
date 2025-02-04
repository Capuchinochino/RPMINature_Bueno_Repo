using UnityEngine;
using UnityEngine.SceneManagement;  // Para cambiar de escena

<<<<<<< Updated upstream
public class FinalizarNivel1 : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            Debug.Log("Level Finished!");


            SceneManager.LoadScene("Level2");
=======
public class FinalizarNivel : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Player"))
        {
            
            Debug.Log("Level Finished!");

            
            SceneManager.LoadScene("FinalBoss");
>>>>>>> Stashed changes
        }
    }
}
