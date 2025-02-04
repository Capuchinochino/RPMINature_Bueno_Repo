using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0; // Pausar el juego
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1; // Reanudar el juego
        isPaused = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

}
