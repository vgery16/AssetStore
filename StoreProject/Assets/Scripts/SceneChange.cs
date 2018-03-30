using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public int SceneBuildIndex = 0;
    public LoadSceneMode mode;

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneBuildIndex, mode);
    }

    public void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(SceneBuildIndex);
    }

}
