using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    [SerializeField] private List<BrickData> _bricks;

    private void Start() {
        for (int i = 0; i < _bricks.Count; i++)
        {
            GameObject element = Instantiate(_bricks[i].Prefab, new Vector3(i, 0, 0), Quaternion.identity);
            if (element.TryGetComponent(out Brick brick))
            {
                brick.Initialize(_bricks[i]);
            }
        }
    }
}
