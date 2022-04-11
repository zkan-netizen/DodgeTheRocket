using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private bool MissionCompleted;
    [SerializeField] private GameObject Diamond;
    [SerializeField] private GameObject FinishDoor;
    Vector3 direct;
    [SerializeField] private List<GameObject> RocketDestroyers = new List<GameObject>();
    void Start()
    {
        MissionCompleted = false;
        Player = GameObject.FindWithTag("Player").transform;
        Diamond = GameObject.FindWithTag("Diamond");
        FinishDoor = GameObject.FindWithTag("WillOpen");
        direct = new Vector3(0, 0, -2);
    }



    private void PointOne()
    {
        if (this.gameObject.tag == "BlockPoint")
        {

            Debug.Log("BANG");
            RocketDestroyers[0].transform.rotation = Quaternion.Euler(0, 0, 0);
            RocketDestroyers[0].transform.position = this.gameObject.transform.position;
            RocketDestroyers[0].transform.rotation = this.gameObject.transform.rotation;
            RocketDestroyers.Add(GameObject.FindWithTag("RocketDestroyer"));
            return;
        }
    }
    private void FinishPoint()
    {
        if (this.gameObject.tag == "FinishPoint")
        {
            RocketDestroyers[0].transform.rotation = Quaternion.Euler(0, 0, 0);
            RocketDestroyers[0].transform.position = this.gameObject.transform.position + direct;
            RocketDestroyers[0].transform.rotation = this.gameObject.transform.rotation;
            RocketDestroyers.Add(GameObject.FindWithTag("RocketDestroyer"));
            FinishDoor.SetActive(false);
        }
    }

    private void MissionChecker()
    {
        if (Vector3.Distance(Diamond.transform.position, Player.position) < 1f)
        {
            MissionCompleted = true;
            Debug.Log("Taken");
            Diamond.SetActive(false);
        }

    }

    private void Update()
    {
        MissionChecker();
    }
    void OnTriggerEnter(Collider _isCol)
    {
        if (_isCol.gameObject.tag == ("Rocket") || _isCol.gameObject.tag == "Agent")
        {
            PointOne();
        }
        if (_isCol.gameObject.tag == ("Player"))
        {
            FinishPoint();
        }

    }










}
