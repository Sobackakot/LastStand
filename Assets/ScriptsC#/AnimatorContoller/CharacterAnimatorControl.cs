
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimatorControl : MonoBehaviour, ICharacterComponent
{

    [SerializeField] private InputControlPerson inputControlPerson;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animatorPerson;

    [Range(1,50)] private float agentMoveStanding = 10f;
    [Range(1,25)] private float agentMoveSitting = 3.5f;

    private void OnEnable()
    {
        inputControlPerson.onCtrlButton += WalkSittingAnim;
        inputControlPerson.onSpaceButton += MoveStandingAnim;
    }
    private void OnDisable()
    {
        inputControlPerson.onCtrlButton -= WalkSittingAnim;
        inputControlPerson.onSpaceButton -= MoveStandingAnim;
    }
    private void LateUpdate()
    {
        AnimatorUpdate();
    }
    public void EnableAnimator()
    {
        enabled = true;
    }
    public void DisableAnimator()
    {
        enabled = false;
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

    public ICharacterComponent GetComponent()
    {
        throw new System.NotImplementedException();
    }

    public void OnEnableComponent()
    {
        throw new System.NotImplementedException();
    }

    public void OnDisableComponent()
    {
        throw new System.NotImplementedException();
    }
}
