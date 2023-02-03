using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public GameObject ball;
    public Transform attackpoint;
    public bool disparar, isActivo;
    public float tiempoDisparo;
    float tiempoDisparoInicio;

    

    private void Start()
    {
        tiempoDisparoInicio = tiempoDisparo;
    }



    void Update()
    {

            if (tiempoDisparo > 0)
            {
                tiempoDisparo -= Time.deltaTime;
                if (disparar)
                {
                    StartCoroutine(disparoCo());

                if (isActivo)
                {
                }

            }
            if (tiempoDisparo <= 0)
            {
                StartCoroutine(tiempoDisparoCo());
            }

        }


    }



    //IEnumerator disparoCo()
    //{


    //    yield return new WaitForSeconds(1f);
    //    Instantiate(ball, attackpoint.position, attackpoint.rotation);


    //}
    IEnumerator disparoCo()
    {
        isActivo = true;

        yield return new WaitForSeconds(0.4f);
        if (isActivo)
        {
            Instantiate(ball, attackpoint.position, attackpoint.rotation);
            isActivo = false;
        }
        yield return new WaitForSeconds(0.4f);




    }

    IEnumerator tiempoDisparoCo()
    {

        yield return new WaitForSeconds(2f);
        tiempoDisparo = tiempoDisparoInicio;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            disparar = true;
        }

    }




    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            disparar = false;
        }
    }
}
