using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isPaused;
    public static bool matchEnded;
    public static float time;
    public FloatVariable matchTime;
    public HUD hud;
    public Character playerChar;

    private void Awake()
    {
        isPaused = true;
        matchEnded = false;
        time = matchTime.value * 60;
    }

    private void Update()
    {
        if (isPaused) return;

        time -= Time.deltaTime;

        if (time <= 0)
        {
            EndMatch();
        }

        if (playerChar.life <= 0)
        {
            EndMatch();
        }
    }

    private void EndMatch()
    {
        isPaused = true;
        matchEnded = true;
        hud.FinalScreen();
    }

}
