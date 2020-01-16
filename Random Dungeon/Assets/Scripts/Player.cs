using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject
{
    public int wallDamage = 1;
    public int pointsPerFood = 10;
    public int pointsPerPop = 20;
    public float restartLevelDelay = 1f;

    private Animator animator;
    private int food;

    // called before the first frame update
    protected override void Start()
    {
        animator = GetComponent<Animator>();

        food = GameManager.instance.playerFoodPoints;

        base.Start();
    }

    // called when the behaviour becomes disabled or inactive.
    private void OnDisable()
    {
        GameManager.instance.playerFoodPoints = food;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.isPlayerTurn) return;

        int horizontal = 0;
        int vertical = 0;

        horizontal = (int) Input.GetAxisRaw("Horizontal");
        vertical = (int) Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
            vertical = 0;
        }

        if (horizontal != 0 || vertical != 0)
        {
            AttemptMove<Wall> (horizontal, vertical);
        }
    }

    protected override void AttemptMove<T>(int xDirection, int yDirection)
    {
        food --;

        base.AttemptMove<T>(xDirection, yDirection);

        RaycastHit2D hit;

        CheckIfGameOver();

        GameManager.instance.isPlayerTurn = false;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Exit")
        {
            Invoke("Restart", restartLevelDelay);
            enabled = false;
        }
        else if (other.tag == "Food")
        {
            food += pointsPerFood;
            other.gameObject.SetActive(false);
        }
        else if (other.tag == "Soda")
        {
            food += pointsPerPop;
            other.gameObject.SetActive(false);
        }

    }

    protected override void OnCantMove<T>(T component)
    {
        Wall hitWall = component as Wall;
        hitWall.DamageWall(wallDamage);
        animator.SetTrigger("PlayerHit");
    }

    private void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void LoseFood(int loss)
    {
        animator.SetTrigger("PlayerGetHit");
        food -= loss;
        CheckIfGameOver();
    }

    private void CheckIfGameOver()
    {
        if (food <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
