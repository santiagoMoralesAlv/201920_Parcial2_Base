using AI;
using UnityEngine;

[RequireComponent(typeof(BehaviourRunner))]
public class AIController : PlayerController
{
    [SerializeField]
    private GameObject target;

    public GameObject Target
    {
        get
        {
            return target;
        }

        set {
            target = value;
        }
    }

    protected void Awake()
    {
        GameController.Instance.e_newPlayerTagger += UpdateEnemyTagged;
    }

    private void UpdateEnemyTagged(PlayerController enemyTagged)
    {
        if (enemyTagged != this)
        {
            target = enemyTagged.gameObject;
        }
        else {
            Debug.Log("Soy el taggeado");
        }
    }



}