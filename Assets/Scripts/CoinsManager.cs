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
    static public int monedasActuales;

    private void Awake()
    {
        TotalMonedas();
        
    }

    public void ActualCoins(int valorMonedas)
   {
        monedasAContar += valorMonedas;
        GameManager.Singleton.coinsUI.ActualizarNumeroMonedasInGame();
        monedasActuales = PlayerPrefs.GetInt("MonedasActuales");

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
            Debug.Log(monedasActuales);
            GameManager.Singleton.coinsUI.ActualizarNumeroMonedas();
            PlayerPrefs.SetInt("MonedasTotales",monedasActuales);
            //PlayerPrefs.SetInt("MonedasActuales", PlayerPrefs.GetInt("MonedasTotales", 0) - monedasAQuitar);
            return true;
            
        }
        else
        {
            return false;
        }
    }
}
