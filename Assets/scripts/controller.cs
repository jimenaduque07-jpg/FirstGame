using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTextNube();
        UpdateTextEnemies();
        UpdateTextGolden();
        UpdateTextNotifications();
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
            UpdateTextNotifications();
            Debug.Log("collected!!!");
            Debug.Log("nube: " + nube);

        }
        
        if (other.CompareTag("bird"))
        {
       
            touchbird = true;
            UpdateTextNotifications();
            Debug.Log("has tocado el pajaro, perdiste");
            Destroy(gameObject);
        }

        if (other.CompareTag("enemy"))
        {
           enemy = enemy + 1;
            UpdateTextEnemies();

            touchenemy = true;
            UpdateTextNotifications();
            Debug.Log("has matado al enemigo");
            Destroy(other.gameObject);
        }
        if (other.CompareTag("golden"))
        {
            golden = golden + 1;
            UpdateTextGolden();
            touchgolden = true;
            Destroy(other.gameObject);
            UpdateTextNotifications();
            Debug.Log("has recolectado el pajaro dorado, bien hecho");
           

        }
       


        //condicion de victoria
        if (nube >= 17 && enemy>= 6 && !touchbird && touchgolden) // es un booleana asumimos que haskey es true y poner ! antes de una variable es false
        {
            UpdateTextNotifications();
            Debug.Log("ganaste");
        }

       

    }

    void UpdateTextNube()
    {
        textNube.text = "Nubes: " + nube + "/17";
    }

    void UpdateTextEnemies()
    {
        textEnemies.text = "Enemies " + enemy + "/4";
    }

    void UpdateTextGolden()
    {
        textGolden.text = "Pajaro dorado: " + golden + "/1";
    }

    void UpdateTextNotifications()
    {
        textNotifications.text = "Notificaciones: ";
    }

}