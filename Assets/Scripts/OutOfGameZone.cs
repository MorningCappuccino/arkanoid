using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfGameZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent(out Ball ball))
        {
            ball.Reset();
            ball.Lost();
        }
    }
}
