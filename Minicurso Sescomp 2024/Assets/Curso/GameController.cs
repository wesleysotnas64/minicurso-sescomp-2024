using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    
    public int player1Score;
    public int player2Score;

    public Text txtPlayer1Score;
    public Text txtPlayer2Score;

    void Start()
    {
        player1Score = 0;
        player2Score = 0;

        txtPlayer1Score.text = player1Score.ToString();
        txtPlayer2Score.text = player2Score.ToString();
    }

    public void PointPlayer1()
    {
        player1Score++;

        txtPlayer1Score.text = player1Score.ToString();
    }

    public void PointPlayer2()
    {
        player2Score++;

        txtPlayer2Score.text = player2Score.ToString();
    }

    public void ReloadGame()
    {
        // Obtém a cena atual
        Scene currentScene = SceneManager.GetActiveScene();
        
        // Recarrega a cena atual usando o nome ou o índice dela
        SceneManager.LoadScene(currentScene.name);
    }

}
