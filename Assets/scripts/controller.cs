using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.SceneManagement;


public class scripts : MonoBehaviour

{

    public float speed = 5f;
    public int nube = 0;
    public bool touchbird = false;
    public bool touchenemy = false;
    public bool touchgolden = false;
    public TextMeshProUGUI textNube;
    public TextMeshProUGUI textEnemies;
    public TextMeshProUGUI textGolden;
    public TextMeshProUGUI textNotifications;
    public int enemy = 0;
    public int golden = 0;

    public GameObject GameOverPanel;
    public GameObject VictoryPanel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
        UpdateTextNube();
        UpdateTextEnemies();
        UpdateTextGolden();
        UpdateTextNotifications("Recolecta lo que te hace falta");
    }

    // Update is called once per frame
    void Update()
    {

        // vamos a leer las teclas wasd o las flechas del teclado
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //creamos un vector para almacenar la direccion del movimiento
        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);

        transform.Translate(direction * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("collectable"))
        {
            nube = nube + 1;
            UpdateTextNube();

            Destroy(other.gameObject);
            UpdateTextNotifications("¡Recolectaste una nube!");
            Debug.Log("collected!!!");
            Debug.Log("nube: " + nube);

        }
        
        if (other.CompareTag("bird"))
        {
       
            touchbird = true;
            UpdateTextNotifications("Has ocado el pájaro, perdiste :(");
            Debug.Log("has tocado el pajaro, perdiste");
            GameOverOn();
            Destroy(gameObject, 0.3f);


        }

        if (other.CompareTag("enemy"))
        {
           enemy = enemy + 1;
            UpdateTextEnemies();

            touchenemy = true;
            UpdateTextNotifications("¡Mataste un enemigo! Bien hecho");
            Debug.Log("has matado al enemigo");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("golden"))
        {
            golden = golden + 1;
            UpdateTextGolden();
            touchgolden = true;
            Destroy(other.gameObject);
            UpdateTextNotifications("¡Recolectaste el pájaro dorado!");
            Debug.Log("has recolectado el pajaro dorado, bien hecho");
           

        }
       


        //condicion de victoria
        if (nube >= 16 && enemy>= 6 && !touchbird && touchgolden) // es un booleana asumimos que haskey es true y poner ! antes de una variable es false
        {
            UpdateTextNotifications("¡¡Ganaste la partida!!");
            Debug.Log("ganaste");
            VictoryOn();
        }

       

    }

    void UpdateTextNube()
    {
        textNube.text = "Nubes: " + nube + "/16";
    }

    void UpdateTextEnemies()
    {
        textEnemies.text = "Enemies " + enemy + "/4";
    }

    void UpdateTextGolden()
    {
        textGolden.text = "Pajaro dorado: " + golden + "/1";
    }

    void UpdateTextNotifications(string message)
    {
        textNotifications.text =  message;
    }

    public void GameOverOn()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f; // pausa el juego
    }

    public void GameOverOff()
    {
        GameOverPanel.SetActive(false);
        Time.timeScale = 1f; // reanuda el juego
    }

    public void VictoryOn()
    {
        VictoryPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void VictoryOff()
    {
        VictoryPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}