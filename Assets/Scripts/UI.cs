using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
   
    public Text healthText;
    public GameObject losePanel;
    public GameObject anuncioVida;
    public bool seActiva;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = GameManager.Singleton.playerLifes.currentHealth.ToString("3");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Singleton.playerLifes.currentHealth == 1 && seActiva )
        {
            anuncioVida.SetActive(true);
            Time.timeScale = 0f;
            seActiva = false;
        }
    }

    public void AumentarVida()
    {
        
        GameManager.Singleton.playerLifes.currentHealth = GameManager.Singleton.playerLifes.currentHealth + 1;
        GameManager.Singleton.playerLifes.lifes[1].gameObject.SetActive(true);
        healthText.text = GameManager.Singleton.playerLifes.currentHealth.ToString();
        Time.timeScale = 1f;
        anuncioVida.SetActive(false);
        seActiva = false;
    }

    public void NoAumentarVida()
    {
        
        anuncioVida.SetActive(false);
        seActiva = false;
        Time.timeScale = 1f;
    }
}
