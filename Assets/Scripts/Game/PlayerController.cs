using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public abstract class PlayerController : MonoBehaviour
{
    private string playerName;
    private int score;

    private bool canMov=true;
    [SerializeField]
    private float stopTime = 3F;
    protected NavMeshAgent agent { get; set; }

    public delegate void Tagged(string playerName, int score);
    public event Tagged e_tagged;

    public bool IsTagged { get; protected set; }

    public string PlayerName
    {
        get
        {
            return playerName;
        }

        set
        {
            playerName = value;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
    }


    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        e_tagged += UpdateScore;
    }

    public void SwitchRoles()
    {
        IsTagged = !IsTagged;

        if (IsTagged == true) {
            StopLogic();
            try
            {
                e_tagged(playerName, score);
            }
            catch (System.Exception e) {
                Debug.Log("Eventos no suscritos");
            }
        }
        // Pause all logic and restart after
    }

    public void GoToLocation(Vector3 location)
    {
        if (canMov)
        {
            agent.SetDestination(location);
        }
    }

    public virtual IEnumerator StopLogic()
    {
        // Stop BT runner if AI player, else stop movement.
        canMov = false;
        yield return new WaitForSeconds(stopTime);
        canMov = true;
        // Restart stuff.
    }

    protected abstract Vector3 GetLocation();


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && IsTagged)
        {
            SwitchRoles();
            collision.gameObject.GetComponent<PlayerController>().SwitchRoles();
        }
    }

    private void UpdateScore()
    {
        score++;
    }
    
}