using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
    public void Parar(bool parou)
    {
    if (parou == true)
    {
        speed = 0;
    }
    else
    {
        speed = 5;
    }
    }
}
