using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel; 
    public Button continueButton;
    public Button resetButton;
    public Button menuButton;

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false); 

        continueButton.onClick.AddListener(ContinueGame);
        resetButton.onClick.AddListener(ResetLevel);
        menuButton.onClick.AddListener(ReturnToMenu);
    }

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true); 
    }

    void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false); 
    }

    void ResetLevel()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ReturnToMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu");
    }
}
