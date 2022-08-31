using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrulhaBlue : MonoBehaviour
{
    public GameObject alvo;
    public float velocidadeIA;
    public GameObject wayPointAtual;


    public GameObject objetivo;
    private float distanciaWayPoint;
    private float distanciaAlvo;

    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanciaAtual = transform.position - wayPointAtual.transform.position;
        
        distanciaWayPoint = distanciaAtual.magnitude;

        distanciaAlvo = Vector3.Distance(transform.position, alvo.transform.position);


        if (distanciaWayPoint < distanciaAlvo)
        {
            objetivo = wayPointAtual;
        }
        else
        {
            objetivo = alvo;
        }

        if (distanciaWayPoint < 0.3f)
        {
            WayPoints scriptsWayPoints = wayPointAtual.GetComponent<WayPoints>();

            float distanciaTemporaria = Mathf.Infinity;
            for(int i = 0; i < scriptsWayPoints.vizinhos.Length; i++)
            {
                float distancia = Vector3.Distance(alvo.transform.position, 
                    scriptsWayPoints.vizinhos[i].transform.position);
                if(distancia < distanciaTemporaria)
                {
                    distanciaTemporaria = distancia; 
                    wayPointAtual = scriptsWayPoints.vizinhos[i];

                }
            }
        }

        transform.Translate(Vector3.forward * velocidadeIA * Time.deltaTime);

        transform.LookAt(objetivo.transform.position);


    }

}
