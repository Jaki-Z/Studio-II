using UnityEngine;
using System.IO.Ports;

public class Serial : MonoBehaviour
{
    private SerialPort serialPort;
    public string portName = "/dev/cu.usbmodem11101"; // Mac端串口名称
    public int baudRate = 9600;
    private bool alreadyLoaded = false; // 用于标记是否已经加载过场景

    public SceneController sceneController; // 拖拽引用

    void Start()
    {
        serialPort = new SerialPort(portName, baudRate);
        serialPort.Open();
    }

    void Update()
    {
        if (serialPort.IsOpen && serialPort.BytesToRead > 0)
        {
            string data = serialPort.ReadLine().Trim(); // 读取数据并去除换行符
            Debug.Log("Receive data: " + data);
            if (data == "UNFOLDED" && !alreadyLoaded)
            {
                alreadyLoaded = true;
                sceneController.LoadNextScene();
            }
        }
    }

    void OnApplicationQuit()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}