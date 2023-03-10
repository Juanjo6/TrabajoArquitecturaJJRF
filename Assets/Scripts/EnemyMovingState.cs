using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovingState : EnemyState
{
    //Usamos el constructor de la clase STATE para pasar todas las referencias necesarias para la consecución correcta de este estado
    //Creo un constructor tomando las cosas que son compartidas con la plantilla de Estado
    public EnemyMovingState(EnemyControllerParent _ecp, GameObject _npc, Transform _transGusano, Transform _transRana,
        float _speed, NavMeshAgent _agent)
        : base(_ecp, _npc, _transGusano, _transRana, _speed, _agent)
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
        // Aquí va el código que le hace navegar el nav mesh. Por lo tanto, cada enemigo tendrá un nav mesh distinto

        //Si el guardia puede ver al enemigo
        if (CanSeeGusano() || CanSeeRana())
        {
            //El siguiente estado entonces sería el estado de Persecución
            nextState = new EnemyAttackState(ecp, npc, transGusano, transRana, speed, agent);
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
