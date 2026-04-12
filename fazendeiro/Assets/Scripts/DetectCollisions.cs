using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollisions : MonoBehaviour
{
    public Placar placar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animais"))
        {
            placar.Pontuacao();
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
