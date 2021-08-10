using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int _destroyPriceRange;
    [SerializeField] private Color[] _colors;

    private SpriteRenderer _spriteRenderer;
    private int _destroyPrice;
    private int _filling;

    public int LeftToFoll => _destroyPrice - _filling;

    public event UnityAction<int> FillingUpdatend;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        SetColor(_colors[Random.Range(0, _colors.Length)]);       
        _destroyPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);
        FillingUpdatend?.Invoke(LeftToFoll);
    }

    public void Fill()
    {
        _filling++;
        FillingUpdatend?.Invoke(LeftToFoll);

        if (_filling == _destroyPrice)
        {
            Destroy(gameObject);
        }
    }
    private void SetColor(Color color)
    {
        _spriteRenderer.color = color;
    }
}
