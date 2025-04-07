using UnityEngine;

public class Flying : MonoBehaviour
{
    public Transform paperPlane; // 拖入纸飞机 Sprite 对象
    public Vector3 startPosition = new Vector3(-778f, -385f, 5f);  // 起点
    public Vector3 targetPosition = new Vector3(754f, -304f, 5f);  // 终点
    public Vector3 controlPoint = new Vector3(0f, 100f, 5f);       // 弧线中间控制点

    public float flyDuration = 3f;     // 飞行持续时间
    private float startTime;
    private bool isFlying = false;

    void Start()
    {
        // 设置初始位置
        if (paperPlane != null)
        {
            paperPlane.position = startPosition;
        }
        else
        {
            Debug.LogError("纸飞机没拖进去！");
        }
    }

    void Update()
    {
        if (isFlying)
        {
            float t = (Time.time - startTime) / flyDuration;
            if (t <= 1f)
            {
                Vector3 position = CalculateBezierPoint(t, startPosition, controlPoint, targetPosition);
                paperPlane.position = position;
            }
            else
            {
                isFlying = false;
            }
        }
    }

    public void StartFlying()
    {
        isFlying = true;
        startTime = Time.time;
    }

    // 二次贝塞尔曲线函数
    Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0;             // (1 - t)^2 * P0
        p += 2 * u * t * p1;             // 2(1 - t)t * P1
        p += tt * p2;                    // t^2 * P2

        return p;
    }
}