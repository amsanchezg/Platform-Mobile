using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DamagePlayer : MonoBehaviour
{
    [SerializeField] public Collider collider;
    [SerializeField] Event damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //M�todo que va a detectar cuando entramos en el trigger
    private void OnTriggerEnter(Collider other)
    {
         //Si es el jugador el que entra en el trigger
        if (other.gameObject.CompareTag("Player"))
        {

            //Del PlayerHealthController uso la instancia que contiene todo el c�digo, y de este saco el m�todo que necesito
            
            
            
            damage.Ocurred(this.gameObject);


            Debug.Log("me pincha");
        }
    }
    
}
