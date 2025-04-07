using UnityEngine;

public class PaperPlaneAni1 : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // 挂 SpriteRenderer
    public Sprite frame1;
    public Sprite frame2;

    public float switchTime = 0.3f;

    private float timer;
    private bool showingFirstFrame = true;
    private bool canAnimate = false; // 用于控制动画是否开始

    // 引用 CameraController 脚本
    public CameraController cameraController;

    void Update()
    {
        // 检查相机是否已放大完成
        if (!canAnimate && cameraController.isZoomed)
        {
            canAnimate = true; // 相机放大完成后，允许动画开始
            Debug.Log("动画开始"); // 添加日志来确认动画开始
        }

        // 如果动画可以开始
        if (canAnimate)
        {
            timer += Time.deltaTime;
            // Debug.Log("Timer: " + timer); // 输出timer的值来确认timer是否增加

            if (timer >= switchTime)
            {
                timer = 0f; // 重置timer
                showingFirstFrame = !showingFirstFrame;
                spriteRenderer.sprite = showingFirstFrame ? frame1 : frame2;

                // Debug.Log("切换到 " + (showingFirstFrame ? "frame1" : "frame2")); // 输出当前显示的帧
            }
        }
    }
}