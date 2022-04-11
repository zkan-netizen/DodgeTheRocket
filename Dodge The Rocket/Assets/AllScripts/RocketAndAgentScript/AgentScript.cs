using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    [SerializeField] private NavMeshAgent Agent;
    [SerializeField] CharacterController _agent;
    [SerializeField] private GameObject _target;
    [SerializeField] private float _distance;
    void Start()
    {
        Agent.GetComponent<CharacterController>();
    }
    void GetDistance()
    {
        _distance = Vector3.Distance(transform.position, _target.transform.position);
        Agent.SetDestination(_target.transform.position);
        if (_distance <= 10)
        {
            Agent.enabled = true;
        }
        {
            Agent.enabled = false;
        }
    }
    void Update()
    {
        GetDistance();
    }

}
