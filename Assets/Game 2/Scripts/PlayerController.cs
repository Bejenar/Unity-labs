using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount;
    [SerializeField] float normalSpeed;
    [SerializeField] float boostSpeed;

    private Rigidbody2D rb2d;
    private SurfaceEffector2D effector;

    private bool gameOver;

    private int input;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        effector = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (gameOver) return;

        input = Math.Sign(Input.GetAxis("Horizontal"));
        CheckBoost();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    public void DisableControls()
    {
        gameOver = true;
    }

    void CheckBoost()
    {
        effector.speed = Input.GetButton("Boost") ? boostSpeed : normalSpeed;
    }

    void Rotate()
    {
        if (input != 0)
        {
            rb2d.AddTorque(-input * torqueAmount);
        }
    }
}