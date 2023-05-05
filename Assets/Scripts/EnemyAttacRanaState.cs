using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttackRanaState : EnemyState
{
    //Usamos el constructor de la clase STATE para pasar todas las referencias necesarias para la consecuci�n correcta de este estado
    //Creo un constructor tomando las cosas que son compartidas con la plantilla de Estado
    public EnemyAttackRanaState(EnemyControllerParent _ecp, GameObject _npc, Transform _transGusano,
        Transform _transMariposa, Transform _transRana, Transform _transRenacuajo, float _speed, 
        NavMeshAgent _agent)
        : base(_ecp, _npc, _transGusano, _transMariposa, _transRana, _transRenacuajo, _speed, _agent)
    {
        //El estado actual en este caso es PURSUE
        currentState = STATE.ATTACKRANA;

    }

    //Sobreescribimos el evento Enter de ese estado 
    public override void Enter()
    {
        //Llamamos al m�todo Enter de la clase State
        base.Enter();
    }

    public override void Update()
    {
        float distanceRana = Vector3.Distance(transRana.position, npc.transform.position);

        agent.destination = transRana.position;   // Por aqu� podr� ir el goal quiz�s

        if (distanceRana > ecp.visionDistance && !CanSeeRana())
        {
            //El guardia pasa al estado de patrulla
            nextState = new EnemyMovingState(ecp, npc, transGusano, transMariposa, transRana, transRenacuajo,
                speed, agent);

            //Pasamos al evento de Exit de este estado
            currentEvent = EVENT.EXIT;
        }
        if (CanSeeMariposa())
        {
            nextState = new EnemyAttackMariposaState(ecp, npc, transGusano, transMariposa, transRana, transRenacuajo,
                speed, agent);

            currentEvent = EVENT.EXIT;
        }
    }
    //Sobreescribimos el evento Exit de ese estado 
    public override void Exit()
    {
        base.Exit();
    }
}
