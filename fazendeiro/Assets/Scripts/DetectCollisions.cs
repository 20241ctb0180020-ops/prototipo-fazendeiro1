using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollisions : MonoBehaviour
{
    int pontuacao;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animais"))
        {
            pontuacao += 1;
            Debug.Log("pontuacao: " + pontuacao);
            // player.Recebe(pontuacao);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
