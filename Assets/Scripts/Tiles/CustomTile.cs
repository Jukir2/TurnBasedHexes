using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CustomTile : Tile
{
    [SerializeField] private bool _walkable;

    public override string ToString()
    {
        return $"{GetType().Name}, walkable: {_walkable}";
    }

#if UNITY_EDITOR
    [MenuItem("Assets/Create/2D/Custom Tiles/Custom Tile")]
    public static void CreateCustomTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Custom Tile", "New Custom Tile", "Asset", "Save Custom Tile", "Assets");
        if(string.IsNullOrEmpty(path))
        {
            return;
        }

        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<CustomTile>(), path);
    }
#endif
}
