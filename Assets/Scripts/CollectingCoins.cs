using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCoins : MonoBehaviour
{

    [SerializeField] public Event pickUp;
    private int valorMonedas = 1;
    public GameObject effect;
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //PARA EL NUEVO SISTEMA DE CONTAR

            NuevoCoinManager.LevelCoins++;

            //FIN DEL NUEVO SISTEMA DE CONTAR;

            pickUp.Ocurred(this.gameObject);
            GameManager.Singleton.Sounds.CoinsSound();
            Instantiate(effect, transform.position, transform.rotation);
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
