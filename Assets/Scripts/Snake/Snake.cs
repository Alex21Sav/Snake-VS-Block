using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TailGenerator))]
[RequireComponent(typeof(SnakeInput))]
public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _snakeHead;
    [SerializeField] private int _tailSize;
    [SerializeField] private float _speed;
    [SerializeField] private float _tailSprings;

    private SnakeInput _snakeInput;
    private List<Segment> _tail;
    private TailGenerator _tailGenerator;

    public event UnityAction<int> SnakeSize;

    private void Awake()
    {
        _tailGenerator = GetComponent<TailGenerator>();
        _snakeInput = GetComponent<SnakeInput>();
        _tail = _tailGenerator.Generator(_tailSize);
        SnakeSize?.Invoke(_tail.Count);
    }

    private void OnEnable()
    {
        _snakeHead.Blockcollided += OnBlockCollided;
        _snakeHead.BonusCollected += OnBonusCollected;
    }

    private void OnDisable()
    {
        _snakeHead.Blockcollided -= OnBlockCollided;
        _snakeHead.BonusCollected -= OnBonusCollected;
    }
    private void FixedUpdate()
    {
        Move(_snakeHead.transform.position + _snakeHead.transform.up * _speed * Time.fixedDeltaTime);
        _snakeHead.transform.up = _snakeInput.GetDirectToClick(_snakeHead.transform.position);
    }
    private void Move(Vector3 nextPosition)
    {
        Vector3 previousPosition = _snakeHead.transform.position;
        foreach (var segment in _tail)
        {
            Vector3 tempPosition = segment.transform.position;
            segment.transform.position = Vector2.Lerp(segment.transform.position, previousPosition, _tailSprings * Time.deltaTime);
            previousPosition = tempPosition;
        }

        _snakeHead.Move(nextPosition);
    }

    private void OnBlockCollided()
    {
        Segment DeletedSegment = _tail[_tail.Count - 1];
        _tail.Remove(DeletedSegment);
        Destroy(DeletedSegment.gameObject);

        SnakeSize?.Invoke(_tail.Count);
    }

    private void OnBonusCollected(int BonusSize)
    {
        _tail.AddRange(_tailGenerator.Generator(BonusSize));
        SnakeSize?.Invoke(_tail.Count);
    }
}
