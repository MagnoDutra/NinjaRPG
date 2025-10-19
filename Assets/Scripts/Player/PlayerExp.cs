using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerExp : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private PlayerStats stats;

    void Update()
    {
        if (Keyboard.current.xKey.wasPressedThisFrame)
        {
            AddExp(300f);
        }
    }

    public void AddExp(float amount)
    {
        stats.CurrentExp += amount;
        while (stats.CurrentExp >= stats.NextLevelExp)
        {
            stats.CurrentExp -= stats.NextLevelExp;
            NextLevel();
        }
    }

    public void NextLevel()
    {
        stats.Level++;

        float currentExpRequiredToLevelUp = stats.NextLevelExp;
        float newNextLevelExp = Mathf.Round(currentExpRequiredToLevelUp + stats.NextLevelExp * (stats.ExpMultiplier / 100f));
        stats.NextLevelExp = newNextLevelExp;
    }
}
