using UnityEngine;
using TMPro;

public class Placar : MonoBehaviour
{
    public TextMeshProUGUI PontuacaoText;
    public TextMeshProUGUI VidaText;
    int pontuacaoplacar = 0;
    int vidaplacar = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PontuacaoText.text = "Pontuacao: " + pontuacaoplacar.ToString();
        VidaText.text = "Vida: " + vidaplacar.ToString();
    }
    public void Pontuacao()
    {
        pontuacaoplacar += 1;
        Debug.Log("Pontuacao: "+ pontuacaoplacar);
    }
    public void Vida(int player)
    {
        vidaplacar = player;
    }
}
