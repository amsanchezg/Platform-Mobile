using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    //Objeto sobre el que actuara esta clase
    public GameObject actor;
    //Referencia al animator de ese personaje
    Animator _anim;
    //Instancias a la clase Command en su totalidad o a la parte de ella que queramos
    Command keyJump, keyPunching, keyKicking, keyMove;
    //Lista donde guardar comandos ya ejecutados
    List<Command> oldCommands = new List<Command>();

    Coroutine replayCoroutine;
    //¿Debo empezar a reproducir de nuevo los comandos ya introducidos?
    bool shouldStartReplay;
    //¿Se estan reproduciendo ya los comandos guardados?
    bool isReplaying;
    // Start is called before the first frame update
    void Start()
    {
        //Declaramos para que sirve cada una de esas instancias
        keyJump = new PerfomJump(); //Hariamos la llamada a la clase de salto en esa instancia, por lo tanto se ejecutaria lo que contiene esa clase
        keyMove = new MoveForward();
        //Inicializamos la referencia del Animator del personaje sobre el que queremos que actue el script
        _anim = actor.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //Si no se estan reproduciendo los comandos guardados
        if (!isReplaying)
        {
            HandleInput();
            StartReplay();
        }


    }

    void HandleInput()
    {
        //Asignamos la accion a una tecla concreta
        if (SimpleInput.GetKeyDown(KeyCode.Space))
        {
            //Ejecutamos el metodo execute de la clase derivada asignada a la referencia
            keyJump.Execute(_anim, true);
            //Añadimos el comando a la lista de comandos usados
            oldCommands.Add(keyJump);
        }
        else if (SimpleInput.GetKeyDown(KeyCode.UpArrow) || SimpleInput.GetKeyDown(KeyCode.W))
        {
            keyMove.Execute(_anim, true);
            //Añadimos el comando a la lista de comandos usados
            oldCommands.Add(keyMove);
        }

        //Reproducimos los comandos guardados
        if (Input.GetKeyDown(KeyCode.X))
        {
            shouldStartReplay = true;
        }

        //Con la tecla Z borramos el ultimo comando guardado
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UndoLastCommand();
        }
    }

    void UndoLastCommand()
    {
        //Creamos una instancia para el ultimo comando guardado
        Command c = oldCommands[oldCommands.Count - 1];
        //Lo reproducimos
        c.Execute(_anim, true);
        //Lo borramos de la lista de comandos guardados
        oldCommands.RemoveAt(oldCommands.Count - 1);
    }

    void StartReplay()
    {
        //Si debo empezar a reproducir los comandos guardados y tengo algun comando guardado
        if (shouldStartReplay && oldCommands.Count > 0)
        {
            shouldStartReplay = false;
            //Si se esta reproduciendo una coroutina que se pare
            if (replayCoroutine != null)
            {
                StopCoroutine(replayCoroutine);
            }
            replayCoroutine = StartCoroutine(ReplayCommands());
        }

        IEnumerator ReplayCommands()
        {
            //Se esta reproduciendo los comandos guardados
            isReplaying = true;

            //Pasa por los comandos guardados de uno en uno mientras pueden
            for (int i = 0; i < oldCommands.Count; i++)
            {
                //Ejecuta comando por comando
                oldCommands[i].Execute(_anim, true);
                //Espera 1 segundo entre cada comando
                yield return new WaitForSeconds(1f);
            }

            //Ya no se esta reproduciendo los comandos guardados
            isReplaying = false;
        }
    }
}
