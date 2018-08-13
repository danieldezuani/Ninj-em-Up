using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    public Camera mainCamera;
    public Transform player1;
    public Transform player2;
    //Transform player3;
    //Transform player4;

    private void Start()
    {
        Menu.numPlayersMode = "2Players";
    }

    private void Update()
    {
        if (Menu.numPlayersMode == "SinglePlayer")
        {

        }
        else if (Menu.numPlayersMode == "2Players")
        {
            CameraFollow2Players(mainCamera,player1,player2);
        }
        else if (Menu.numPlayersMode == "4Players")
        {

        }
    }

    public void CameraFollow2Players(Camera cam, Transform p1, Transform p2)
    {
        // How many units should we keep from the players
        float zoomFactor = 1.5f;
        float followTimeDelta = 0.8f;

        // Midpoint we're after
        Vector3 midpoint = (p1.position + p2.position) / 2f;

        // Distance between objects
        float distance = (p1.position - p2.position).magnitude;

        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        // Define o o tamanho da camera de acordo com a distancia
        if (cam.orthographic)
        {
            cam.orthographicSize = distance / 2f;
        }
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude >= 0.05f)
            cam.transform.position = cameraDestination;
    }
}
