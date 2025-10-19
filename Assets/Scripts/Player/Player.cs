using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    public PlayerStats Stats => stats;

    private PlayerAnimations playerAnimations;

    void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    public void ResetPlayer()
    {
        stats.ResetPlayer();
        playerAnimations.ResetPlayerAnimation();
    }
}
