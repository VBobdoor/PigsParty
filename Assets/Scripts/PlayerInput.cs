using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(AnimationController))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Joystick joystick;

    private PlayerMovement playerMovement;
    private AnimationController animator;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<AnimationController>();
    }

    private void FixedUpdate()
    {
        float horizontalDirection = joystick.Horizontal;
        if (Math.Abs(horizontalDirection) < 0.1)
            horizontalDirection = 0;

        float verticalDirection = joystick.Vertical;
        if (Math.Abs(verticalDirection) < 0.1)
            verticalDirection = 0;

        if(horizontalDirection != 0 || verticalDirection !=0)
            animator.SetAnimation(horizontalDirection, verticalDirection);
        playerMovement.Move(horizontalDirection * Time.fixedDeltaTime, verticalDirection * Time.fixedDeltaTime);
    }

}
