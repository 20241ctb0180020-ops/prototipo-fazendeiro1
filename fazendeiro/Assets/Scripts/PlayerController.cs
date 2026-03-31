using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;
    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction ghostAction;
    private IEnumerator coroutine;
    public TextMeshProUGUI VidaText;
    public TextMeshProUGUI PontuacaoText;
    int pontuacao1;
    int vida = 3;
    // public Renderer aparecer;

    void Start()
    {
        // aparecer = GetComponent<Renderer>();
    }
    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }
    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Jump");
        ghostAction = InputSystem.actions.FindAction("Ghost");
    }

    // void Start()
    // {

    // }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        // movimenta o player para esquerda e direita a partir da entrada do usu�rio
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        // mant�m o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }
        // dispara comida ao pressionar barra de espa�o
        if (fireAction.WasPressedThisFrame())
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        if (ghostAction.WasPressedThisFrame())
        {
            coroutine = WaitAndPrint(2.0f);
            StartCoroutine(coroutine);
            print("ghost comecou");
            //    aparecer.enabled = false;
        }
        VidaText.text = "Vida: " + vida.ToString();
        // PontuacaoText.text = "Pontuação: " + pontuacao1.ToString();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Animais"))
        {
            vida -= 1;
            if (vida < 1)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver");
            }
            Debug.Log("Vida: " + vida);
        }
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        print("ghost terminou: " + Time.time + " segundos");
        //   aparecer.enabled = true;
    }
    public void Uma(int maisum)
    {
        Debug.Log(maisum);
    }
    public void Recebe(int valor)
    {
        pontuacao1 = valor;
    }
}
