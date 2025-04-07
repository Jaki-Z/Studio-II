using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 targetPos = new Vector3(313f, 176f, -10f); // 你想聚焦的位置
    public float targetSize = 170f;                              // 越小越放大
    public float duration = 2f;

    private Vector3 startPos;
    private float startSize;
    private float elapsed = 0f;
    private bool isZooming = false;

    // 新增：放大完成的标志
    public bool isZoomed = false;

    void Start()
    {
        startPos = Camera.main.transform.position;
        startSize = Camera.main.orthographicSize;
        isZooming = true;
    }

    void Update()
    {
        if (!isZooming) return;

        elapsed += Time.deltaTime;
        float t = Mathf.Clamp01(elapsed / duration);

        Camera.main.transform.position = Vector3.Lerp(startPos, targetPos, t);
        Camera.main.orthographicSize = Mathf.Lerp(startSize, 100, t);

        if (t >= 1f)
        {
            isZooming = false;
            isZoomed = true; // 相机完成放大，设置标志为 true
        }
    }
}