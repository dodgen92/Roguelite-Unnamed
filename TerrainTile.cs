using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] Vector2Int tilePosition;
    // Terrain tiles
    void Start()
    {
        GetComponentInParent<WorldScrolling>().Add(gameObject, tilePosition);

        transform.position = new Vector3(-100, -100, 0);
    }
}


