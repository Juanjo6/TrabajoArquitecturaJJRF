using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that manages the different states of the enemy
/// </summary>

[AddComponentMenu("Aventura_Trófica/EnemyState")]
public class EnemyState
{
    //Enumeración de estados por los que puede pasar el guarda
    public enum STATE
    {
        MOVING, ATTACK,
    };

    //Enumeración de eventos por los que debe pasar cada estado
    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    };

    //Estado actual en el que se encuentra el enemigo
    public STATE currentState;
    //Evento actual en el que está el estado en el que nos encontramos
    protected EVENT currentEvent;
    //Estas referencias son para obtener información sobre la que vamos a actuar
    protected GameObject npc;
    protected Transform player;
    //Referencia a las clases derivadas por las que nos vamos a mover entre estados
    protected EnemyState nextState;
    // Velocidad del enemigo
    protected float speed;

    //Variables con información concreta con la que trabajamos
    float visDist = 5.0f;
    float visAngle = 60.0f;

    //Creamos el constructor de la clase State
    public EnemyState(GameObject _npc, Transform _player, float _speed)
    {
        //Rellenamos las referencias previamente declaradas
        npc = _npc;
        //Al usar el constructor le decimos que para ese estado entrará en su evento de ENTER
        currentEvent = EVENT.ENTER;
        player = _player;
        speed = _speed;
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
    public bool CanSeePlayer()
    {
        // Reference used to check the distance between the owner of this script and his target, tipically enemy and player
        Vector3 direction = player.position - npc.transform.position;
        float angle = Vector3.Angle(direction, npc.transform.forward);
        if (direction.magnitude < visDist && angle < visAngle)
        {
            return true;
        }
        return false;
    }
}
