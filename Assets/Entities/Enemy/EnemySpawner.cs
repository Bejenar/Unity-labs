using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    public float width = 10f;
    public float height = 5f;

    private Vector2 _movingDirection = Vector2.right;
    public float speed = 5f;

    private float xmin;
    private float xmax;

    // Start is called before the first frame update
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xmin = leftBorder.x + width * 0.5f;
        xmax = rightBorder.x - width * 0.5f;

        SpawnEnemies();
    }

    private void Update()
    {
        if (transform.position.x >= xmax)
        {
            _movingDirection = Vector2.left;
        }
        else if (transform.position.x <= xmin)
        {
            _movingDirection = Vector2.right;
        }

        if (AllMembersAreDead())
        {
            StartCoroutine(SpawnUntilFull());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(_movingDirection * (speed * Time.deltaTime));

        transform.position = PositionUtils.ClampXPosition(transform.position, xmin, xmax);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            SpawnEnemy(child);
        }
    }

    void SpawnEnemy(Transform parent)
    {
        var enemy = Instantiate(enemyPrefab, parent.transform.position, Quaternion.identity);
        enemy.transform.parent = parent;
    }

    IEnumerator SpawnUntilFull()
    {
        while (NextFreePosition())
        {
            Transform freePosition = NextFreePosition(); // is it efficient to call it again? is it safe to not call it again?
            if (freePosition)
            {
                SpawnEnemy(freePosition);
            }

            yield return new WaitForSeconds(1);
        }
    }

    private bool AllMembersAreDead()
    {
        return GetComponentsInChildren<Enemy>().Length == 0;
    }

    private Transform NextFreePosition()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount == 0)
            {
                return child;
            }
        }

        return null;
    }
}