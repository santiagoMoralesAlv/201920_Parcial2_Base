using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : MonoBehaviour
{
    private PlayerController m_playerController;

    private Text head;

    private void Start()
    {
        m_playerController.e_tagged -= UpdateScore;
        m_playerController.e_tagged += UpdateScore;
    }

    public void UpdateScore(string playerName, int score) {
        head.text = playerName + " / "+ score;
    }
}
