using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int sceneID;
    [SerializeField] private string LoadingSceneName = "Load";
    public  readonly UnityEvent<float> Progress;

    void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }

    public void Exit() => Application.Quit();

    public void Reload() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    public void StartLoad()
    {
        SceneManager.LoadScene(LoadingSceneName);
        StartCoroutine(LoadSceneAsync());
        Destroy(gameObject);
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneID);
        while (!asyncLoad.isDone)
        {
            Progress?.Invoke(asyncLoad.progress / 0.9f);
            yield return null;
        }
    }
}