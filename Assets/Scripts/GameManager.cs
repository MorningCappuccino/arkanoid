using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _levels;
    [SerializeField] private UnityEvent<int> UIUpdate; 
    [SerializeField] private Ball ball;
    public AudioSource Audio;

    public static event Action<int> OnUpdateLifeUI;

    private const int MAX_LIFE = 3;
    private int _life;
    private int _overallScore;
    private int _currentLevel = 0;

    private int _blockToDestroy;
    private int _destroydBlock = 0;

    public static GameManager Instance;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        LoadLevel(_currentLevel);
        _life = MAX_LIFE;
    }

    private void OnEnable()
    {
        Ball.OnLost += LostLife;
        Brick.OnDestroyed += AddScore;
    }

    private void OnDisable()
    {
        Ball.OnLost -= LostLife;
        Brick.OnDestroyed -= AddScore;
    }

    private void AddScore(int score)
    {
        _destroydBlock++;
        _overallScore += score;
        UIUpdate?.Invoke(_overallScore);

        if (_destroydBlock >= _blockToDestroy)
        {
            _currentLevel++;
            LoadLevel(_currentLevel);
            ball.Reset();
        }
    }

    private void LoadLevel(int level)
    {
        GameObject currentLevel = Instantiate(_levels[level]);
        _blockToDestroy = currentLevel.GetComponent<Level>().blocksCount;
        _destroydBlock = 0;
    }

    private void LostLife()
    {
        _life--;
        if (_life < 1)
        {
            UIController.Instance.ShowGameOverScreen();
            Time.timeScale = 0;
        }
        else
        {
            OnUpdateLifeUI?.Invoke(_life);
        }
    }
}
