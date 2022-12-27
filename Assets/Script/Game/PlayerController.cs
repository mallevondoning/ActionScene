using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Varible")]
    [SerializeField] private float _speedModifier = 400;

    private Rigidbody _playerRB;

    private void Awake()
    {
        _playerRB = GetComponentInChildren<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 finalDir = new Vector3(Input.GetAxis("Horizontal") * _speedModifier, _playerRB.velocity.y, Input.GetAxis("Vertical")*_speedModifier);
        _playerRB.velocity = finalDir;
    }

    public void AddExplodeForce(float force,Vector3 center,float radius)
    {
        _playerRB.AddExplosionForce(force, center, radius, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyController checkEC = other.gameObject.GetComponent<EnemyController>();
        if (checkEC == null)
        {
            GameManager.Instance.StopGame();
            DataManager.IsPlaying = false;
            //SceneManager.LoadScene();
        }
    }
}
