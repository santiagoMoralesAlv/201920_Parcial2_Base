using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayer : MonoBehaviour
{
    [SerializeField]
    private PlayerController m_playerController;

    [SerializeField]
    private TextMeshPro head;

    [SerializeField]
    private GameObject indicadorTagged;

    private void Awake()
    {
        m_playerController.e_tagged += Tagged;
        m_playerController.e_untagged += UnTagged;


    }

    private void Start()
    {

        head.text = m_playerController.PlayerName + " / " + 0;
    }


    public void Tagged(PlayerController player) {
        head.text = player.PlayerName + " / "+ player.Score;
        indicadorTagged.SetActive(true);
    }

    public void UnTagged(PlayerController player)
    {
        indicadorTagged.SetActive(false);
    }
}
