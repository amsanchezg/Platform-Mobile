using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Goal : MonoBehaviour
{
    CoinsManager coinsManager;
    public string escena;
    public Text textGoal;
    public int levelToUnlock;
    int numberOfUnlockedLevels;
    [SerializeField] Event victoryAnim;
    
    private void Awake()
    {
        coinsManager = FindObjectOfType<CoinsManager>();
    }

    public void CambiarEscena(string escena) 
    {

        StartCoroutine(CambioEscena());

    }

    public void VictoryEvent()
    {
        StartCoroutine(Victory());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            victoryAnim.Ocurred(this.gameObject);
            numberOfUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");
            VictoryEvent();
            coinsManager.GuardarMonedas();
            coinsManager.TotalMonedas();
            if (numberOfUnlockedLevels <= levelToUnlock)
            {
                PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockedLevels + 1);

            }
        }
    }

    IEnumerator CambioEscena()
    {
        
        yield return new WaitForSeconds(0);
        GameManager.Singleton.Nulify();
        SceneManager.LoadScene(escena);
    }

    IEnumerator Victory()
    {
        GameManager.Singleton.Sounds.EndMusic();
        GameManager.Singleton.Sounds.VictorySound();
        GameManager.Singleton.reloj.escalaDeTiempo = 0;
        GameManager.Singleton.Nulify();
        //GameManager.Singleton.charController.anim.SetTrigger("Goal");
        GameManager.Singleton.charController.speed = 0;
        GameManager.Singleton.charController.rotationSpeed = 0;
        textGoal.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        CambiarEscena(escena);
    }
}
