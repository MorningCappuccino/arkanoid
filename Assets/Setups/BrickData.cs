using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BrickData", menuName = "Setups/Brick")]
public class BrickData : ScriptableObject
{
    public GameObject Prefab;
    public List<Sprite> Sprites;
    public int Score;
    public Color ParticleColor;
}
