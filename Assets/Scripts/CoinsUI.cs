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
        monedasActualesTexto.text = GameManager.Singleton.coins.monedasActuales.ToString();
        
        
    }
}
