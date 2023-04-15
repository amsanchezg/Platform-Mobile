using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CoinsManager : MonoBehaviour
{
   
    public int monedasAContar;
    public int monedasActuales;

    public void Start()
    {
        monedasActuales = PlayerPrefs.GetInt("MonedasTotales", 500);
    }

    public void ActualCoins(int valorMonedas)
   {
        monedasAContar += valorMonedas;
        GameManager.Singleton.coinsUI.ActualizarNumeroMonedas();
        
        
   }

    public void GuardarMonedas()
    {
        PlayerPrefs.SetInt("Monedas_" + SceneManager.GetActiveScene().name, monedasAContar);
        int totales = PlayerPrefs.GetInt("MonedasTotales", 0);
        PlayerPrefs.SetInt("MonedasTotales", totales += monedasAContar);
    }

    public int TotalMonedas() 
    {
        return PlayerPrefs.GetInt("MonedasTotales", 500);
        

    }

    public bool QuitarMonedas(int monedasAQuitar)
    {
        if (monedasActuales >= monedasAQuitar)
        {
            monedasActuales -= monedasAQuitar;
            GameManager.Singleton.coinsUI.ActualizarNumeroMonedas();
            return true;
            
        }
        else
        {
            return false;
        }
    }
}
