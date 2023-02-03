using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootState : EnemyState
{

    //Usamos el constructor de la clase STATE para pasar todas las referencias necesarias para la consecuci�n correcta de este estado
    //Creo un constructor tomando las cosas que son compartidas con la plantilla de Estado
    public EnemyShootState(GameObject _npc, Transform _player)
        : base(_npc, _player)
    {
        //El estado actual en este caso es PURSUE
        currentState = STATE.PURSUE;
    }

    //Sobreescribimos el evento Enter de ese estado 
    public override void Enter()
    {
        //Llamamos al m�todo Enter de la clase State
        base.Enter();
    }

    public override void Update()

    {
        if (!CanSeePlayer())
        {
            //El guardia pasa al estado de patrulla
            nextState = new EnemyIdleState(npc, player);
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
