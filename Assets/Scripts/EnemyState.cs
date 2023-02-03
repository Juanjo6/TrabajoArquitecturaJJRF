using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    //Enumeraci�n de estados por los que puede pasar el guarda
    public enum STATE
    {
        IDLE, PURSUE,
    };

    //Enumeraci�n de eventos por los que debe pasar cada estado
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    //Estado actual en el que se encuentra el enemigo
    public STATE currentState;
    //Evento actual en el que est� el estado en el que nos encontramos
    protected EVENT currentEvent;
    //Estas referencias son para obtener informaci�n sobre la que vamos a actuar
    protected GameObject npc;
    protected Transform player;
    //Referencia a las clases derivadas por las que nos vamos a mover entre estados
    protected EnemyState nextState;

    //Variables con informaci�n concreta con la que trabajamos
    float visDist = 5.0f;
    float visAngle = 60.0f;

    //Creamos el constructor de la clase State
    public EnemyState(GameObject _npc, Transform _player)
    {
        //Rellenamos las referencias previamente declaradas
        npc = _npc;
        //Al usar el constructor le decimos que para ese estado entrar� en su evento de ENTER
        currentEvent = EVENT.ENTER;
        player = _player;
    }

    //Virtual -> se usa para modificar una declaraci�n de m�todo, propiedad o evento y permite que
    //se invalide en una clase derivada. Cualquier clase que herede este m�todo puede reemplazarlo

    //Creamos unos m�todos para cambiar entre eventos dentro de un estado
    public virtual void Enter() { currentEvent = EVENT.UPDATE; }
    public virtual void Update() { currentEvent = EVENT.UPDATE; }
    public virtual void Exit() { currentEvent = EVENT.EXIT; }

    //Este m�todo nos sirve para cambiar entre los diferentes m�todos que cambian los eventos de un estado
    public EnemyState Process()
    {
        if (currentEvent == EVENT.ENTER) Enter();
        if (currentEvent == EVENT.UPDATE) Update();
        if (currentEvent == EVENT.EXIT)
        {
            Exit();
            //Nos devolver�a el estado al que ir�amos desde el que nos encontramos
            return nextState;
        }
        //Esto nos devolver�a el mismo estado en el que nos encontramos si no nos ha devuelto ning�n otro
        return this;
    }

    //Este m�todo nos sirve para detectar si el npc ve al jugador
    public bool CanSeePlayer()
    {
        //Referencia para conocer la distancia y direcci�n entre el guardia y el jugador
        Vector3 direction = player.position - npc.transform.position;
        // La funci�n angle calcula el �ngulo entre dos vectores
        float angle = Vector3.Angle(direction, npc.transform.forward);
        //Si la distancia entre el jugador y el guardia y tambi�n el �ngulo de este son menores que los estipulados para que nos vea
        if (direction.magnitude < visDist && angle < visAngle)
        {
            //El guardia puede ver al jugador
            return true;
        }
        //Si el guardia no nos puede ver
        return false;
    }

}
