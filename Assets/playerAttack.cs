/*using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] BubbleHolder;

    private Animator anim;
    private playerController playerController;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<playerController>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;

        BubbleHolder[FindBubble()].transform.position = firePoint.position;
        BubbleHolder[FindBubble()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindBubble()
    {
        for (int i = 0; i < BubbleHolder.Length; i++)
        {
            if (!BubbleHolder[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}*/