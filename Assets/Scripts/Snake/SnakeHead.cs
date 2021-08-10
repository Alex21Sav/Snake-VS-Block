using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeHead : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public event UnityAction Blockcollided;
    public event UnityAction<int> BonusCollected;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 newPosition)
    {
        _rigidbody.MovePosition(newPosition);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Block block))
        {
            Blockcollided?.Invoke();
            block.Fill();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Bonus bonus))
        {
            BonusCollected?.Invoke(bonus.Collect());
        }
    }
}
