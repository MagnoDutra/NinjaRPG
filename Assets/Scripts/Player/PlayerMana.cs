using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMana : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            UseMana(1f);
        }
    }

    public void UseMana(float amount)
    {
        if (stats.Mana >= amount)
        {

            stats.Mana = Mathf.Max(0f, stats.Mana - amount);
        }
    }
}
