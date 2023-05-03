using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackRenacuajoState : EnemyState
{
    //Usamos el constructor de la clase STATE para pasar todas las referencias necesarias para la consecución correcta de este estado
    //Creo un constructor tomando las cosas que son compartidas con la plantilla de Estado
    public EnemyAttackRenacuajoState(EnemyControllerParent _ecp, GameObject _npc, Transform _transGusano,
        Transform _transMariposa, Transform _transRana, Transform _transRenacuajo, float _speed,
        NavMeshAgent _agent)
        : base(_ecp, _npc, _transGusano, _transMariposa, _transRana, _transRenacuajo, _speed, _agent)
    {
        //El estado actual en este caso es PURSUE
        currentState = STATE.ATTACKRENACUAJO;

    }

    //Sobreescribimos el evento Enter de ese estado 
    public override void Enter()
    {
        //Llamamos al método Enter de la clase State
        base.Enter();
    }

    public override void Update()
    {
        float distanceRenacuajo = Vector3.Distance(transRenacuajo.position, npc.transform.position);

        agent.destination = transRenacuajo.position;   // Por aquí podrá ir el goal quizás

        if (distanceRenacuajo > ecp.visionDistance && !CanSeeRenacuajo())
        {
            //El guardia pasa al estado de patrulla
            nextState = new EnemyMovingState(ecp, npc, transGusano, transMariposa, transRana, transRenacuajo,
                speed, agent);

            //Pasamos al evento de Exit de este estado
            currentEvent = EVENT.EXIT;
        }
        if (CanSeeGusano())
        {
            nextState = new EnemyAttackGusanoState(ecp, npc, transGusano, transMariposa, transRana, transRenacuajo,
                speed, agent);
        }
        if (CanSeeMariposa())
        {
            nextState = new EnemyAttackMariposaState(ecp, npc, transGusano, transMariposa, transRana, transRenacuajo,
                speed, agent);
        }
    }
    //Sobreescribimos el evento Exit de ese estado 
    public override void Exit()
    {
        base.Exit();
    }
}
