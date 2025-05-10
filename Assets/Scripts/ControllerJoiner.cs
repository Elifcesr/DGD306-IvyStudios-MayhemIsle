using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ControllerJoiner : MonoBehaviour
{
    private PlayerInputManager _inputManager;

    public Transform spawnPoint;

    public GameObject playerPrefab;

    private void Awake()
    {

        _inputManager = GetComponent<PlayerInputManager>();

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

    }
}