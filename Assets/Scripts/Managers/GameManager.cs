using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;

    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            player.ResetPlayer();
        }
    }
}
