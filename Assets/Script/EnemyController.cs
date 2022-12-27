using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Comonent")]
    [SerializeField] private GameObject _bombObj;
    [SerializeField] private Transform _muzzle;

    [Header("Varibles")]
    [SerializeField] private float _bombDelayInSec = 1f;
    [SerializeField] private float _bombSpeed;

    [SerializeField]
    private PlayerController _player;
    private Bomb _bomb;

    private bool _isShootingActive = false;

    private void Awake()
    {
        GameObject[] sceneObject;
        sceneObject = FindObjectsOfType(typeof(GameObject)) as GameObject[];

        foreach (var item in sceneObject)
        {
            PlayerController currentPC = item.GetComponent<PlayerController>();

            if (currentPC != null)
            {
                _player = currentPC;
                break;
            }
        }

        _bomb = _bombObj.GetComponent<Bomb>();
    }

    void Update()
    {
        Vector3 lookingDir = _player.transform.position - transform.position;
        lookingDir.y = 0;
        transform.forward = lookingDir;

        if (!_isShootingActive)
            StartCoroutine(ThrowBomb());
    }

    private IEnumerator ThrowBomb()
    {
        _isShootingActive = true;

        while (true)
        {
            yield return new WaitForSeconds(_bombDelayInSec);

            Instantiate(_bombObj).GetComponent<Bomb>().Setup(_player,_muzzle.position, transform.forward, _bombSpeed);
        }
    }
}
