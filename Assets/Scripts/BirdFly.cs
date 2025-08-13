using UnityEngine;

public class BirdFly : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    
    private bool _hasGameStarted;
    private float _defaultGravityScale;
    
    [SerializeField] private float flapStrength = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _defaultGravityScale =  _rigidBody.gravityScale;
        _rigidBody.gravityScale = 0f;
    }
    
    private void Update()
    {
        if (_hasGameStarted)
        {
            RotateBird();
        }
    }

    private void RotateBird()
    {
        var verticalVelocity = _rigidBody.linearVelocity.y;
        var targetRotationZ = Mathf.Lerp(-90f, 45f, Mathf.InverseLerp(-10f, 10f, verticalVelocity));
        
        var targetRotation = Quaternion.Euler(0, 0, targetRotationZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void StartFly()
    {
        if (_hasGameStarted) return;
        
        _hasGameStarted = true;
        _rigidBody.gravityScale = _defaultGravityScale;
    }
    
    public void Flap()
    {
        _rigidBody.linearVelocity = new Vector2(_rigidBody.linearVelocity.x, 0);
        _rigidBody.AddForce(Vector2.up * flapStrength, ForceMode2D.Impulse);
    }
}
