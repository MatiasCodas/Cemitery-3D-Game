using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States { Follow, Idle, Attack, None }
public class BotFSM : StateMachine
{

    private Enemy enemy;
    public States firstState = States.None;
    public States secondState = States.None;

    private Follow followState;
    private Attack attackState;

    public Animator animController;

    [SerializeField] private float cooldownTime = 1f;
    private float cooldown;
    private bool inCooldown;
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    public void Follow()
    {
        if (followState == null) { followState = new Follow(this, enemy, animController); }
        if (firstState != States.Follow)
        {
            SetState01(followState);
            firstState = States.Follow;
        }
    }

    public void Attack()
    {
		if(inCooldown) return;
        if (attackState == null) { attackState = new Attack(this, enemy, animController); }
        if (secondState != States.Attack)
        {
            SetState02(attackState);
            secondState = States.Attack;
        }
    }

    public void AttackCooldown()
    {
        inCooldown = true;
        cooldown += Time.deltaTime;

        if (cooldown >= cooldownTime)
        {
            inCooldown = false;
            cooldown = 0;
			ResetState(2);
        }
    }

    public void ResetState(int index)
    {
        if (index == 1 && firstState != States.None)
        {
            firstState = States.None;
        }

        else if (index == 2 && secondState != States.None)
        {
            secondState = States.None;
        }
    }
}
