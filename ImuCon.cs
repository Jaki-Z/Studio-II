using Assets;
using Assets.Device.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImuCon : MonoBehaviour
{
    public float throwThreshold = 0.8f;
    public Flying flyingController;
    DeviceService deviceService;
    UdpServer udpServer;
    DeviceModel myImu;

    float accZ;
    bool hasThrown = false;


    void Start()
    {
        udpServer = WitApplication.Context.GetBean<UdpServer>();
        deviceService = WitApplication.Context.GetBean<DeviceService>();
        deviceService.putDeviceEvent.AddListener(OnFindDevice);
        StartUDP();
    }

    void Update()
    {
        if (myImu != null)
        {
            accZ = -(float)myImu.AccX;
        }

        if (!hasThrown)
        {
            if (accZ > throwThreshold)
            {
                hasThrown = true;
                flyingController.StartFlying();
                Debug.Log("飞起来了！");
            }
        }
    }

    public void StartUDP()
    {
        udpServer.StartReceive();
        udpServer.SendLoc();
    }

    private void OnFindDevice(DeviceModel deviceModel)
    {
        myImu = deviceModel;
    }

}
