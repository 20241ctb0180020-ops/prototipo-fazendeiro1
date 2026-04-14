using UnityEngine;
using TMPro;

public class Placar : MonoBehaviour
{
    public TextMeshProUGUI PontuacaoText;
    public TextMeshProUGUI VidaText;
    int pontuacao = 0;
    int vidaplacar = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PontuacaoText.text = "Pontuacao: " + pontuacao.ToString();
        VidaText.text = "Vida: " + vidaplacar.ToString();
    }
    public void Pontuacao(int valor)
    {
        pontuacao = pontuacao + valor;
        if (pontuacao < 1)
        {
            pontuacao = 0;
        }
        Debug.Log("Pontuacao: " + pontuacao);
    }
    public void Vida(int player)
    {
        vidaplacar = player;
    }
}
