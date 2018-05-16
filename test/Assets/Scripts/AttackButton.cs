using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour {

    public PlayerController m_PlayerController;

    public void OnClick()
    {
        if (m_PlayerController != null)
        {
           
            m_PlayerController.OnAttack();
        }
    }
}
