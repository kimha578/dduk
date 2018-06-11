using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMonster : Enemy {

    public float m_SkeletonDelay = 3.0f;
    protected override void Awake()
    {
        base.Awake();
        SetDelay();
    }
	// Update is called once per frame
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
        m_AttackDelay = m_SkeletonDelay;
        m_LastAttack = m_AttackDelay;
    }

}
