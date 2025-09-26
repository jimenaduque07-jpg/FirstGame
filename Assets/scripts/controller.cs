using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class scripts : MonoBehaviour

{
    public float speed = 5f;
    public int score = 0;
    public bool touchbird = false;
    public bool touchenemy = false;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textEnemies;
    public int enemy = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTextScore();
        UpdateTextEnemies();
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
            score = score + 1;
            UpdateTextScore();

            Destroy(other.gameObject);
            Debug.Log("collected!!!");
            Debug.Log("score: " + score);

        }

        if (other.CompareTag("bird"))
        {
       
            touchbird = true;
            Debug.Log("has tocado el pajaro, perdiste");
            Destroy(gameObject);
        }

        if (other.CompareTag("enemy"))
        {
           enemy = enemy + 1;
            UpdateTextEnemies();

            touchenemy = true;
            Debug.Log("has matado al enemigo");
            Destroy(other.gameObject);
        }


        //condicion de victoria
        if (score >= 11 && enemy>= 6 && !touchbird) // es un booleana asumimos que haskey es true y poner ! antes de una variable es false
        {
            Debug.Log("ganaste");
        }

       

    }

    void UpdateTextScore()
    {
        textScore.text = "Score: " + score;
    }

    void UpdateTextEnemies()
    {
        textEnemies.text = "Enemies " + enemy;
    }
}