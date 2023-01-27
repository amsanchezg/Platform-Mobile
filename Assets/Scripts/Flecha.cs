using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flecha : MonoBehaviour
{

    public float velX, velY, VelZ;

    public float time;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(velX, velY, VelZ);
        StartCoroutine(DestruirCo());
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("AH ME HA DADO");
            //Inicializar explosi�n o algo
            Destroy(gameObject);
            //Damage Player
            GameManager.Singleton.charController.DamageImpulse();
            GameManager.Singleton.playerLifes.DamagePlayer();
        }
    }


    IEnumerator DestruirCo()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
