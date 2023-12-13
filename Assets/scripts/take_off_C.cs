using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class take_off_C : MonoBehaviour
{
    // Update is called once per frame
    float timeCounter = -0.5f;
    [SerializeField] private GameObject collisionW;
    [SerializeField] private string SceneTToload;

    void Update()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter > 0)
        {
            float x = Mathf.Cos(timeCounter);
            float y = (Mathf.Sin(timeCounter * 0.0001f) + timeCounter * 3);
            float z = -1;
            transform.position = new Vector3(x - 1.8f, y - 0.4f, z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collisionW)
    {
        SceneManager.LoadScene(SceneTToload);
    }
}

