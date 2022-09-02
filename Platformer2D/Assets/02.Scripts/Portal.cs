using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private string _sceneNameToMove;


    private void Start()
    {
        StartCoroutine(E_CheckScenePutPlayerHere());
    }

    IEnumerator E_CheckScenePutPlayerHere()
    {
        yield return new WaitUntil(() => SceneInformation.isSceneLoaded);
        if (SceneInformation.oldSceneName == _sceneNameToMove)
            Player.instance.transform.position = transform.position;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (1 << collision.gameObject.layer == LayerMask.NameToLayer("Player") &&
                Input.GetKeyDown(KeyCode.UpArrow) ) 
            {
                SceneMover.MoveTo(_sceneNameToMove);
            }
        }
    }
}
