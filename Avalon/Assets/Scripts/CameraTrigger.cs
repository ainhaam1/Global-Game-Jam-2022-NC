using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraTrigger : MonoBehaviour
{
    public CinemachineVirtualCamera oldCamera;
    public CinemachineVirtualCamera cameraToSwitch;
    public GameObject enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CameraSwitcher.Register(oldCamera);
            CameraSwitcher.Register(cameraToSwitch);

            if (CameraSwitcher.ActiveCamera != cameraToSwitch)
            {
                Debug.Log("camera switch here");
                CameraSwitcher.SwitchCamera(cameraToSwitch);
                CameraSwitcher.Unregister(oldCamera);
            }

            enemy.GetComponent<enemyStateMachine>().active = true;
        }
    }
}
