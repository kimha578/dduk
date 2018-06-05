using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
    public enum EnemystateMachine
    {
        Idle,
        Move,
        Attack,
        Death
    }

    public GameObject enemyOBJ;
    public GameObject target;
    EnemyIdle    m_Idle =   new EnemyIdle();
    EnemyMove    m_Move =   new EnemyMove();
    EnemyAttack  m_Attack = new EnemyAttack();
    EnemyDeath   m_Death =  new EnemyDeath();
    EnemystateMachine currentState;
    Rigidbody rb;
	// Use this for initialization
    protected virtual void Awake()
    {
        m_Idle.Enter(this.gameObject);
        currentState = EnemystateMachine.Idle;
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
    protected virtual void Update()
    {
        switch (currentState)
        {
            case EnemystateMachine.Idle:
                m_Idle.Execute(this.gameObject);
                break;
            case EnemystateMachine.Move:
                m_Move.Execute(this.gameObject);
                break;
            case EnemystateMachine.Attack:
                m_Attack.Execute(this.gameObject);
                break;
            case EnemystateMachine.Death:
                m_Death.Execute(this.gameObject);
                break;
        }
	}

    public virtual void Change(EnemystateMachine nextState)
    {
        if (currentState == nextState) return;
        switch (currentState)
        {
            case EnemystateMachine.Idle:
                m_Idle.Exit(this.gameObject);
                break;
            case EnemystateMachine.Move:
                m_Move.Exit(this.gameObject);
                break;
            case EnemystateMachine.Attack:
                m_Attack.Exit(this.gameObject);
                break;
            case EnemystateMachine.Death:
                m_Death.Exit(this.gameObject);
                break;
        }
        currentState = nextState;
        switch (currentState)
        {
            case EnemystateMachine.Idle:
                m_Idle.Enter(this.gameObject);
                break;
            case EnemystateMachine.Move:
                m_Move.Enter(this.gameObject);
                break;
            case EnemystateMachine.Attack:
                m_Attack.Enter(this.gameObject);
                break;
            case EnemystateMachine.Death:
                m_Death.Enter(this.gameObject);
                break;
        }


    }
}
