using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetectCollisions : MonoBehaviour
{
    // PlayerController player;
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
            // player.Recebe(1);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
