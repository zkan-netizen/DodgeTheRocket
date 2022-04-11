using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RocketScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particlesystem;
    [SerializeField] protected bool isBang;//Controller of destroy ExplosionParticleSystem
    [SerializeField] protected bool canDestroy;//Controller of destroy ExplosionParticleSystem
    [SerializeField] protected bool canLaunch = true;//Controller of navmesh system
    [SerializeField] private float _distance;//Controller of between agent and target's distance

    [SerializeField] private GameObject Target;
    NavMeshAgent _navmeshagent;

    void Start()
    {

        _navmeshagent = GetComponent<NavMeshAgent>();

        _particlesystem.Stop();


        // ParticleSystem ps = GameObject.Find("ParticaleSystem-Object-Name").GetComponent<ParticleSystem>();
        // _navmeshagent.acceleration = 20; kullan zamanla zorlaşması için
        //_navmeshagent.enabled=false patlama efekti öncesi roketin durması için
    }

    void getTarget()
    {
        if (canLaunch == true)
        {
            _navmeshagent.speed += Time.deltaTime / 25;
            _navmeshagent.angularSpeed += Time.deltaTime * 10;
            _navmeshagent.acceleration += Time.deltaTime;
            _navmeshagent.SetDestination(Target.transform.position);
            _distance = Vector3.Distance(transform.position, Target.transform.position);
            // _navmeshagent.stoppingDistance = 5;
            if (this.gameObject.tag == "Agent")
            {
                _distance = Vector3.Distance(transform.position, Target.transform.position);
                if (_distance < 7)
                {
                    this._navmeshagent.speed = 4.5f;

                }
                else
                {

                    isBang = false;
                    this._navmeshagent.speed = 0;

                }

            }
        }
    }
    void Update()
    {

        ControlParticle();
        getTarget();
    }

    private void KillPlayer()
    {

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {

            Debug.Log("KillPlayer");
            isBang = true;
            canDestroy = true;

        }

        if (col.gameObject.tag == "BlockPoint" || col.gameObject.tag == "RocketDestroyer")
        {
            Debug.Log("DestroyRocket");

            isBang = true;
            canDestroy = true;
            _navmeshagent.speed = 0;
        }

    }





    void ControlParticle()
    {

        if (isBang == true)
        {
            _particlesystem.Play();
            if (canDestroy == true)
            {
                isBang = false;

            }

        }
        else if (isBang == false && canDestroy == true)
        {
            _particlesystem.transform.position = this.gameObject.transform.position;
            Destroy(_particlesystem.gameObject, .9f);
            // _particlesystem.gameObject.SetActive(false);
            canDestroy = false;
            canLaunch = false;
            this.gameObject.SetActive(false);
            return;
        }

    }
}
