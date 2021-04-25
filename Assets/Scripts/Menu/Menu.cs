using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
public class Menu : MonoBehaviour
{
    public GameObject settingsScreen;
    public GameObject loadingScreen;
    public Slider loadingBar;
    public Slider difficultySlider;
    public FloatVariable difficulty;
    public Slider countdownSlider;
    public FloatVariable initialCountdown;
    public Slider matchTimeSlider;
    public FloatVariable matchTime;

    private void Awake()
    {
        difficultySlider.value = difficulty.value;
        countdownSlider.value = initialCountdown.value;
        matchTimeSlider.value = matchTime.value;
    }

    public void Play()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBar.value = progress;
            yield return null;
        }
    }

    public void Settings()
    {
        settingsScreen.SetActive(!settingsScreen.activeInHierarchy);
    }

    public void Difficulty(float value)
    {
        difficulty.value = value;
    }

    public void Countdown(float value)
    {
        initialCountdown.value = value;
    }

    public void MatchTime(float value)
    {
        matchTime.value = value;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
