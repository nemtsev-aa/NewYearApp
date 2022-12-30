using UnityEngine;

public class RabbitMove : MonoBehaviour
{
    public Transform Target;
    public float Speed;
    [Tooltip("Как близко приближаться к Target")]
    public float RelaxDistance;

    private Animator animator;

    public void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        var dir = Target.position - transform.position;
        if (dir.sqrMagnitude > RelaxDistance * RelaxDistance)
        {
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Target.position, step);

            transform.LookAt(Target);
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
}
