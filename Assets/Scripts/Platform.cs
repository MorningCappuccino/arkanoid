using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float minX = -5f; // Левая граница
    public float maxX = 5f;  // Правая граница

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // transform.position = new Vector3(mousePosition.x, transform.position.y, 0);

        // Ограничиваем позицию объекта по оси X в пределах minX и maxX
        float clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);

        // Обновляем позицию объекта
        rb.MovePosition(new Vector2(clampedX, rb.position.y));
    }
}
