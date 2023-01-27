using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UILifes : MonoBehaviour
{
   
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        healthText.text = GameManager.Singleton.playerLifes.currentHealth.ToString("5");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
