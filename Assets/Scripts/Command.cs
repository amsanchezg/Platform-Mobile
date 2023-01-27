using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    //Clase abstracta -> nos sirve para declarar funcionalidades que no forman en si mismas un objeto
public abstract class Command
{
  //Creamos una funcion a la que le pasaremos por parametro una referencia a un Animator, que para este ejemplo nos va a servir para cambiar las animaciones de un personaje
  //Esto es una plantilla de una clase para poder hacer clases derivadas que usen lo que haya dentro de esta plantilla
    public abstract void Execute(Animator anim, bool forward);
}

public class MoveForward : Command
{
    public override void Execute(Animator anim, bool forward)
    {
        if (forward)
            //Se activara la animacion de caminar al ejecutar este metodo 
            anim.SetTrigger("isMoving");
        
    }
}

public class PerfomJump : Command
{
    //Con override al llamar a este metodo sobreescribiremos cualquier otro metodo que se estuviera ejecutando
    public override void Execute(Animator anim, bool forward)
    {
        if (forward)
            //Se activara la animacion de salto al ejecutar este metodo 
            anim.SetTrigger("Salto");
        


    }
}

