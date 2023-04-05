using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Class that manages the different states of the enemy
/// </summary>

[AddComponentMenu("Aventura_Tr�fica/EnemyState")]
public class EnemyState
{
    //Enumeraci�n de estados por los que puede pasar el enemigo
    public enum STATE
    {
        MOVING, ATTACKGUSANO, ATTACKRANA
    };

    //Enumeraci�n de eventos por los que debe pasar cada estado
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    // Referencia usada en vez de un singleton
    protected EnemyControllerParent ecp;

    // Estado actual en el que se encuentra el enemigo. Es p�blico por que le pregunto a d�nde ir.
    public STATE currentState;
    // Evento actual en el que est� el estado en el que nos encontramos
    protected EVENT currentEvent;
    /* Un enemigo es a la vez npc y agente. Trabajador de d�a, superh�roe de d�a tambi�n.*/
    // Estas referencias son para obtener informaci�n sobre la que vamos a actuar
    protected GameObject npc;
    // Uso UnityEngine.AI para mover enemigos por el NavMesh
    protected NavMeshAgent agent;
    // Target
    protected Transform goal;   // Para la navegaci�n
    protected Transform transGusano;
    protected Transform transRana;

    // Referencia a las clases derivadas por las que nos vamos a mover entre estados
    protected EnemyState nextState;
    // Velocidad del enemigo
    protected float speed;

    //Creamos el constructor de la clase State
    public EnemyState(EnemyControllerParent _ecp, GameObject _npc, Transform _transGusano, Transform _transRana, float _speed, 
        NavMeshAgent _agent)
    {
        // Referencia al script padre del enemigo
        ecp = _ecp;
        //Rellenamos las referencias previamente declaradas
        npc = _npc;
        //Al usar el constructor le decimos que para ese estado entrar� en su evento de ENTER
        currentEvent = EVENT.ENTER;
        transGusano = _transGusano;
        transRana = _transRana;
        speed = _speed;
        agent = _agent;
    }

    //Virtual -> se usa para modificar una declaraci�n de m�todo, propiedad o evento y permite que
    //se invalide en una clase derivada. Cualquier clase que herede este m�todo puede reemplazarlo

    //Creamos unos m�todos para cambiar entre eventos dentro de un estado
    public virtual void Enter() { currentEvent = EVENT.UPDATE; }
    public virtual void Update() { currentEvent = EVENT.UPDATE; }
    public virtual void Exit() { currentEvent = EVENT.EXIT; }

    // Method used to change between different stages that group what the enemy can do
    public EnemyState Process()
    {
        if (currentEvent == EVENT.ENTER) Enter();
        if (currentEvent == EVENT.UPDATE) Update();
        if (currentEvent == EVENT.EXIT)
        {
            Exit();
            return nextState;
        }
        return this;
    }

    // Method used to check if the enemy can see the player
    public bool CanSeeGusano()
    {
        // Reference used to check the distance between the owner of this script and his target, tipically enemy and player
        Vector3 direction = transGusano.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        // Debug.Log("angle = " + angle);
        if (direction.magnitude < ecp.visionDistance && angle < ecp.visionAngle && ecp.CanRaycastCharacterGusano)
        {
            return true;
        }

        return false;
    }

    public bool CanSeeRana()
    {
        // Reference used to check the distance between the owner of this script and his target, tipically enemy and player
        Vector3 direction = transRana.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        // Debug.Log("angle = " + angle);
        if (direction.magnitude < ecp.visionDistance && angle < ecp.visionAngle && ecp.CanRaycastCharacterRana)
        {
            // Debug.Log("hola");
            return true;
        }
        return false;
    }
}
