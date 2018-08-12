using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public static string estadoCamera;

    public GameObject playerAtual;
    //public GameObject limitEsq;
    public GameObject camLimitDir;
    public GameObject limitDir;
    public Transform mainCamera;

    private void Awake()
    {
        estadoCamera = "followP1";
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    

    void Update()
    {
        CameraLimits();
        CameraFollow();
    }

    public void CameraFollow()
    {
        if (estadoCamera == "none")
        {
            mainCamera.position = Vector3.Lerp(mainCamera.position, new Vector3(mainCamera.transform.position.x,
                mainCamera.position.y, mainCamera.position.z), 1f);
        }

        else if (estadoCamera == "followP1")
        {
            //faz a camera seguir o personagem da esquerda
            mainCamera.position = Vector3.Lerp(mainCamera.position, new Vector3(playerAtual.transform.position.x + 5.5f,
                mainCamera.position.y, mainCamera.position.z), 1f);
        }

        else if (estadoCamera == "followP2")
        {
            //faz a camera seguir o personagem da direita
            mainCamera.position = Vector3.Lerp(mainCamera.position, new Vector3(playerAtual.transform.position.x - 5.5f,
                mainCamera.position.y, mainCamera.position.z), 1f);
        }
    }

    public void CameraLimits()
    {
        if (camLimitDir.transform.position.x >= limitDir.transform.position.x)
        {
            estadoCamera = "none";
        }
    }
}
