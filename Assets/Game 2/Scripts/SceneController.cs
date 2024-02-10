using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game_2.Scripts
{
    public class SceneController
    {
        public static IEnumerator ReloadSceneAfterDelay(int index, float delay)
        {
            float timeElapsed = 0;

            while (timeElapsed < delay)
            {
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            SceneManager.LoadScene(index);
        }
    }
}