 
using UnityEngine;
using UnityEngine.AI;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;

    private bool isSquat = false;
    private bool isFighting = false;  
     
    private void Update()
    {
        if (isSquat)
            AnimationSquatWalk();
        else if (isFighting)
            AnimationFighting();
        else
            AnimationRun();
    }  
    private void CheckKayDown()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSquat = false;
            isFighting = false;
        } 
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isFighting = false;
            isSquat = true;
        } 
        else if (Input.GetKeyDown(KeyCode.F))
        {
            isFighting =true;
            isSquat = false;
        }
    }

    private void AnimationRun()
    {
        anim.SetBool("isFighting", false);
        anim.SetBool("isSquat", false);
        agent.speed = 10f; 
        anim.SetFloat("SpeedMove", SpeedCalculate(), 0.1f, Time.deltaTime); 
    }

    private void AnimationSquatWalk()
    {
        anim.SetBool("isFighting", false);
        anim.SetBool("isSquat", true);
        agent.speed = 3.5f; 
        anim.SetFloat("SquatMove", SpeedCalculate(), 0.1f, Time.deltaTime); 
    }
    private void AnimationFighting()
    {
        anim.SetBool("isSquat", false);
        anim.SetBool("isFighting", true);
        agent.speed = 5f;  
    }
    private float SpeedCalculate()
    {
        CheckKayDown();
        return agent.velocity.magnitude / agent.speed; 
    }
    public void Fite()
    {
        anim.SetBool("Kick", true);
    }
    
}
