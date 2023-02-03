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
        return PlayerPrefs.GetInt("MonedasTotales", 0);
    }
}
