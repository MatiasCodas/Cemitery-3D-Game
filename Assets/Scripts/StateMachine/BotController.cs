using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BotFSM))]
public class BotController : MonoBehaviour
{
    private BotFSM botFSM;

    public Transform player;

    [SerializeField] private float attackDistance = 3f;
    public LayerMask playerMask;
    public bool canAttack;


    void Start()
    {
        botFSM = GetComponent<BotFSM>();
    }

    private void Update()
    {
        botFSM.Follow();
        canAttack = Physics.CheckSphere(gameObject.transform.position, attackDistance, playerMask);

        if (canAttack)
        {
            botFSM.Attack();
        }
    }

}
