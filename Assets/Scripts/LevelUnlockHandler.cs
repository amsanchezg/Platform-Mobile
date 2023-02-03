using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelUnlockHandler : MonoBehaviour
{
    [SerializeField] Button[] botonesNiveles;
    int unlockedLevelsNumber;
    // Start is called before the first frame update
    void Start()
    {
        //Desbloquea al empezar el juego el nivel 1
        if (!PlayerPrefs.HasKey("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", 1);
        }

        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");
        for (int i = 0; i < botonesNiveles.Length; i++)
        {
            botonesNiveles[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");
        for (int i = 0; i < unlockedLevelsNumber; i++)
        {
            botonesNiveles[i].interactable = true;
        }
    }
}
