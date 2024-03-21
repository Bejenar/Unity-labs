using UnityEngine;

public class SimpleSingleton : Singleton<SimpleSingleton>
{
    public void DoSomething()
    {
        Debug.Log("I'm the singleton! Hello!");
    }
}