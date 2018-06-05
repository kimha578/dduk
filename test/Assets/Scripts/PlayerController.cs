using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum stateMachine { 
        Idle,
        Move,
        Attack, 
        Death
    }

    stateMachine currentState;
    Idle m_Idle = new Idle();
    Move m_Move = new Move();
    Attack m_Attack = new Attack();
    Death m_Death = new Death();
    public  bool isCombo = false;
    public Vector2 playerVector = Vector2.zero;
    public Rigidbody rigidbady;
    public float playerSpeed = 10.0f;
    public Collider jabBox;
    public Collider spinkickBox;
    public Collider risingPunchBox;

	// Use this for initialization
	void Start () {
        m_Idle.Enter(this.gameObject);
        currentState = stateMachine.Idle;
        rigidbady = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        switch (currentState)
        {
            case stateMachine.Idle:
                m_Idle.Execute(this.gameObject);
                break;
            case stateMachine.Move:
                m_Move.Execute(this.gameObject);
                break;
            case stateMachine.Attack:
                m_Attack.Execute(this.gameObject);
                break;
            case stateMachine.Death:
                m_Death.Execute(this.gameObject);
                break;
        }
	}

    public void Change(stateMachine nextState)
    {
        if (currentState == nextState) return;
        switch (currentState)
        {
            case stateMachine.Idle:
                m_Idle.Exit(this.gameObject);
                break;
            case stateMachine.Move:
                m_Move.Exit(this.gameObject);
                break;
            case stateMachine.Attack:
                m_Attack.Exit(this.gameObject);
                break;
            case stateMachine.Death:
                m_Death.Exit(this.gameObject);
                break;
        }
        currentState = nextState;
        switch (currentState)
        {
            case stateMachine.Idle:
                m_Idle.Enter(this.gameObject);
                break;
            case stateMachine.Move:
                m_Move.Enter(this.gameObject);
                break;
            case stateMachine.Attack:
                m_Attack.Enter(this.gameObject);
                break;
            case stateMachine.Death:
                m_Death.Enter(this.gameObject);
                break;
        }

       
    }
    public void OnVectorChange(Vector3 vec3)
    {
        playerVector = new Vector2(vec3.x, vec3.y);
       

    }

    public void OnAttack()
    {
        if (currentState != stateMachine.Attack)
        {
            Change(stateMachine.Attack);
        }
        else 
        {
            isCombo = true;
        }
    }

    public void OnJabHitBox()
    {
        jabBox.gameObject.SetActive(true);
    }
    public void OffJabHitBox()
    {
        jabBox.gameObject.SetActive(false);
    }

    public void OnSpinkickHitBox()
    {
        spinkickBox.gameObject.SetActive(true);
    }

    public void OffSpinkickHitBox()
    {
        spinkickBox.gameObject.SetActive(false);
    }

    public void OnRisingPunchHitBox()
    {
        risingPunchBox.gameObject.SetActive(true);
    }

    public void OffRisingPunchHitBox()
    {
        risingPunchBox.gameObject.SetActive(false);
    }
}
