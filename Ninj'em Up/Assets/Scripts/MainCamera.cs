using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public static string estadoCamera;

    public Transform playerAtual;
    //public GameObject limitEsq;
    public GameObject camLimitDir;
    public GameObject limitDir;
    public GameObject camMeio;
    public Transform mainCamera;

    public float camVelocity = 1;

    private void Awake()
    {
        estadoCamera = "followP1";
    }

    // Use this for initialization
    void Start () {
        camMeio.SetActive(false);
    }

    private void FixedUpdate()
    {
        CameraLimits();
        CameraFollow();
    }

    public void CameraFollow()
    {
        if (estadoCamera == "none")
        {
            mainCamera.position = Vector3.Lerp(mainCamera.position, new Vector3(mainCamera.transform.position.x,
                mainCamera.position.y, mainCamera.position.z), camVelocity);
        }

        else if (estadoCamera == "followP1")
        {
            mainCamera.position = Vector3.Lerp(mainCamera.position, new Vector3(playerAtual.transform.position.x + 5.5f,
                 mainCamera.position.y, mainCamera.position.z), camVelocity);
        }

        else if (estadoCamera == "followP2")
        {
            mainCamera.position = Vector3.Lerp(mainCamera.position, new Vector3(playerAtual.transform.position.x - 5.5f,
                mainCamera.position.y, mainCamera.position.z), camVelocity);
        }
    }

    public void CameraLimits()
    {
        if (camLimitDir.transform.position.x >= limitDir.transform.position.x)
        {
            camVelocity = 0f;
        }
    }
}
