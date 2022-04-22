using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RocketScript : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particlesystem;
public static AgentGuardScript agentscript;
    [SerializeField]
    protected bool isBang; //Controller of destroy ExplosionParticleSystem

    [SerializeField]
    protected bool canDestroy; //Controller of destroy ExplosionParticleSystem

    [SerializeField]
    protected bool canLaunch = true; //Controller of navmesh system

    [SerializeField]
    private float _distance; //Controller of between agent and target's distance

    [SerializeField]
    private GameObject Target;

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
            _navmeshagent.angularSpeed += Time.deltaTime * 2;
            _navmeshagent.acceleration += Time.deltaTime*0.05f;
            _navmeshagent.SetDestination(Target.transform.position);
            _distance =
                Vector3.Distance(transform.position, Target.transform.position);

            // _navmeshagent.stoppingDistance = 5;
            if (this.gameObject.tag == "Agent")
            {
                _distance =
                    Vector3
                        .Distance(transform.position,
                        Target.transform.position);
                if (_distance < 7)
                {
                   AgentGuardScript.SpotterCondition=false;
                    this._navmeshagent.speed = 4.5f;
                }
                else
                {
                    AgentGuardScript.SpotterCondition=true;
                    isBang = false;
                    this._navmeshagent.speed = 0;
                }
            }
            // if (this.gameObject.tag == "Rocket")
            // {
            //     this.transform.position =
            //         transform.position = transform.position.Change(x: 1.3f);
            // }
        }
    }

    void ControlParticle()
    {
        if (isBang == true && this.gameObject.tag == "Rocket")
        {
            _particlesystem.Play();
            if (canDestroy == true)
            {
                isBang = false;
            }
        }
        else if (isBang == false && canDestroy == true)
        {
            if (this.gameObject.tag == "Rocket")
            {
                _particlesystem.transform.position =
                    this.gameObject.transform.position;
                Destroy(_particlesystem.gameObject, .9f);

                // _particlesystem.gameObject.SetActive(false);
                canDestroy = false;
                canLaunch = false;
                this.gameObject.SetActive(false);
                return;
            }
        }
    }

    void Update()
    {
        ControlParticle();
        getTarget();
    }

    void OnTriggerEnter(Collider col)
    {
#region  //Rocket and Agent collision condition on Player
        if (this.gameObject.tag == "Rocket")
        {
            if (col.gameObject.tag == "Player" || col.gameObject.tag == "Agent")
            {
                Debug.Log("KillPlayerOrAgent");
                isBang = true;
                canDestroy = true;
            }
        }
        if (this.gameObject.tag == "Agent")
        {
            if (col.gameObject.tag == "Player")
            {
                this.gameObject.SetActive(false); //use animation here instead of this code
                Debug.Log("Catched");
            }
        }
#endregion



#region //Rocket and Agent collision condition on Blocks
        if (
            col.gameObject.tag == "BlockPoint" ||
            col.gameObject.tag == "RocketDestroyer"
        )
        {
            Debug.Log("DestroyRocket");

            isBang = true;
            canDestroy = true;
            if (this.gameObject.tag == "Agent")
            {
                _navmeshagent.speed = 0;
            }

            //rotary block part
        }
#endregion


        if (
            col.gameObject.tag == "RotaryBlock" ||
            col.gameObject.tag == "LaserProtect"
        )
        {
            Debug.Log("BangOnRotary");
            isBang = true;
            canDestroy = true;
        }
    }
}
