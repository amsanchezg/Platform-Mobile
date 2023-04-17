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

 

    public void ActualCoins(int valorMonedas)
   {
        monedasActuales += valorMonedas;
        GameManager.Singleton.coinsUI.ActualizarNumeroMonedas();
        
        
   }

    public void GuardarMonedas()
    {
        PlayerPrefs.SetInt("Monedas_" + SceneManager.GetActiveScene().name, monedasActuales);
        int totales = PlayerPrefs.GetInt("MonedasTotales");
        PlayerPrefs.SetInt("MonedasTotales", totales += monedasActuales);
    }

    public int TotalMonedas() 
    {
        
       return monedasActuales = PlayerPrefs.GetInt("MonedasTotales");

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
