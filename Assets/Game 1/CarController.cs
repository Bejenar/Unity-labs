using System;
using Game_1;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class CarController : MonoBehaviour
{
    [SerializeField] private float steerSpeed;
    [SerializeField] private float moveSpeed;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;


    private Vector3 force = Vector3.zero;
    private float torque = 0f;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Action<PackagePickedUpEvent> handler = ChangeCarColor;
        EventBus.Register("change-car-color", handler);
        SceneManager.sceneUnloaded += _ => EventBus.Unregister("change-car-color", handler);
    }

    private void ChangeCarColor(PackagePickedUpEvent str)
    {
        _spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        force = new Vector2(0, vertical * moveSpeed);
        torque = horizontal * steerSpeed;

        // Debug.Log($"{force}, {torque}");
        // _rigidbody.AddForce(force);
        // _rigidbody.AddTorque(torque);
    }

    private void FixedUpdate()
    {
        transform.Translate(force * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, -torque * Time.deltaTime));
    }
}