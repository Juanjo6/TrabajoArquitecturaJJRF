using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    //Usamos el constructor de la clase STATE para pasar todas las referencias necesarias para la consecución correcta de este estado
    //Creo un constructor tomando las cosas que son compartidas con la plantilla de Estado
    public EnemyAttackState(GameObject _npc, Transform _player, float _speed)
        : base(_npc, _player, _speed)
    {
        //El estado actual en este caso es PURSUE
        currentState = STATE.ATTACK;
    }

    //Sobreescribimos el evento Enter de ese estado 
    public override void Enter()
    {
        //Llamamos al método Enter de la clase State
        base.Enter();
    }

    public override void Update()

    {
        if (!CanSeePlayer())
        {
            //El guardia pasa al estado de patrulla
            nextState = new EnemyMovingState(npc, player, speed);
            //Pasamos al evento de Exit de este estado
            currentEvent = EVENT.EXIT;
        }

        float step = speed * Time.deltaTime;

        npc.transform.position = Vector3.MoveTowards(npc.transform.position, player.position, step);

        // Esto se usaba para disparar
        // Spawner.singleton.Shooting();
    }
    //Sobreescribimos el evento Exit de ese estado 
    public override void Exit()
    {
        base.Exit();
    }
}
