using UnityEngine;

public class Desaparecer : MonoBehaviour
{
    private SkinnedMeshRenderer aparecer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aparecer = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fantasma(bool invisivel)
    {
        if(invisivel == true)
        {
            aparecer.enabled = false;
        }
        else
        {
            aparecer.enabled = true;
        }
    }
}
