using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State  {
    
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
//대기
public class Idle : State
{
    GameObject charOBJ;
    public override void Enter(GameObject obj)
    {
        charOBJ = obj;
        
        
    }

    public override void Execute(GameObject obj)
    {
        if (obj.GetComponent<PlayerController>().playerVector.magnitude > 0.2f)
        {
            obj.GetComponent<PlayerController>().Change(PlayerController.stateMachine.Move);
        }
    }

    public override void Exit(GameObject obj)
    {

    }
}
//이동
public class Move : State
{
    GameObject charOBJ;
    Vector3 playerLook;
    public override void Enter(GameObject obj)
    {
        charOBJ = obj;
        charOBJ.GetComponent<Animator>().SetBool("Move", true);    }

    public override void Execute(GameObject obj)
    {
        playerLook = charOBJ.GetComponent<PlayerController>().playerVector;
        if (playerLook.x != 0 && playerLook.y != 0)
        charOBJ.transform.rotation = Quaternion.LookRotation(new Vector3(playerLook.x, 0.0f, playerLook.y));
        charOBJ.transform.Translate(0, 0, playerLook.magnitude * charOBJ.GetComponent<PlayerController>().playerSpeed*Time.deltaTime);
        
        if (obj.GetComponent<PlayerController>().playerVector.magnitude < 0.2f)
        {
            obj.GetComponent<PlayerController>().Change(PlayerController.stateMachine.Idle);
        }
    }

    public override void Exit(GameObject obj)
    {
        charOBJ.GetComponent<Animator>().SetBool("Move", false);
    }
}
//공격
public class Attack : State
{
    GameObject charOBJ;
    Animator charAnim;
    public override void Enter(GameObject obj)
    {
        charOBJ = obj;
        charAnim = charOBJ.GetComponent<Animator>();
        charAnim.SetTrigger("Jab");
    }

    public override void Execute(GameObject obj)
    {
        if (charAnim.GetCurrentAnimatorStateInfo(0).length > charAnim.GetCurrentAnimatorStateInfo(0).normalizedTime &&
            (!charAnim.GetCurrentAnimatorStateInfo(0).IsName("Jab") &&
            !charAnim.GetCurrentAnimatorStateInfo(0).IsName("Spinkick") &&
            !charAnim.GetCurrentAnimatorStateInfo(0).IsName("RisingPunch")))
        {
            charOBJ.GetComponent<PlayerController>().Change(PlayerController.stateMachine.Idle);
        }
        else {
            if (charOBJ.GetComponent<PlayerController>().isCombo)
            {
                if (charAnim.GetCurrentAnimatorStateInfo(0).IsName("Jab"))
                {
                    charAnim.SetTrigger("Spinkick");
                    charOBJ.GetComponent<PlayerController>().isCombo = false;
                }
                else if (charAnim.GetCurrentAnimatorStateInfo(0).IsName("Spinkick"))
                {
                    charAnim.SetTrigger("RisingPunch");
                    charOBJ.GetComponent<PlayerController>().isCombo = false;
                }
            }
        }
    }

    public override void Exit(GameObject obj)
    {
        charAnim.ResetTrigger("Jab");
        charAnim.ResetTrigger("Spinkick") ;
        charAnim.ResetTrigger("RisingPunch");
}
}
//사망
public class Death : State
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
