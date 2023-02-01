using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] Transform[] puntosVista;
    [SerializeField] float velocidadTransicion; //velocidad para la transicion entre camaras
    [SerializeField] Transform puntoVistaActual;
    // Start is called before the first frame update
    void Start()
    {
        puntoVistaActual = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            puntoVistaActual = puntosVista[1];
        }
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, puntoVistaActual.position, Time.deltaTime * velocidadTransicion);
    }
}
