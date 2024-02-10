using Unity.VisualScripting;
using UnityEngine;

namespace Game_1
{
    public class ClientBehaviour : MonoBehaviour
    {
        [SerializeField] private string id;

        private PackageController _packageController;

        private void Awake()
        {
            _packageController = FindObjectOfType<PackageController>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                var package = _packageController.GetPackage(id);
                if (package == null)
                {
                    return;
                }

                Debug.Log("Got the package");
                ChangeCarColor();
            }
        }

        private void ChangeCarColor()
        {
            EventBus.Trigger("change-car-color", new PackagePickedUpEvent());
        }
    }
}