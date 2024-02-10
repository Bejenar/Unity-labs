using System.Collections.Generic;
using Game_1;
using UnityEngine;

public class PackageController : MonoBehaviour
{
    private Dictionary<string, PackageSO> packages = new();


    public void StorePackage(PackageSO package)
    {
        packages.Add(package.ClientId, package);
    }

    public PackageSO GetPackage(string clientId)
    {
        packages.TryGetValue(clientId, out var value);
        if (value != null)
        {
            packages.Remove(clientId);
        }

        return value;
    }
}