using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Brick : MonoBehaviour
{
    [SerializeField] private BrickData _brickData;
    [SerializeField] private bool _initFromData;
    [SerializeField] private AudioClip _destroy;

    public static event Action<int> OnDestroyed;

    private SpriteRenderer _sr;
    private int _score;
    private List<Sprite> _sprites;
    private int _health;
    private ParticleSystem _particle;

    private void Awake() {
        _sr = GetComponent<SpriteRenderer>();
        _particle = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        if (_initFromData)
        {
            Initialize(_brickData);
        }
    }

    public void Initialize(BrickData brickData)
    {
        _sprites = new List<Sprite>(brickData.Sprites);
        _score = brickData.Score;
        _health = _sprites.Count;
        _sr.sprite = _sprites[_health - 1];
        MainModule main = _particle.main;
        main.startColor = brickData.ParticleColor;
    }

    public void ApplyDamage()
    {
        _health--;
        if (_health < 1)
        {
            _sr.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            _particle.Play();
            OnDestroyed?.Invoke(_score);
        }
        else
        {
            _sr.sprite = _sprites[_health - 1];
        }

        GameManager.Instance.Audio.PlayOneShot(_destroy);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("ball"))
        {
            ApplyDamage();
        }
    }
}
