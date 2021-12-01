using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    private const string goingRightVarName = "Right";
    private const string goingLefttVarName = "Left";
    private const string goingTopVarName = "Top";
    private const string goingBottomVarName = "Bottom";
    private const string takeDanageVarName = "TakeDamage";
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnimation(float horizontalDeltaDirection, float verticalDeltaDirection)
    {
        string directionVarName = GetDirectionMoveVarName(horizontalDeltaDirection, verticalDeltaDirection);
        animator.SetTrigger(directionVarName);
    }

    private String GetDirectionMoveVarName(float horizontalDeltaDirection, float verticalDeltaDirection)
    {
        if (Math.Abs(horizontalDeltaDirection) > Math.Abs(verticalDeltaDirection))
        {
            if (horizontalDeltaDirection < 0)
                return goingLefttVarName;
            else
                return goingRightVarName;
        }
        else
        {
            if (verticalDeltaDirection < 0)
                return goingBottomVarName;
            else
                return goingTopVarName;
        }
    }

    public void SetTakeDamageAnimation()
    {
        animator.SetTrigger(takeDanageVarName);
    }
}
