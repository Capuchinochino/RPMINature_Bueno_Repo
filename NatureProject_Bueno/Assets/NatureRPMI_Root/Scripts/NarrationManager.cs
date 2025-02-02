using System.Collections;
using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class NarrationManager : MonoBehaviour
{
    public GameObject narrationPanel;  
    public TextMeshProUGUI narrationText;  
    public string[] storyLines; 
    public float textSpeed = 0.05f;  

    private int currentLine = 0;  
    private bool isTyping = false;  

    void Start()
    {
        narrationPanel.SetActive(false);  // Ocultar el panel al inicio
    }

    public void StartNarration()
    {
        narrationPanel.SetActive(true);  // Mostrar el panel de narración
        StartCoroutine(TypeText());  
    }

    IEnumerator TypeText()
    {
        isTyping = true;
        narrationText.text = "";  // Vaciar el texto antes de escribir

        foreach (char letter in storyLines[currentLine].ToCharArray())
        {
            narrationText.text += letter;  
            yield return new WaitForSeconds(textSpeed);  
        }

        isTyping = false;
        yield return new WaitForSeconds(2f);  
        NextLine();  

    void NextLine()
    {
        if (currentLine < storyLines.Length - 1)
        {
            currentLine++; 
            StartCoroutine(TypeText()); 
        }
        else
        {
            StartGame();  
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("Level1"); 
    }
    }
}
