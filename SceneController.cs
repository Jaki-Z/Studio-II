using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [Tooltip("点击按钮后要切换到的下一个场景名")]
    public string nextSceneName;

    // ✅ 按钮点击时调用这个方法
    public void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("未指定下一个场景名！");
        }
    }
}