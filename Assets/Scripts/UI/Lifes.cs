using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifes : MonoBehaviour
{
    [SerializeField] private List<GameObject> _lifes;

    private void OnEnable()
    {
        GameManager.OnUpdateLifeUI += UpdateLifeUI;
    }

    private void OnDisable()
    {
        GameManager.OnUpdateLifeUI -= UpdateLifeUI;
    }

    private void UpdateLifeUI(int life)
    {
        switch (life)
        {
            case 3:
                break;
            case 2:
                _lifes[2].SetActive(false);
                break;
            case 1:
                _lifes[1].SetActive(false);
                break;
        }
    }
}
