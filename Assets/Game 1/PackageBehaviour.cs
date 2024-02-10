using Game_1;
using Unity.VisualScripting;
using UnityEngine;

public class PackageBehaviour : MonoBehaviour
{
    [SerializeField] private PackageSO package;

    private PackageController _packageController;

    private void Awake()
    {
        _packageController = FindObjectOfType<PackageController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Package was taken");
            _packageController.StorePackage(package);
            ChangeCarColor();
            Destroy(gameObject);
        }
    }
    
    private void ChangeCarColor()
    {
        EventBus.Trigger("change-car-color", new PackagePickedUpEvent());
    }
}