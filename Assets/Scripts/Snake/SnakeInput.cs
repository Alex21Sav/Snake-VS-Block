using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }
    public Vector2 GetDirectToClick(Vector2 HeadPoisition)
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = _camera.ScreenToViewportPoint(mousePosition);
        mousePosition.y = 1;
        mousePosition = _camera.ViewportToWorldPoint(mousePosition);
        Vector2 direction= new Vector2(mousePosition.x - HeadPoisition.x, mousePosition.y - HeadPoisition.y);    

        return direction;
    }
}
