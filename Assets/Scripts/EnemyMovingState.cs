using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovingState : EnemyState
{
    //Usamos el constructor de la clase STATE para pasar todas las referencias necesarias para la consecuci�n correcta de este estado
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
        //Llamamos al m�todo Enter de la clase State
        base.Enter();
    }

    //Sobreescribimos el evento Update de ese estado 
    public override void Update()
    {
        // Aqu� va el c�digo que le hace navegar el nav mesh. Por lo tanto, cada enemigo tendr� un nav mesh distinto

        //Si el guardia puede ver al enemigo
        if (CanSeeGusano())
        {
            //El siguiente estado entonces ser�a el estado de Persecuci�n
            nextState = new EnemyAttackGusanoState(ecp, npc, transGusano, transMariposa, transRana, transRenacuajo,
                speed, agent);
            //El evento ahora ser� EXIT
            currentEvent = EVENT.EXIT;
        }
        if (CanSeeMariposa())
        {
            //El siguiente estado entonces ser�a el estado de Persecuci�n
            nextState = new EnemyAttackMariposaState(ecp, npc, transGusano, transMariposa, transRana, transRenacuajo,
                speed, agent);
            //El evento ahora ser� EXIT
            currentEvent = EVENT.EXIT;
        }
        if (CanSeeRana())
        {
            //El siguiente estado entonces ser�a el estado de Persecuci�n
            nextState = new EnemyAttackRanaState(ecp, npc, transGusano, transMariposa, transRana,  transRenacuajo,
                speed, agent);
            //El evento ahora ser� EXIT
            currentEvent = EVENT.EXIT;
        }
        if (CanSeeRenacuajo())
        {
            //El siguiente estado entonces ser�a el estado de Persecuci�n
            nextState = new EnemyAttackRenacuajoState(ecp, npc, transGusano, transMariposa, transRana,  transRenacuajo,
                speed, agent);
            //El evento ahora ser� EXIT
            currentEvent = EVENT.EXIT;
        }
    }

    //Sobreescribimos el evento Exit de ese estado 
    public override void Exit()
    {
        base.Exit();
    }
}
