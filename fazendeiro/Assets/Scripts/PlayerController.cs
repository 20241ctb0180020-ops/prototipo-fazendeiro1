using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    private Collider colisao;
    int vida = 3;
    public Desaparecer farmer;
    public Placar placar;
    public GameObject animal;

    void Start()
    {
        colisao = GetComponent<Collider>();
        animal = GameObject.FindWithTag("Animais");
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
            StartCoroutine(Ghost());
        }
        if (pauseAction.WasPressedThisFrame())
        {
            InputActions.FindActionMap("Player").Disable();
            MenuPausa.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Animais"))
        {
            vida -= 1;
            placar.Vida(vida);
            if (vida < 1)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver");
            }
            Debug.Log("Vida: " + vida);
        }
    }

    private IEnumerator Ghost()
    {
        farmer.Fantasma(true);
        colisao.enabled = false;
        yield return new WaitForSeconds(2f);
        colisao.enabled = true;
        farmer.Fantasma(false);
    }
    public void Voltar()
    {
        MenuPausa.SetActive(false);
        InputActions.FindActionMap("Player").Enable();
    }
    public void Sair()
    {
        Application.Quit();
    }
}
