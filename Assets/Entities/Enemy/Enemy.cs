using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int health = 100;
    [SerializeField] private float projectileSpeed = 5f;
    public GameObject projectilePrefab;

    public float shotsPerSecond = 0.5f;

    [SerializeField] private AudioClip fireSound;
    [SerializeField] private AudioClip deathSound;
    
    private ScoreKeeper _scoreKeeper;

    private void Start()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        // InvokeRepeating("Fire", 0.00001f, 1);
    }

    private void Update()
    {
        float p = shotsPerSecond * Time.deltaTime;

        if (Random.value < p)
        {
            Fire();
        }
    }

    private void Fire()
    {
        var startPos = transform.position;
        var projectile = Instantiate(projectilePrefab, startPos, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = Vector2.down * projectileSpeed;
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        health -= other.gameObject.GetComponent<Laser>()?.damage ?? 0;
        Destroy(other.gameObject);

        if (health <= 0)
        {
            _scoreKeeper.Score(100);
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
            Destroy(gameObject);
        }
    }
}