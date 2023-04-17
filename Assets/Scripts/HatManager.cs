using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatManager : MonoBehaviour
{
    public static GameObject equippedHat;
    public HatInfo[] allHats;


    //mi manera
    public static int IDEquipHat;
    public GameObject[] SceneHats;
    public void Update()
    {
        
    }
    private void Awake()
    {
        string lastHatUsed = PlayerPrefs.GetString("hatPref", HatInfo.hatsID.hat1.ToString());
        foreach(HatInfo h in allHats)
        {
            if (h.TheHatsID.ToString() == lastHatUsed)
            {
                EquipedHat(h);
            }
        }
    }
    public void EquipedHat(HatInfo hatInfo)
    {
       equippedHat = hatInfo.hatObject;
       
        
       
        PlayerPrefs.SetString("hatPref", hatInfo.TheHatsID.ToString());

      // mi manera 

        for( int i = 0; i < SceneHats.Length; i++)
        {
            SceneHats[i].SetActive(false);
        }
        SceneHats[IDEquipHat].SetActive(true);
    }


}
