using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackRanaState : EnemyState
{
    //Usamos el constructor de la clase STATE para pasar todas las referencias necesarias para la consecución correcta de este estado
    //Creo un constructor tomando las cosas que son compartidas con la plantilla de Estado
    public EnemyAttackRanaState(EnemyControllerParent _ecp, GameObject _npc, Transform _transGusano, Transform _transRana,
        float _speed, NavMeshAgent _agent)
        : base(_ecp, _npc, _transGusano, _transRana, _speed, _agent)
    {
        //El estado actual en este caso es PURSUE
        currentState = STATE.ATTACKRANA;

    }

    //Sobreescribimos el evento Enter de ese estado 
    public override void Enter()
    {
        //Llamamos al método Enter de la clase State
        base.Enter();
    }

    public override void Update()
    {
        float distanceRana = Vector3.Distance(transRana.position, npc.transform.position);

        agent.destination = transRana.position;   // Por aquí podrá ir el goal quizás

        if (distanceRana > ecp.visionDistance && !CanSeeRana())
        {
            //El guardia pasa al estado de patrulla
            nextState = new EnemyMovingState(ecp, npc, transGusano, transRana, speed, agent);

            //Pasamos al evento de Exit de este estado
            currentEvent = EVENT.EXIT;
        }
    }
    //Sobreescribimos el evento Exit de ese estado 
    public override void Exit()
    {
        base.Exit();
    }
}
