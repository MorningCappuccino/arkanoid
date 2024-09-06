using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _force = 10f;

    private bool isFired = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFired)
        {
            transform.position = _platform.gameObject.transform.position + _offset;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isFired = true;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(1f, 1f) * _force, ForceMode2D.Force);
        }
    }

    public void Reset()
    {
        isFired = false;
    }
}
