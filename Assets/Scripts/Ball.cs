using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _force = 10f;
    [SerializeField] private AudioClip _ballSound;

    public static event Action OnLost;

    private bool isFired = false;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isFired)
        {
            transform.position = _platform.gameObject.transform.position + _offset;

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                isFired = true;
                _rb.velocity = Vector2.zero;
                _rb.AddForce(Vector2.up * _force, ForceMode2D.Force);
            }
        }
    }

    public void Reset()
    {
        isFired = false;
    }

    public void Lost()
    {
        OnLost?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            float collisionX = collision.GetContact(0).point.x;
            // Debug.Log("collisionX: " + collisionX);
            float platformCenterX = platform.gameObject.transform.position.x;
            float diff = platformCenterX - collisionX;
            // Debug.Log("diff: " + diff);
            float direction = collisionX > platformCenterX ? 1 : -1;
            _rb.velocity = Vector2.zero;
            _rb.AddForce(new Vector2(direction * Mathf.Abs(diff * _force), _force));

            GameManager.Instance.Audio.PlayOneShot(_ballSound);
        }
    }
}
