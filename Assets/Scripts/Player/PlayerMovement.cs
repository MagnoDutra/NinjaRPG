using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    private readonly int moveX = Animator.StringToHash("MoveX");
    private readonly int moveY = Animator.StringToHash("MoveY");
    private readonly int isMoving = Animator.StringToHash("Moving");

    private PlayerActions actions;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private Animator anim;

    private void Awake()
    {
        actions = new PlayerActions();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // MovePosition teletransporta o player para a nova posição, utilizando da física do RB
        // Ele vai calcular toda colisão mas não vai acumular força por exemplo. Por se tratar de fisica
        // Utilizamos a posicao do RB ao inves do GameObject e o FixedUpdate
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }

    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;

        if (moveDirection == Vector2.zero)
        {
            anim.SetBool(isMoving, false);
            return;
        }

        anim.SetBool(isMoving, true);
        anim.SetFloat(moveX, moveDirection.x);
        anim.SetFloat(moveY, moveDirection.y);

    }

    // Liga os Actions inputs criados
    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
