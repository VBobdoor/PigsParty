using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(AnimationController))]
public class Agent : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private Transform target;

    private AnimationController animationController;
    private NavMeshAgent agent;
    private float animationChangeCooldown = 0.2f;
    private bool ableToChangeAnimation = true;
    private bool isAlive = true;

    public EnemySpawner EnemySpawner
    {
        set { enemySpawner = value;  }
    }

    public Transform Target
    {
        set{ target = value; }
    }


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animationController = GetComponent<AnimationController>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (isAlive)
        {
            agent.SetDestination(target.position);
            if (ableToChangeAnimation)
                SetAnimation();
        }     
    }

    public void TakeDamage()
    {
        enemySpawner.enemyDead();
        isAlive = false;
        agent.velocity = Vector3.zero;
        agent.updatePosition = false;
        animationController.SetTakeDamageAnimation();
    }

    private void SetAnimation()
    {
        float horizontalDirection = agent.velocity.x;
        float verticalDirection = agent.velocity.y;

        if (Math.Abs(horizontalDirection) < 0.1)
            horizontalDirection = 0;
        if (Math.Abs(verticalDirection) < 0.1)
            verticalDirection = 0;

        animationController.SetAnimation(horizontalDirection, verticalDirection);
        StartCoroutine(SetAnimationChangeCooldown());
    }

    private IEnumerator SetAnimationChangeCooldown()
    {
        ableToChangeAnimation = false;
        yield return new WaitForSeconds(animationChangeCooldown);
        ableToChangeAnimation = true;
    }
}
