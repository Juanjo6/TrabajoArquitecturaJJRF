using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingState : EnemyState
{
    //Usamos el constructor de la clase STATE para pasar todas las referencias necesarias para la consecución correcta de este estado
    //Creo un constructor tomando las cosas que son compartidas con la plantilla de Estado
    public EnemyMovingState(GameObject _npc, Transform _player, float _speed)
        : base(_npc, _player, _speed)
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
        //Si el guardia puede ver al enemigo
        if (CanSeePlayer())
        {
            //El siguiente estado entonces sería el estado de Persecución
            nextState = new EnemyAttackState(npc, player, speed);
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
