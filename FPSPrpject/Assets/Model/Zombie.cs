using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zombie : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float detectRange = 10f;
    public float attackRange = 1.5f;
    public Transform target;
    public GameObject zombi;

    private Animator animator;
    private bool isAttacking = false;
    private bool isChasing = false;

    public int Saldiri;
    public GameObject EkranFlas;
    public AudioSource[] sound;
    public int VurmaSesi;

   // public int soncan = KalanCan.OyuncuCan; // Ba�lang��ta 3 can
    private float attackCooldown = 1.5f; // Sald�r� aral���
    private float currentCooldown = 0f;

    void Start()
    {
        animator = zombi.GetComponent<Animator>();
        InvokeRepeating("RandomMovement", 0f, 2f);
    }

    void Update()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= attackRange)
            {
                Attack();
            }
            else if (distanceToTarget <= detectRange)
            {
                MoveTowardsTarget();
                isChasing = true;
            }
            else
            {
                isChasing = false;
                animator.SetBool("Walking", false);
                animator.SetBool("Attacking", false);
            }
        }

        // Sald�r� aral���n� kontrol et
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
        else
        {
            isAttacking = false; // Sald�r� s�resi bitti�inde izin ver
        }
    }

    void RandomMovement()
    {
        if (!isChasing)
        {
            float randomAngle = Random.Range(0f, 360f);
            transform.Rotate(0f, randomAngle, 0f);
        }
    }

    void MoveTowardsTarget()
    {
        transform.LookAt(target);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        animator.SetBool("Walking", true);
        animator.SetBool("Attacking", false);
    }

    void Attack()
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Attacking", true);

        if (!isAttacking && KalanCan.OyuncuCan > 0) // Sald�r� yapabilir ve can� varsa
        {
            isAttacking = true;
            KalanCan.OyuncuCan -= 1; // Can� azalt
            currentCooldown = attackCooldown; // Sald�r� aral���n� ba�lat

            if (KalanCan.OyuncuCan > 0)
            {
                // Rastgele bir ses �al
                int randomSoundIndex = Random.Range(0, sound.Length);
                sound[randomSoundIndex].Play();

                // Ekran fla��n� h�zl� bir �ekilde aktif et ve pasifle�tir
                StartCoroutine(ActivateAndDeactivateFlash());
            }
        }
    }

    IEnumerator ActivateAndDeactivateFlash()
    {
        EkranFlas.SetActive(true); // Ekran fla��n� aktif et
        yield return new WaitForSeconds(0.1f); // K�sa bir s�re beklet
        EkranFlas.SetActive(false); // Ekran fla��n� pasifle�tir
    }
}
