using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Faz com que esse código requira um componente do tipo Camera para rodar
[RequireComponent(typeof(Camera))]

public class MainCamera : MonoBehaviour {
    
    //lista de alvos que a camera vai seguir
    public List<Transform> alvos;

    public Vector3 offset;
    public float smoothTime = .5f;
    public float minZoom = 9f;
    public float maxZoom = 4f;
    public float limitZoom = 10f;

    private Vector3 velocidade;
    private Camera mainCam;

    private void Start()
    {
        mainCam = GetComponent<Camera>();
    }

    //Utilizei o LateUpdate para que a camera só se mova depois que tudo for feito
    private void LateUpdate()
    {
        //Caso o numero de alvos seja 0 não retorna nada
        if (alvos.Count == 0)
            return;

        MovimentoCam();
        ZoomCamera();
    }

    void MovimentoCam()
    {
        Vector3 pontoCentral = PegaPontoCentral();

        Vector3 novaPosicao = pontoCentral + offset;

        //Movimenta a camera e faz com que sua movimentacao seja mais suave com o SmoothDamp
        transform.position = Vector3.SmoothDamp(transform.position, novaPosicao, ref velocidade, smoothTime);
    }

    //Da zoom in e out e tambem faz com que isso seja mais suave com o Lerp
    void ZoomCamera()
    {
        float novoZoom = Mathf.Lerp(maxZoom, minZoom, PegaMaiorDistancia() / limitZoom);
        mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, novoZoom, Time.deltaTime);
    }

    //faz o calculo para saber a maior distancia entre o alvos, assim sabemos ate onde a camera pode ir
    public float PegaMaiorDistancia()
    {
        var bounds = new Bounds(alvos[0].position, Vector3.zero);

        for (int i = 0; i < alvos.Count; i++)
        {
            bounds.Encapsulate(alvos[i].position);
        }

        return bounds.size.x;
    }

    //pega o alvo central para ignora e retorna que ele é o centro do bound
    Vector3 PegaPontoCentral()
    {
        if (alvos.Count == 1)
        {
            return alvos[0].position;
        }

        // pega a posicao central do primeiro alvo na lista
        var bounds = new Bounds(alvos[0].position, Vector3.zero);

        //Faz com que os alvos entrem nas bounds de acordo com quantos existem na lista
        for (int i = 0; i < alvos.Count; i++)
        {
            bounds.Encapsulate(alvos[i].position);
        }

        //retorna os calculos para o centro
        return bounds.center;
    }
}
