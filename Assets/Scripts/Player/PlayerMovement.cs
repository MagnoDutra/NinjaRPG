using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;

    private PlayerActions actions;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    private void Awake() {
        actions = new PlayerActions();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate() {
        Move();
    }

    private void Move(){
        // MovePosition teletransporta o player para a nova posição, utilizando da física do RB
        // Ele vai calcular toda colisão mas não vai acumular força por exemplo. Por se tratar de fisica
        // Utilizamos a posicao do RB ao inves do GameObject e o FixedUpdate
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }

    private void ReadMovement(){
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
    }

    private void OnEnable() {
        actions.Enable();
    }

    private void OnDisable() {
        actions.Disable();
    }
}
