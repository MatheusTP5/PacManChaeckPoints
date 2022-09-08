using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetio : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.forward * 1.0f * Time.deltaTime);
        Destroy(gameObject, 2.0f);
    }
}
