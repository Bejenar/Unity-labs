using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = offset + target.position;
    }
}