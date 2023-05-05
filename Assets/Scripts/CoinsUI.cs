using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class CoinsUI : MonoBehaviour
{

    public Text monedasActualesTexto;
    public Text monedasContadas;
    
    GameManager _gameManager;

    private void Awake()
    {
        
       
        if (SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            monedasActualesTexto.text = GameManager.Singleton.coins.TotalMonedas().ToString();
            

        }
    }
    public void ActualizarNumeroMonedas()
    {
        monedasActualesTexto.text = CoinsManager.monedasActuales.ToString();
        //monedasContadas.text = GameManager.Singleton.coins.monedasAContar.ToString();
        
        
    }

    public void ActualizarNumeroMonedasInGame()
    {
        monedasContadas.text = GameManager.Singleton.coins.monedasAContar.ToString();
    }
    public void ActualizarMonedasMainMenu()
    {
        monedasActualesTexto.text = PlayerPrefs.GetInt("MonedasTotales", 0).ToString();


    }
}
