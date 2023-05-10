using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NuevoCoinManager : MonoBehaviour
{

    public static int TotalCoins;
    public static int LevelCoins;
    public Text TextoTotalCoins;
    public Text TextoLevelCoins;
   
    // Start is called before the first frame update
    void Start()
    {
        LevelCoins = 0;
        TotalCoins = PlayerPrefs.GetInt("MonedasTotales_nuevo");

    }

    // Update is called once per frame
    void Update()
    {
        ////UPDATE LA UI
        if(TextoTotalCoins != null)
        {
            TextoTotalCoins.text = TotalCoins.ToString();
        }
        if (TextoLevelCoins != null)
       {
            TextoLevelCoins.text = LevelCoins.ToString();
      }


    }
    public void FinalizarNivelyGuardarMonedas()
    {

        TotalCoins += LevelCoins;
        PlayerPrefs.SetInt("MonedasTotales_nuevo", TotalCoins);
         
    }


    public bool QuitarMonedas(int monedasAQuitar)
    {
        if (TotalCoins >= monedasAQuitar)
        {
            TotalCoins -= monedasAQuitar;

            
            PlayerPrefs.SetInt("MonedasTotales_nuevo", TotalCoins);
            //PlayerPrefs.SetInt("MonedasActuales", PlayerPrefs.GetInt("MonedasTotales", 0) - monedasAQuitar);
            return true;

        }
        else
        {
            return false;
        }
    }
}
