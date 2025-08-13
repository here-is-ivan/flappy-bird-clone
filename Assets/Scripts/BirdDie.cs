using UnityEngine;
using UnityEngine.Events;

public class BirdDie : MonoBehaviour
{
    private bool _isDead;
    [SerializeField] private UnityEvent onDie;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Damage>() && !_isDead)
        {
            _isDead = true;
            onDie.Invoke();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Damage>() && !_isDead)
        {
            _isDead = true;
            onDie.Invoke();
        }
    }
}
