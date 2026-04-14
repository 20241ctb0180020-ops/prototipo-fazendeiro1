using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string nomeFase;
    [SerializeField] private GameObject MenuInicial;
    // [SerializeField] private GameObject MenuOpcoes;
    public void Jogar()
    {
        SceneManager.LoadScene(nomeFase);
    }
    // public void AbrirOpcoes()
    // {
    //     MenuInicial.SetActive(false);
    //     MenuOpcoes.SetActive(true);
    // }
    // public void FecharOpcoes()
    // {
    //     MenuOpcoes.SetActive(false);
    //     MenuInicial.SetActive(true);
    // }
    public void SairJogo()
    {
        Debug.Log("Saiu");
        Application.Quit();
    }
}
