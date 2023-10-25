using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float ShakeIntensity = 1f;
    private float ShakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmp;

    void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start() {
        StopShake();
    }

    public void ShakeCamera(){
        CinemachineBasicMultiChannelPerlin _cbmp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmp.m_AmplitudeGain = ShakeIntensity;

        timer = ShakeTime;
    }

        public void StopShake(){
        CinemachineBasicMultiChannelPerlin _cbmp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmp.m_AmplitudeGain = 0f;

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            ShakeCamera();
        }

        if(timer > 0){

            timer -= Time.deltaTime;

            if(timer <= 0){
                StopShake();
            }
        }
        
    }
}
