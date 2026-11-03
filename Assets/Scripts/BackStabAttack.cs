using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class BackStabAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float bsAngle = -0.5f;
    public TMP_Text feedback;

    public EnemyPatrol enemyPatrol;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }

    void Attack()
    {

        if (enemyPatrol == null)
        {
            feedback.text = "No Enemies!";
            return;
        }

        Vector3 enemyPos = enemyPatrol.transform.position;
        float distance = Vector3.Distance(transform.position, enemyPos);

        if (distance > attackRange)
        {
            feedback.text = "Attack Failed";
            return;
        }

        Vector3 directionToPlayer = transform.position - enemyPatrol.transform.position;

        directionToPlayer.y = 0f;
        directionToPlayer.Normalize();

        Vector3 enemyForward = enemyPatrol.transform.forward;
        enemyForward.y = 0f;
        enemyForward.Normalize();

        float dotProduct = Vector3.Dot(enemyForward, directionToPlayer);

        if (dotProduct > bsAngle)
        {
            feedback.text = "Backstab Success!";
            enemyPatrol.Death();
        }
        else
        {
            feedback.text = "Attack Failed!";
        }
    }
}
