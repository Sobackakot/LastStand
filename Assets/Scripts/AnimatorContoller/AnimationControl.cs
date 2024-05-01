 
using UnityEngine;
using UnityEngine.AI;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator anim;

    public float agentMoveStanding = 10f;
    public float agentMoveSitting = 3.5f;
    private void Update()
    {
        AnimatorUpdate();
    }
    public void AnimatorUpdate()
    {
        float speedAnimator = agent.velocity.sqrMagnitude > 0 ? SpeedCalculate() : 0f;
        anim.SetFloat("MoveSitting", speedAnimator, 0.1f, Time.deltaTime);
        anim.SetFloat("MoveStanding", speedAnimator, 0.1f, Time.deltaTime);
    }
    public void WalkSittingAnim()
    {
        agent.speed = agentMoveSitting;
        anim.SetBool("isSquat", true); 
    }
    public void MoveStandingAnim()
    {
        agent.speed = agentMoveStanding;
        anim.SetBool("isSquat", false);
    }
    private float SpeedCalculate()
    {
        return agent.velocity.magnitude / agent.speed; 
    }
    
}
