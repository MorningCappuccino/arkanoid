using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _gameOverScreen;

    public static UIController Instance;

    private void Awake() {
        Instance = this;
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    public void ShowGameOverScreen()
    {
        _gameOverScreen.SetActive(true);
    }

    public void ReloadButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
