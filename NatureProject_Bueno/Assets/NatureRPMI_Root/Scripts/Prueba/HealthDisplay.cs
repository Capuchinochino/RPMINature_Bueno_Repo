using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public PlayerController playerController;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        if (playerController == null)
        {
            playerController = FindObjectOfType < PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null)
        {
            int currentHealth = playerController.playerHealth;


            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < currentHealth)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
            }
        }
    }
}
