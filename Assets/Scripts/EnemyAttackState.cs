using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackState : EnemyState
{
    //Usamos el constructor de la clase STATE para pasar todas las referencias necesarias para la consecución correcta de este estado
    //Creo un constructor tomando las cosas que son compartidas con la plantilla de Estado
    public EnemyAttackState(EnemyControllerParent _ecp, GameObject _npc, Transform _player, float _speed, NavMeshAgent _agent)
        : base(_ecp, _npc, _player, _speed, _agent)
    {
        //El estado actual en este caso es PURSUE
        currentState = STATE.ATTACK;

    }

    //Sobreescribimos el evento Enter de ese estado 
    public override void Enter()
    {
        //Llamamos al método Enter de la clase State
        base.Enter();
    }

    public override void Update()
    {
        float distance = Vector3.Distance(player.position, npc.transform.position);

        if(CanSeePlayer())
        {
            agent.destination = player.position;    // Por aquí podrá ir el goal
        }
        else if(distance > ecp.visionDistance)
        {
            //El guardia pasa al estado de patrulla
            nextState = new EnemyMovingState(ecp, npc, player, speed, agent);
            //Pasamos al evento de Exit de este estado
            currentEvent = EVENT.EXIT;
            // float step = speed * Time.deltaTime;
            // npc.transform.position = Vector3.MoveTowards(npc.transform.position, player.position, step);

            // Si el npc colisiona con el jugador, hará una animación y bajará su velocidad

            // Esto se usaba para disparar
            // Spawner.singleton.Shooting();
        }
    }
    //Sobreescribimos el evento Exit de ese estado 
    public override void Exit()
    {
        base.Exit();
    }
}
