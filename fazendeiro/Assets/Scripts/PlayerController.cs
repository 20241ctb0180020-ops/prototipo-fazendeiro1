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
    private InputAction pauseAction;
    private IEnumerator coroutine;
    [SerializeField] private GameObject MenuPausa;
    public TextMeshProUGUI VidaText;
    // public TextMeshProUGUI PontuacaoText;
    private Collider colisao;
    int pontuacao;
    int vida = 3;
    // MoveForward script;

    void Start()
    {
        // script = Object.FindAnyObjectByType<MoveForward>();

        colisao = GetComponent<Collider>();
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
        pauseAction = InputSystem.actions.FindAction("Pause");
    }

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
            coroutine = WaitAndPrint(2f);
            StartCoroutine(coroutine);
            print("ghost comecou");
            colisao.enabled = false;
        }
        if (pauseAction.WasPressedThisFrame())
        {
            InputActions.FindActionMap("Player").Disable();
            MenuPausa.SetActive(true);
            // script.Parar(true);
        }
        VidaText.text = "Vida: " + vida.ToString();
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
        colisao.enabled = true;
    }
    public void Recebe(int receber)
    {
        pontuacao = pontuacao + receber;
    }
    public void Voltar()
    {
        MenuPausa.SetActive(false);
        InputActions.FindActionMap("Player").Enable();
    }
}
