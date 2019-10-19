using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    [SerializeField]
    private Text gameTime;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Text winner;

    private void Start()
    {
        GameController.Instance.e_EndGame += UpdateScores;
    }

    private void Update()
    {
        gameTime.text = "Tiempo de juego: "+(GameController.Instance.GameTime);
    }

    void UpdateScores()
    {
        panel.SetActive(true);
        winner.text = GameController.Instance.GetWinner();
    }
}
