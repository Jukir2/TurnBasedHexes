using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InputBehaviour : MonoBehaviour
{
    [SerializeField] Tilemap _tilemap;
    [SerializeField] UnitBehaviour _selectedUnit;

    MouseInput _mouseInput;
    Camera _mainCamera;

    private void Awake()
    {
        _mouseInput = new();
    }

    private void OnEnable()
    {
        _mouseInput.Enable();
        _mainCamera = Camera.main;
        _mouseInput.Mouse.MouseClick.performed += _ => OnMouseClick();
    }

    private void OnDisable()
    {
        _mouseInput.Disable();
        _mouseInput.Mouse.MouseClick.performed -= _ => OnMouseClick();
    }

    private void OnMouseClick()
    {
        Vector2 mousePosition = _mouseInput.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = _mainCamera.ScreenToWorldPoint(mousePosition);
        Vector3Int gridPosition = _tilemap.WorldToCell(mousePosition);
        if(_tilemap.HasTile(gridPosition))
        {
            CustomTile tile = (CustomTile) _tilemap.GetTile(gridPosition);
            Debug.Log($"{gridPosition} {tile}");
            if (_selectedUnit != null)
            {
                _selectedUnit.MoveTo(mousePosition);
            }
        }
    }
}
