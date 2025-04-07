using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextDelay : MonoBehaviour
{
    public TextMeshProUGUI textObject;  // 绑定TextMeshProUGUI组件
    public string sceneName = "Memory1"; // 目标场景名称
    private bool isSceneLoaded = false;

    void Start()
    {
        textObject.enabled = false;
        // 在场景加载后开始监听
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 确保是Memory1场景加载完成后
        if (scene.name == sceneName)
        {
            isSceneLoaded = true;
            StartCoroutine(ShowTextAfterDelay(10f));  // 延迟10秒后显示字体
        }
    }

    IEnumerator ShowTextAfterDelay(float delay)
    {
        // 等待指定的时间（10秒）
        yield return new WaitForSeconds(delay);

        // 显示字体
        textObject.enabled = true;
    }

    void OnDestroy()
    {
        // 移除监听器，防止内存泄漏
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}