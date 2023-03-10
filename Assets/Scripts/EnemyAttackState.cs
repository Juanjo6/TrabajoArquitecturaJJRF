using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackState : EnemyState
{
    //Usamos el constructor de la clase STATE para pasar todas las referencias necesarias para la consecución correcta de este estado
    //Creo un constructor tomando las cosas que son compartidas con la plantilla de Estado
    public EnemyAttackState(EnemyControllerParent _ecp, GameObject _npc, Transform _transGusano, Transform _transRana,
        float _speed, NavMeshAgent _agent)
        : base(_ecp, _npc, _transGusano, _transRana, _speed, _agent)
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
        float distanceGusano = Vector3.Distance(transGusano.position, npc.transform.position);
        float distanceRana = Vector3.Distance(transRana.position, npc.transform.position);

        if (CanSeeGusano() || CanSeeRana())
        {
            if (CanSeeGusano())
            {
                agent.destination = transGusano.position;    // Por aquí podrá ir el goal quizás
            }
            
            if (CanSeeRana())
            {
                agent.destination = transRana.position;
            }
        }
        else if(distanceGusano > ecp.visionDistance && distanceRana > ecp.visionDistance)
        {
            //El guardia pasa al estado de patrulla
            nextState = new EnemyMovingState(ecp, npc, transGusano, transRana, speed, agent);
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
