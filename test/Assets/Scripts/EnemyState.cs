using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyState 
{
    public virtual void Enter(GameObject obj)
    {

    }

    public virtual void Execute(GameObject obj)
    {

    }

    public virtual void Exit(GameObject obj)
    {

    }

	
}
public class EnemyIdle: EnemyState
{
    GameObject charOBJ;
    public override void Enter(GameObject obj)
    {
        charOBJ = obj;
        if (charOBJ.GetComponent<Animator>() != null)
        {
            charOBJ.GetComponent<Animator>().SetBool("Move",false);
        }
        else
        {
            charOBJ.GetComponent<Animation>().Play("Idle");

        }

    }

    public override void Execute(GameObject obj)
    {
       // Debug.Log(this.charOBJ.GetComponent<Animator>());
        if (Vector3.Magnitude(charOBJ.transform.position - charOBJ.GetComponent<Enemy>().target.transform.position) >= 2.0f)
        {
            charOBJ.GetComponent<Enemy>().Change(Enemy.EnemystateMachine.Move);
        }
        else if (Vector3.Magnitude(charOBJ.transform.position - charOBJ.GetComponent<Enemy>().target.transform.position) < 2.0f)
        {
            charOBJ.transform.LookAt(charOBJ.GetComponent<Enemy>().target.transform.position);
        }
    }

    public override void Exit(GameObject obj)
    {

    }


}
public class EnemyMove: EnemyState
{
    GameObject charOBJ;
    public override void Enter(GameObject obj)
    {
        charOBJ = obj;
        if (charOBJ.GetComponent<Animator>() != null)
        {
            this.charOBJ.GetComponent<Animator>().SetBool("Move", true);
        }
        else
        {
            charOBJ.GetComponent<Animation>().Play("Move");

        }
        charOBJ.GetComponent<NavMeshAgent>().enabled = true;
        charOBJ.GetComponent<NavMeshAgent>().destination = charOBJ.GetComponent<Enemy>().target.transform.position;
    }

    public override void Execute(GameObject obj)
    {
        charOBJ.GetComponent<NavMeshAgent>().destination = charOBJ.GetComponent<Enemy>().target.transform.position;
        if (Vector3.Magnitude(charOBJ.transform.position - charOBJ.GetComponent<Enemy>().target.transform.position) < 2.0f)
        {
            charOBJ.GetComponent<Enemy>().Change(Enemy.EnemystateMachine.Idle);
        }
        Debug.Log(charOBJ.GetComponent<Enemy>().m_AttackDelay);
    }

    public override void Exit(GameObject obj)
    {

    }


}
public class EnemyAttack: EnemyState
{
    GameObject charOBJ;
    public override void Enter(GameObject obj)
    {
        charOBJ = obj;
        if (charOBJ.GetComponent<Animator>() != null)
        {
            charOBJ.GetComponent<Animator>().SetTrigger("Attack");
        }
        else
        {
            charOBJ.GetComponent<Animation>().Play("Attack");

        }
    }

    public override void Execute(GameObject obj)
    {

    }

    public override void Exit(GameObject obj)
    {

    }


}
public class EnemyDeath: EnemyState
{
    GameObject charOBJ;
    public override void Enter(GameObject obj)
    {
        charOBJ = obj;


    }

    public override void Execute(GameObject obj)
    {

    }

    public override void Exit(GameObject obj)
    {

    }


}
public class EnemySkill: EnemyState
{
    GameObject charOBJ;
    public override void Enter(GameObject obj)
    {
        charOBJ = obj;


    }

    public override void Execute(GameObject obj)
    {

    }

    public override void Exit(GameObject obj)
    {

    }


}

