using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMonster : Enemy
{
    public float m_StoneDelay = 3.0f;

    protected override void Awake()
    {
        base.Awake();
        SetDelay();
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Change(EnemystateMachine nextState)
    {
        base.Change(nextState);
    }

    protected override void SetDelay()
    {
        m_AttackDelay = m_StoneDelay;
        m_LastAttack = m_AttackDelay;
    }
}
