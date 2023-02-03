using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    //Usamos el constructor de la clase STATE para pasar todas las referencias necesarias para la consecuci�n correcta de este estado
    //Creo un constructor tomando las cosas que son compartidas con la plantilla de Estado
    public EnemyIdleState(GameObject _npc, Transform _player)
        : base(_npc, _player)
    {
        //El estado actual en este caso es IDLE
        currentState = STATE.IDLE;
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
        //Si el guardia puede ver al enemigo
        if (CanSeePlayer())
        {
            //El siguiente estado entonces ser�a el estado de Persecuci�n
            nextState = new EnemyShootState(npc, player);
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
