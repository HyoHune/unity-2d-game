using UnityEngine;

public class PedestrianMovement : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float changeDirectionInterval = 2f;

    private Vector3 moveDirection;
    private float timer;

    void Start()
    {
        PickNewDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= changeDirectionInterval)
        {
            PickNewDirection();
            timer = 0f;
        }

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.LookAt(transform.position + moveDirection);
    }

    void PickNewDirection()
    {
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);
        moveDirection = new Vector3(x, 0f, z).normalized;
    }
}

/*
pedestrian의 이동 스크립트
이동 방향을 랜덤하게 선택하여 일정 시간마다 변경
*/