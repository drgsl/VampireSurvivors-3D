using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGamePaused = false;

    public static SUPERCharacter.SUPERCharacterAIO player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<SUPERCharacter.SUPERCharacterAIO>();
    }

    public static void Pause()
    {
        Enemy.PauseAllEnemies();
        player.PausePlayer();
    }
    public static void Unpause()
    {
        Enemy.unPauseAllEnemies();
        player.UnpausePlayer();
    }
}
