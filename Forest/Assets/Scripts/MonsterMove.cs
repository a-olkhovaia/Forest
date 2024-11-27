using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PatrolBehavior : MonoBehaviour
{

    public float speed;
    public int positionOfPatrol;
    public Transform point;
    bool movingRight;

    public float distanceWithPlayer;
    public float stoppingDistance;
    Transform player;

    bool patrol, pursue, goBack = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, столкнулся ли персонаж
        if (other.CompareTag("Player"))
        {
            // Перезапускаем текущую сцену
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < positionOfPatrol && pursue == false)
            patrol = true;
            
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            pursue = false;
        }

        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            pursue = true;
            goBack = false;
            patrol = false;
        }

        if (patrol) Patrol();
        else if (pursue) Pursue();
        else if (goBack) GoBack();
    }

    void Patrol()
    {
        if (transform.position.x > point.position.x + positionOfPatrol) 
            movingRight = false;
        else if (transform.position.x < point.position.x - positionOfPatrol)
            movingRight = true;

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }

    void Pursue()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }

}