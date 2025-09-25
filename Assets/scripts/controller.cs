using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class scripts : MonoBehaviour

{
    public float speed = 5f;
    public int score = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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


            Destroy(other.gameObject);
            Debug.Log("collected!!!");
            Debug.Log("score: " + score);

        }


    }
}