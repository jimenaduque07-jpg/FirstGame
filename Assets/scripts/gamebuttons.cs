using UnityEngine;
using UnityEngine.SceneManagement;

public class gamebuttons : MonoBehaviour 

{
    public GameObject PausePanel;
    public GameObject InstructionsPanel;
    public GameObject SettingsPanel;


    public void InstructionsOn()
    {
        InstructionsPanel.SetActive(true);
    }

    public void InstruccionsOff()
    {
        InstructionsPanel.SetActive(false);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SettingsOn()
    {
        SettingsPanel.SetActive(true);
    }

    public void SettingsOff()
    {
        SettingsPanel.SetActive(false);
    }


    private bool isPaused = false;
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }


        void PauseGame()
        {
            Time.timeScale = 0f; // Detiene el tiempo del juego
            PausePanel.SetActive(true);
            isPaused = true;
            Debug.Log("Juego en pausa");
        }

        void ResumeGame()
        {
            Time.timeScale = 1f;// Restaura el tiempo normal
            PausePanel.SetActive(false);
            isPaused = false;
            Debug.Log("Juego reanudado");
        }
    } 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
