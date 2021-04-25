using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class HUD : MonoBehaviour
{
    public Character playerChar;
    public Slider lifeSlider;
    public GameObject pauseScreen;
    public FloatVariable currentAmmo;
    public TMP_Text ammoText;
    public TMP_Text timeText;
    public TMP_Text countdownText;
    public FloatVariable countdownTime;
    public GameObject finalScreen;
    public TMP_Text killsText;
    public TMP_Text pointText;

    private void Awake()
    {
        StartCoroutine(Countdown());
    }

    private void Update()
    {
        ammoText.text = currentAmmo.value.ToString() + " Arrows";
        timeText.text = GameManager.time.ToString("F0") + " Tempo faltando";
        
        if (Input.GetKeyDown(KeyCode.Escape) && GameManager.matchEnded == false)
        {
            PauseButton();
        }
    }

    public void UpdateLife()
    {
        lifeSlider.value = playerChar.life;
    }

    public void PauseButton()
    {
        pauseScreen.SetActive(!pauseScreen.activeInHierarchy);
        GameManager.isPaused = !GameManager.isPaused;

        if (!pauseScreen.activeInHierarchy) Cursor.lockState = CursorLockMode.Locked;
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void FinalScreen()
    {
        finalScreen.SetActive(true);
        killsText.text = "Matou: " + PointsController.kills.ToString();
        pointText.text = "Pontos: " + PointsController.points.ToString();
    }

    IEnumerator Countdown()
    {
        float count = countdownTime.value;
        countdownText.text = count.ToString();

        for (int i = 0; i < countdownTime.value; i++)
        {

            yield return new WaitForSeconds(1f);

            count--;
            countdownText.text = count.ToString();
        }

        countdownText.gameObject.SetActive(false);
        GameManager.isPaused = false;
    }
}
