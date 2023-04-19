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

    private void Awake()
    {
        monedasActuales = PlayerPrefs.GetInt("MonedasTotales", TotalMonedas());
        
    }

    public void ActualCoins(int valorMonedas)
   {
        monedasAContar += valorMonedas;
        GameManager.Singleton.coinsUI.ActualizarNumeroMonedas();
        
        
   }

    public void GuardarMonedas()
    {
        PlayerPrefs.SetInt("Monedas_" + SceneManager.GetActiveScene().name, monedasAContar);
        int totales = PlayerPrefs.GetInt("MonedasTotales");
        PlayerPrefs.SetInt("MonedasTotales", totales + monedasAContar);
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
            GameManager.Singleton.coinsUI.ActualizarMonedasMainMenu();
            //PlayerPrefs.SetInt("MonedasActuales", PlayerPrefs.GetInt("MonedasTotales", 0) - monedasAQuitar);
            return true;
            
        }
        else
        {
            return false;
        }
    }
}
