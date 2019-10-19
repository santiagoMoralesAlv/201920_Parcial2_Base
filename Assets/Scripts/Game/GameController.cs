using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEditor;
using System.Linq;


public class GameController : MonoBehaviour
{
    #region singleton
    private static GameController instance;

    public static GameController Instance
    {
        get
        {
            return instance;
        }
    }

    
    #endregion


    private bool inGame;

    public delegate void EndGame();
    public event EndGame e_EndGame;

    [SerializeField]
    private float playTime = 60F, gameTime;

    [SerializeField]
    private int playerCount = 10;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private bool instantiateHumanPlayer = true;

    public delegate void Tagged(PlayerController playerTagged);
    public event Tagged e_newPlayerTagger;
    
    private List<PlayerController> players;

    public List<PlayerController> Players
    {
        get
        {
            return players;
        }
        
    }

    public float GameTime
    {
        get
        {
            return gameTime;
        }
    }

    public float PlayTime
    {
        get
        {
            return playTime;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
            instance = this;
        }
        else
        {
            instance = this;

        }

        players = new List<PlayerController>();

        for (int i = 0; i < playerCount; i++)
        {
            string prefabPath = i == 0 && instantiateHumanPlayer ? "HumanPlayer" : "AIPlayer";

            GameObject playerInstance = Instantiate(Resources.Load<GameObject>(prefabPath), new Vector3(i * 2, 0, 0), Quaternion.identity);

            playerInstance.name = string.Format("Player{0}", i + 1);
            playerInstance.GetComponent<PlayerController>().PlayerName = playerInstance.name;
            playerInstance.GetComponent<PlayerController>().e_tagged += NewPlayerTagged;

            players.Add(playerInstance.GetComponent<PlayerController>());
        }
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        players[0].SwitchRoles();
        gameTime = playTime;     
    }

    public string GetWinner()
    {
        IOrderedEnumerable<PlayerController> lista = players.OrderBy(player => player.Score);
        return "El ganador fue " + lista.First().name + " con solo " + lista.First().Score + " solo y el peor fue " + lista.Last().name + " con " + lista.Last().Score +" puntos";
    }

    private void Update()
    {
            gameTime -= Time.deltaTime;
            if (gameTime <= 0) {
                gameTime = 0;
            try
                {
                    e_EndGame();
                Pause();

                }
                catch (System.Exception e) {
                }
            }
    }

    private void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    private void NewPlayerTagged(PlayerController player) {


        try
        {
            e_newPlayerTagger(player);
        }
        catch (System.NullReferenceException e)
        {
            Debug.Log("Eventos no suscritos al GM");
        }
    }
    
}