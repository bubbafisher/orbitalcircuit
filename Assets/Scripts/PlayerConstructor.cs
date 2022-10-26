using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConstructor : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab, cameraPrefab;
    [SerializeField] private InputActionAsset controls;

    public GameObject createPlayer()
    {
        //Add the ship model and size properly
        GameObject player = Instantiate(playerPrefab);
        player.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
        //Add components
        player.AddComponent<Rigidbody>().useGravity = false;
        player.GetComponent<MeshCollider>().enabled = false;
        player.AddComponent<PlayerInput>().actions = controls;
        player.AddComponent<Player>();
        //Add Camera and make it child of model
        GameObject camera = Instantiate(cameraPrefab);
        camera.transform.parent = player.transform;
        //Move camera to proper position
        camera.transform.localPosition = new Vector3(0, 5.253f, -26.398f);
        camera.transform.eulerAngles = new Vector3(camera.transform.eulerAngles.x - 10, 0, 0);

        return player;
    }
}
