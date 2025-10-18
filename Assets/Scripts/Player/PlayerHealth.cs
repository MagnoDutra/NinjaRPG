using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    private PlayerAnimations playerAnimations;

    void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            TakeDamage(1f);
        }
    }

    public void TakeDamage(float amount)
    {
        stats.Health -= amount;
        if (stats.Health <= 0f)
        {
            PlayerDead();
        }
    }

    private void PlayerDead()
    {
        playerAnimations.SetDeadAnimation();
    }
}
