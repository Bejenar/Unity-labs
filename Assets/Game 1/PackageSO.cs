using UnityEngine;

namespace Game_1
{
    [CreateAssetMenu(fileName = "Package", menuName = "Add Package", order = 0)]
    public class PackageSO : ScriptableObject
    {
        [SerializeField] private string packageName;
        [SerializeField] private string clientId;

        public string Name
        {
            get => packageName;
            set => packageName = value;
        }

        public string ClientId
        {
            get => clientId;
            set => clientId = value;
        }
    }
}