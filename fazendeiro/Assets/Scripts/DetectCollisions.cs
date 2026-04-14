using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollisions : MonoBehaviour
{
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
            var placar = FindObjectOfType<Placar>();
            placar.Pontuacao(1);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
