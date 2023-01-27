using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{
    [Tooltip("Tiempo incial en segundos")]
    public int tiempoInicial;

    [Tooltip("Escala del tiempo del reloj")]
    [Range(-10.0f, 10.0f)]
    public float escalaDeTiempo = 1;

    private Text miTexto;
    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoAMostrarEnSegundos = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Establecer la escala de tiempo inicial
        //escala = escalaDeTiempo;

        //Componente del texto
        miTexto = GetComponent<Text>();

        //Iniciamos la variable que acumula el tiempo de cada frame con el inicial
        tiempoAMostrarEnSegundos = tiempoInicial;

        ActualizarReloj(tiempoInicial);
    }

    // Update is called once per frame
    void Update()
    {
        //Representamos el tiempo de cada frame considerando la escala de tiempo
        tiempoDelFrameConTimeScale = Time.deltaTime * escalaDeTiempo;
        //Acumulamos el tiempo transcurrido en el juego
        tiempoAMostrarEnSegundos += tiempoDelFrameConTimeScale;
        ActualizarReloj(tiempoAMostrarEnSegundos);
    }   

    void ActualizarReloj(float tiempoEnSegundos)
    {
        int minutos = 0;
        int segundos = 0;
        string textoDelReloj;
        //Aseguramos que el tiempo no sea negativo
        if (tiempoEnSegundos < 0)
        {
            tiempoEnSegundos = 0;
        }

        //Calcular minutos y segundos
        minutos = (int) tiempoEnSegundos / 60;
        segundos = (int) tiempoEnSegundos % 60;

        //Creamos la cadena de caracteres con 2 digitos para los minutos y segundos
        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00");

        //Actualizamos el texto
        miTexto.text = textoDelReloj;
    }
}
