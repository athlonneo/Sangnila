using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    public int damagePerAttack = 20;
    public float timeBetweenAttacks = 0.15f;
    public float range = 10f;
    public GameObject magicPrefab;
    public Transform magicSpawn;
    public AudioSource attackAudio;

    float timer;
    Animator anim;

    int floorMask;
    float camRayLength = 100f;

    ParticleSystem exp;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Terrain");
        anim = GetComponent<Animator>();
        exp = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire2"))
        {
            Animate();
            if (timer >= timeBetweenAttacks && !GameOverManager.isGameOver)
            {
                Attack();
            }
        }
    }

    void Animate()
    {
        anim.SetTrigger("Attack");
        attackAudio.Play();
        if (exp)
        {
            //exp.Play();
        }

    }

    void Attack()
    {
        timer = 0f;

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            
            playerToMouse.y = 0f;
            
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            var magicBall = (GameObject)Instantiate(magicPrefab, magicSpawn.transform.position, newRotation) as GameObject;

            Rigidbody rb = magicBall.GetComponent<Rigidbody>();

            rb.AddForce(magicBall.transform.forward * 10, ForceMode.Impulse);

            Destroy(magicBall, 1.5f);
        }
    }
}
