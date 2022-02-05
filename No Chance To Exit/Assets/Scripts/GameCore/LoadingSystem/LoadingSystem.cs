using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCore
{

    public class LoadingSystem : MonoBehaviour
    {
        private int sceneToLoad;
        private int sceneToUnload;

        public void StartLoadingScene(int sceneIndex)
        {
            sceneToLoad = sceneIndex;
            if (sceneToLoad == 0)
            {
                GameObject.FindGameObjectWithTag("GameMusic")?.GetComponent<AudioSource>().Stop();
            }
            sceneToUnload = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine(LoadScene());
        }

        private IEnumerator LoadScene()
        {
            var loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
            yield return new WaitUntil(() => loadingOperation.isDone);
            StartUnloadingScene();
            sceneToLoad = -1;
        }

        public void StartUnloadingScene()
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneToLoad));
            StartCoroutine(UnloadScene());
        }

        private IEnumerator UnloadScene()
        {
            var unloadingOperation = SceneManager.UnloadSceneAsync(sceneToUnload);
            yield return new WaitUntil(() => unloadingOperation.isDone);
            sceneToUnload = -1;
        }


        public int SceneCounting()
        {
            int value = SceneManager.sceneCountInBuildSettings - 1;
            return value;
        }
    }  
}

