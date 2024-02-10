using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] ParticleSystem trailEffect;

    void OnCollisionEnter2D(Collision2D other)
    {
        trailEffect.Play();
    }

    void OnCollisionExit2D(Collision2D other)
    {
        trailEffect.Stop();
    }
}