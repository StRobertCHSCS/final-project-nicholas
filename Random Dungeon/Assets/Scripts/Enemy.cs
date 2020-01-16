using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject
{
    public int playerDamage;


    private Animator animator;
    private Transform target;
    private bool skipMove;

    // called before the first frame update
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
    }

    protected override void AttemptMove<T>(int xDirection, int yDirection)
    {
        if (skipMove == true)
        {
            skipMove = false;
            return;
        }

        base.AttemptMove<T>(xDirection, yDirection);

        skipMove = true;
    }

    public void MoveEnemy()
    {
        int xDirection = 0;
        int yDirection = 0;

        if (Mathf.Abs(target.position.x - transform.position.x) < float.Epsilon )
        {
            yDirection = target.position.y > transform.position.y ? 1 : -1;
        }
        else
        {
            xDirection = target.position.x > transform.position.x ? 1 : -1;
        }

        AttemptMove <Player> (xDirection, yDirection);
    }

    protected override void OnCantMove<T>(T component)
    {
        Player hitPlayer = component as Player;

        hitPlayer.LoseFood(playerDamage);
    }
}
