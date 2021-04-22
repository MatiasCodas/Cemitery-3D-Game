using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : StateAI
{
    public readonly Enemy enemy;

	public Animator animController;
    private BotFSM stateMachine;
    public Attack(BotFSM _stateMachine, Enemy _enemy, Animator _animController)
    {
		stateMachine = _stateMachine;
        enemy = _enemy;
		animController = _animController;
    }

    public override void EntryAction()
    {
		animController.SetTrigger("Attack");
    }

    public override void ExitAction()
    {
    }

    public override void UpdateAction()
    {
		stateMachine.AttackCooldown();
    }
}
