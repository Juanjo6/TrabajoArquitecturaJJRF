using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovingState : EnemyState
{
    int currentIndex = -1;
    float waypointMaxDistance = 1000;
    int uno = 1;
    int zero = 0;

    //Usamos el constructor de la clase STATE para pasar todas las referencias necesarias para la consecución correcta de este estado
    //Creo un constructor tomando las cosas que son compartidas con la plantilla de Estado
    public EnemyMovingState(EnemyControllerParent _ecp, GameObject _npc, Transform _transGusano, Transform _transMariposa,
        Transform _transRana, Transform _transRenacuajo, float _speed, NavMeshAgent _agent)
        : base(_ecp, _npc, _transGusano, _transMariposa, _transRana, _transRenacuajo, _speed, _agent)
    {
        //El estado actual en este caso es IDLE
        currentState = STATE.MOVING;
    }

    //Sobreescribimos el evento Enter de ese estado 
    public override void Enter()
    {
        //Llamamos al método Enter de la clase State
        base.Enter();
    }

    //Sobreescribimos el evento Update de ese estado 
    public override void Update()
    {
       /* //Si la distancia del agent al punto de patrulla es menor que 1
        //Esto equivale al operador ternario de abajo
        if (agent.remainingDistance < uno)
        {
            //Si he llegado al final de la lista de puntos
            if (currentIndex >= ecp.Checkpoints.Count - uno)
                //Comenzamos la lista de nuevo por el principio
                currentIndex = zero;
            else
                //Pasamos al siguiente punto de patrulla de la lista
                currentIndex++;
            //Le pasamos el destino de patrulla
            agent.SetDestination(ecp.Checkpoints[currentIndex].position);
        }*/

            //Si el guardia puede ver al enemigo
        if (CanSeeGusano())
        {
            //El siguiente estado entonces sería el estado de Persecución
            nextState = new EnemyAttackGusanoState(ecp, npc, transGusano, transMariposa, transRana, transRenacuajo,
                speed, agent);
            //El evento ahora será EXIT
            currentEvent = EVENT.EXIT;
        }
        if (CanSeeMariposa())
        {
            //El siguiente estado entonces sería el estado de Persecución
            nextState = new EnemyAttackMariposaState(ecp, npc, transGusano, transMariposa, transRana, transRenacuajo,
                speed, agent);
            //El evento ahora será EXIT
            currentEvent = EVENT.EXIT;
        }
        if (CanSeeRana())
        {
            //El siguiente estado entonces sería el estado de Persecución
            nextState = new EnemyAttackRanaState(ecp, npc, transGusano, transMariposa, transRana,  transRenacuajo,
                speed, agent);
            //El evento ahora será EXIT
            currentEvent = EVENT.EXIT;
        }
        if (CanSeeRenacuajo())
        {
            //El siguiente estado entonces sería el estado de Persecución
            nextState = new EnemyAttackRenacuajoState(ecp, npc, transGusano, transMariposa, transRana,  transRenacuajo,
                speed, agent);
            //El evento ahora será EXIT
            currentEvent = EVENT.EXIT;
        }
    }

    //Sobreescribimos el evento Exit de ese estado 
    public override void Exit()
    {
        base.Exit();
    }
}
