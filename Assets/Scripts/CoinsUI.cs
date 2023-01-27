using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class CoinsUI : MonoBehaviour
{
    CoinsManager reference;
    public Text monedasActualesTexto;
    
    GameManager _gameManager;

    private void Awake()
    {
        reference = FindObjectOfType<CoinsManager>();
       
        if (SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            monedasActualesTexto.text = reference.TotalMonedas().ToString();
        }
    }
    public void ActualizarNumeroMonedas()
    {
        monedasActualesTexto.text = reference.monedasAContar.ToString("00");
        
    }
}
