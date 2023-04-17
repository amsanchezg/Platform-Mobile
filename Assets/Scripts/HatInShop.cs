using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HatInShop : MonoBehaviour
{
    public HatInfo hatInfo;
    public GameObject hatObject;
    public bool isHatUnlocked;
    public TextMeshProUGUI textoBoton;
    public Image coinImage;


    //mi manera
    public int IDHat;
    private void Awake()
    {

        hatObject = hatInfo.hatObject;
        EstaLaGorraDesbloqueada();
    }

    private void EstaLaGorraDesbloqueada()
    {
        if(PlayerPrefs.GetInt(hatInfo.TheHatsID.ToString()) == 1)
        {
            isHatUnlocked = true;
            textoBoton.text = "Equipar";
            coinImage.gameObject.SetActive(false);
            hatObject.SetActive(true);
        }
        else
        {
            hatObject.SetActive(false);
            
        }
    }
    public void PulsamosBoton()
    {
        if (isHatUnlocked)
        {
            //equipamos
            HatManager.IDEquipHat = IDHat;
            FindObjectOfType<HatManager>().EquipedHat(hatInfo);
            



        }
        else
        {
            //compramos
            if (FindObjectOfType<CoinsManager>().QuitarMonedas(hatInfo.hatPrice))
            {
                
                PlayerPrefs.SetInt(hatInfo.TheHatsID.ToString(), 1);
                EstaLaGorraDesbloqueada();
            }
        }
    }
}
