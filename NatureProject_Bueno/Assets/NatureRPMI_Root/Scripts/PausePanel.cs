using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject PanelPause; 
    public Button continueButton;
    public Button resetButton;
    public Button menuButton;

    private bool isPaused = false;

    void Start()
    {
        PanelPause.SetActive(false); 

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
        PanelPause.SetActive(true); 
    }

    void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        PanelPause.SetActive(false); 
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
