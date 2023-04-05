using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackGusanoState : EnemyState
{
    //Usamos el constructor de la clase STATE para pasar todas las referencias necesarias para la consecución correcta de este estado
    //Creo un constructor tomando las cosas que son compartidas con la plantilla de Estado
    public EnemyAttackGusanoState(EnemyControllerParent _ecp, GameObject _npc, Transform _transGusano, Transform _transRana,
        float _speed, NavMeshAgent _agent)
        : base(_ecp, _npc, _transGusano, _transRana, _speed, _agent)
    {
        //El estado actual en este caso es PURSUE
        currentState = STATE.ATTACKGUSANO;

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

        agent.destination = transGusano.position;   // Por aquí podrá ir el goal quizás

        if(distanceGusano > ecp.visionDistance && !CanSeeGusano())
        {
            //El guardia pasa al estado de patrulla
            nextState = new EnemyMovingState(ecp, npc, transGusano, transRana, speed, agent);

            //Pasamos al evento de Exit de este estado
            currentEvent = EVENT.EXIT;

            // Esto se usaba para disparar
            // Spawner.singleton.Shooting();
        }
        if (CanSeeRana())
        {
            nextState = new EnemyAttackRanaState(ecp, npc, transGusano, transRana, speed, agent);
        }
    }
    //Sobreescribimos el evento Exit de ese estado 
    public override void Exit()
    {
        base.Exit();
    }
}
