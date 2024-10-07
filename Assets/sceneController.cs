using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

public class sceneController : MonoBehaviour
{

    [SerializeField]
    private InputActionReference _activateAction;
    [SerializeField]
    private GameObject _grabCube;
    // Start is called before the first frame update
    void Start()
    {
        _activateAction.action.performed += onActivateAction;
    }

    private void onActivateAction(InputAction.CallbackContext obj)
    {
        spawnCube();
    }

    private void spawnCube()
    {
        Instantiate(_grabCube, new Vector3(0, 0, 2), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
