using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Class that manages the different states of the enemy
/// </summary>

[AddComponentMenu("Aventura_Trófica/EnemyState")]
public class EnemyState
{
    //Enumeración de estados por los que puede pasar el enemigo
    public enum STATE
    {
        MOVING, ATTACKGUSANO, ATTACKRANA, ATTACKMARIPOSA, ATTACKRENACUAJO
    };

    //Enumeración de eventos por los que debe pasar cada estado
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    // Referencia usada en vez de un singleton
    protected EnemyControllerParent ecp;

    // Estado actual en el que se encuentra el enemigo. Es público por que le pregunto a dónde ir.
    public STATE currentState;
    // Evento actual en el que está el estado en el que nos encontramos
    protected EVENT currentEvent;
    /* Un enemigo es a la vez npc y agente. Trabajador de día, superhéroe de día también.*/
    // Estas referencias son para obtener información sobre la que vamos a actuar
    protected GameObject npc;
    // Uso UnityEngine.AI para mover enemigos por el NavMesh
    protected NavMeshAgent agent;
    // Target
    protected Transform goal;   // Para la navegación
    protected Transform transGusano;
    protected Transform transMariposa;
    protected Transform transRana;
    protected Transform transRenacuajo;

    // Referencia a las clases derivadas por las que nos vamos a mover entre estados
    protected EnemyState nextState;
    // Velocidad del enemigo
    protected float speed;

    //Creamos el constructor de la clase State
    public EnemyState(EnemyControllerParent _ecp, GameObject _npc, Transform _transGusano, Transform _transMariposa,
        Transform _transRana, Transform _transRenacuajo, float _speed, NavMeshAgent _agent)
    {
        // Referencia al script padre del enemigo
        ecp = _ecp;
        //Rellenamos las referencias previamente declaradas
        npc = _npc;
        //Al usar el constructor le decimos que para ese estado entrará en su evento de ENTER
        currentEvent = EVENT.ENTER;
        transGusano = _transGusano;
        transMariposa = _transMariposa;
        transRana = _transRana;
        transRenacuajo = _transRenacuajo;
        speed = _speed;
        agent = _agent;
    }

    //Virtual -> se usa para modificar una declaración de método, propiedad o evento y permite que
    //se invalide en una clase derivada. Cualquier clase que herede este método puede reemplazarlo

    //Creamos unos métodos para cambiar entre eventos dentro de un estado
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
            return true;
        }
        return false;
    }
    public bool CanSeeMariposa()
    {
        // Reference used to check the distance between the owner of this script and his target, tipically enemy and player
        Vector3 direction = transMariposa.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        // Debug.Log("angle = " + angle);
        if (direction.magnitude < ecp.visionDistance && angle < ecp.visionAngle && ecp.CanRaycastCharacterMariposa)
        {
            return true;
        }
        return false;
    }
    public bool CanSeeRenacuajo()
    {
        // Reference used to check the distance between the owner of this script and his target, tipically enemy and player
        Vector3 direction = transRenacuajo.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        // Debug.Log("angle = " + angle);
        if (direction.magnitude < ecp.visionDistance && angle < ecp.visionAngle && ecp.CanRaycastCharacterRenacuajo)
        {
            return true;
        }
        return false;
    }
}
