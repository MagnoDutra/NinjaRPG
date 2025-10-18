using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private readonly int moveX = Animator.StringToHash("MoveX");
    private readonly int moveY = Animator.StringToHash("MoveY");
    private readonly int moving = Animator.StringToHash("Moving");
    private readonly int dead = Animator.StringToHash("Dead");

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetDeadAnimation()
    {
        anim.SetTrigger(dead);
    }

    public void SetMovingAnimation(bool isMoving)
    {
        anim.SetBool(moving, isMoving);
    }

    public void SetMoveDirectionAnimation(Vector2 direction)
    {
        anim.SetFloat(moveX, direction.x);
        anim.SetFloat(moveY, direction.y);
    }
}
