using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
  public GameObject victoriaCanvas;
    public GameObject derrotaCanvas;

    void Update()
    {
       
        GameObject[] basesPlayer = GameObject.FindGameObjectsWithTag("BasePlayer");

        Debug.Log("Bases conquistadas por el jugador: " + basesPlayer.Length);

        
        if (basesPlayer.Length == 4)
        {
            victoriaCanvas.SetActive(true);
            Debug.Log("¡El jugador ha conquistado todas las bases y ha ganado!");
        }

       
        if (basesPlayer.Length == 0)
        {
            derrotaCanvas.SetActive(true);
            Debug.Log("¡El jugador ha perdido todas las bases y ha sido derrotado!");
        }

        
        
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
            salirjue();
            }
        
    }


    public void RepetirJuego()
    {
        SceneManager.LoadScene("juego");
    }

    public void RegresarAlMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void salirjue()
    {
        Application.Quit();
    }
}
