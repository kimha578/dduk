using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    }

    public override void Execute(GameObject obj)
    {
        
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


    }

    public override void Execute(GameObject obj)
    {

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

