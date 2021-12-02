using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
    
public class LevelController : MonoBehaviour
{
    [SerializeField] private Slider _loadingBar;

    public void LoadLevelAsync(int sceneIndex)
    {
        StartCoroutine(AsyncLoad(sceneIndex));
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    private IEnumerator AsyncLoad(int sceneIndex)
    {
        AsyncOperation asyncLoader = SceneManager.LoadSceneAsync(sceneIndex);

        while(asyncLoader.isDone == false)
        {
            if(_loadingBar != null)
                _loadingBar.value = asyncLoader.progress / .9f;

            yield return null;
        }
    }
}