using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputController : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tpos = tilemap.WorldToCell(worldPoint);
            TileBase tile = tilemap.GetTile(tpos);
            CustomTile customTile = (CustomTile) tile;
            if (customTile != null)
            {
                Debug.Log(customTile.ToString());
                tilemap.SetTileFlags(tpos, TileFlags.None);
                tilemap.SetColor(tpos, Color.cyan);
            }
        }
    }
}
