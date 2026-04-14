using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30f;
    private float lowerBound = -10f;
    // private GameObject placar;

    // Start is called before the first frame update
    void Start()
    {
        // placar = FindObjectOfType<Placar>();
    }

    // Update is called once per frame
    void Update()
    {
        var placar = FindObjectOfType<Placar>();
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.z < lowerBound)
        {
            placar.Pontuacao(-1);
            Destroy(gameObject);
            Exit();
        }
    }

    public void Exit()
    {
        // Debug.Log("Game Over!");
        /*
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif*/
    }
}
