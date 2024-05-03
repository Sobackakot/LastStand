
using UnityEngine;
using UnityEngine.AI;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animatorPerson;

    [Header("Current speed move")]
    [SerializeField,Range(1,50)] private float agentMoveStanding = 10f;
    [SerializeField,Range(1,25)] private float agentMoveSitting = 3.5f;

    private void Update()
    {
        AnimatorUpdate();
    }
    public void AnimatorUpdate()
    {
        float speedAnimator = agent.velocity.sqrMagnitude > 0 ? SpeedCalculate() : 0f;
        animatorPerson.SetFloat("MoveSitting", speedAnimator, 0.1f, Time.deltaTime);
        animatorPerson.SetFloat("MoveStanding", speedAnimator, 0.1f, Time.deltaTime);
    }
    public void WalkSittingAnim()
    {
        agent.speed = agentMoveSitting;
        animatorPerson.SetBool("isSquat", true); 
    }
    public void MoveStandingAnim()
    {
        agent.speed = agentMoveStanding;
        animatorPerson.SetBool("isSquat", false);
    }
    private float SpeedCalculate()
    {
        return agent.velocity.magnitude / agent.speed; 
    }
    
}
