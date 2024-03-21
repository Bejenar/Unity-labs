using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Entities.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5;
        [SerializeField] private float padding = 1f;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float projectileSpeed = 5f;
        [SerializeField] private float firingRate = 2f;
        [SerializeField] private AudioClip fireClip;
        private Vector2 moveInput = Vector2.zero;

        private float xmin;
        private float xmax;

        public int health = 100;

        void Start()
        {
            float distance = transform.position.z - Camera.main.transform.position.z;
            Vector3 leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
            Vector3 rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

            xmin = leftBorder.x + padding;
            xmax = rightBorder.x - padding;
        }

        void FixedUpdate()
        {
            // Debug.Log($"move input in FU {moveInput}");

            var movement = new Vector2(moveInput.x, 0) * (moveSpeed * Time.deltaTime);

            transform.Translate(movement);

            transform.position = PositionUtils.ClampXPosition(transform.position, xmin, xmax);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            moveInput = context.ReadValue<Vector2>();
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            if (context.action.WasPerformedThisFrame())
            {
                InvokeRepeating("Fire", 0.00001f, firingRate);
            }
            else if (context.action.WasReleasedThisFrame())
            {
                CancelInvoke("Fire");
            }
        }

        private void Fire()
        {
            var pos = transform.position;
            var projectile = Instantiate(projectilePrefab, pos, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = Vector2.up * projectileSpeed;
            AudioSource.PlayClipAtPoint(fireClip, transform.position);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            health -= other.gameObject.GetComponent<Laser>()?.damage ?? 0;
            Destroy(other.gameObject);

            if (health <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(0);
            }
        }
    }
}