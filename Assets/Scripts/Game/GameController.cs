using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool inGame;

    public delegate void EndGame();
    public event EndGame e_EndGame;

    [SerializeField]
    private float playTime = 60F, gameTime;

    [SerializeField]
    private int playerCount = 4;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private bool instantiateHumanPlayer = true;

    private Dictionary<string, int> taggedScore = new Dictionary<string, int>();

    public string GetWinner()
    {
        return string.Empty;
    }

    // Start is called before the first frame update
    private void Start()
    {
        onTaggedChange += UpdateTaggedScore;

        taggedScore.Clear();

        for (int i = 0; i < playerCount; i++)
        {
            string prefabPath = i == 0 && instantiateHumanPlayer ? "HumanPlayer" : "AIPlayer";

            GameObject playerInstance = Instantiate(Resources.Load<GameObject>(prefabPath), Vector3.zero, Quaternion.identity);

            playerInstance.name = string.Format("Player{0}", i + 1);
            playerInstance.GetComponent<PlayerController>().PlayerName = playerInstance.name;


            taggedScore.Add(playerInstance.name, 0);
        }
        
    }

    private void Update()
    {
        gameTime -= Time.deltaTime;
        if (gameTime <= 0) {
            gameTime = 0;
            e_EndGame();
        }
    }

    private void Pause()
    {
        Time.
    }

    private void UpdateTaggedScore(string taggedPlayer, int score)
    {
        taggedScore[taggedPlayer] += 1;
    }
}