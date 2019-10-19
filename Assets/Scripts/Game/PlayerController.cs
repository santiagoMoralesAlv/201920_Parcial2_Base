using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public abstract class PlayerController : MonoBehaviour
{
    private string playerName;
    private int score;

    [SerializeField]
    private bool canMov=true;
    [SerializeField]
    private float stopTime = 3F;
    protected NavMeshAgent agent { get; set; }
    
    public event GameController.Tagged e_tagged;
    public event GameController.Tagged e_untagged;

    [SerializeField]
    private bool isTagged;

    public bool CanMove { get { return canMov; } }
    public bool IsTagged { get { return isTagged; } }

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
    protected void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SwitchRoles()
    {
        isTagged = !IsTagged;

        if (IsTagged == true)
        {
            StartCoroutine(StopLogic());
            UpdateScore();
            e_tagged(this);
            this.GetComponent<NavMeshAgent>().speed = 30;


            try
            {
                e_tagged(this);
            }
            catch (System.NullReferenceException e)
            {
                Debug.Log("Eventos no suscritos al PC");
            }
        }
        else
        {
            this.GetComponent<NavMeshAgent>().speed = 25f;

            try
            {
                e_untagged(this);
            }
            catch (System.NullReferenceException e)
            {
                Debug.Log("Eventos no suscritos al pC");
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
        canMov = false;
        yield return new WaitForSeconds(stopTime);
        canMov = true;
    }
    
    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && isTagged && canMov)
        {
            Debug.Log("Colision"+this.playerName);
            SwitchRoles();
            collision.gameObject.GetComponent<PlayerController>().SwitchRoles();
        }
    }

    private void UpdateScore()
    {
        score++;
    }

    
    
}