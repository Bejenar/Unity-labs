using Game_2.Scripts;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayTime = 2f;
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Win");
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            StartCoroutine(LevelManager.ReloadSceneAfterDelay(1, delayTime));
        }
    }
}