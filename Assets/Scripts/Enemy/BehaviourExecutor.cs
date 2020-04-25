using UnityEngine;
using BehaviourCase = EnemyBehaviourHandler.BehaviourEnum;
public class BehaviourExecutor : MonoBehaviour
{
    public GameObject player;
    EnemyBehaviourHandler behaviour;
    MeleeAttackHandler meleeAttackHandler;

    [Header("Enemy")]
    public float speed;
    Vector2 moveDirection;

    [Header("Field of sight")]
    FieldOfSight fieldOfSight;
    public float angleOfSight;


    private void Start()
    {
        meleeAttackHandler = GetComponent<MeleeAttackHandler>();
        behaviour = GetComponent<EnemyBehaviourHandler>();
        fieldOfSight = GetComponent<FieldOfSight>();
    }

    void Update()
    {
        executeBehaviour(behaviour.getBehaviour());
    }

    void executeBehaviour(BehaviourCase behaviour)
    {
        GetComponent<EnemyAnimatorHandler>().updateAnimator(behaviour);
        switch (behaviour)
        {
            case BehaviourCase.GetCrazy:
                break;
            case BehaviourCase.Attack:
                attack();
                break;
            case BehaviourCase.KeepGuardStand:
                break;
            case BehaviourCase.RunBackwards:
                runBackwards();
                break;
            case BehaviourCase.KeepGuardRight:
                keepGuardRight();
                break;
            case BehaviourCase.KeepGuardLeft:
                keepGuardLeft();
                break;
            case BehaviourCase.Idle:
                break;
            case BehaviourCase.PerformAttack:
                performAttack();
                break;
            default:
                Debug.Log("[BehaviourExecutor] Unknown behaviour: " + behaviour);
                break;
        }
    }

    void performAttack()
    {
        GetComponent<MeleeAttackHandler>().attack();
    }

    void attack()
    {
        runTowardsPlayer();
    }

    void runTowardsPlayer()
    {
        Vector3 direction = player.transform.position - gameObject.transform.position;
        Vector3 unitaryDir = direction.normalized;
        moveEnemy(unitaryDir, speed);
    }

    void moveEnemy(Vector3 dir, float speed)
    {
        //transform.position += new Vector3(dir.x, 0, dir.y) * speed * Time.deltaTime;
        Vector3 force = new Vector3(dir.x, 0, dir.z) * speed;
        transform.GetComponent<Rigidbody>().AddForce(force);
    }

    void runBackwards()
    {
        Vector3 direction = player.transform.position - gameObject.transform.position;
        Vector3 unitaryDir = direction.normalized;
        moveEnemy(unitaryDir * (-1), speed);
    }

    void Attack()
    {

    }

    void keepGuardRight()
    {
        setMoveDirection(gameObject.transform.position - player.transform.position);
        Vector2 unitaryDir = Vector2.Perpendicular(moveDirection.normalized);
        moveEnemy(unitaryDir, speed);
    }

    void keepGuardLeft()
    {
        setMoveDirection(gameObject.transform.position - player.transform.position);
        Vector2 unitaryDir = Vector2.Perpendicular(moveDirection.normalized);
        moveEnemy(unitaryDir * -1, speed);
    }

    void setMoveDirection(Vector3 initialDirection)
    {
        moveDirection = new Vector2(initialDirection.x, -initialDirection.z);
    }


}
