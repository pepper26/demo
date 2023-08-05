using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    public Transform Player;
    public Transform ShootingPoint;
    public GameObject bullet;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);

        float x = Mathf.Clamp(transform.position.x, -12f, 12f);
        float y = Mathf.Clamp(transform.position.y, -6.5f, 6.5f);
        transform.position = new Vector3(x, y, transform.position.z);

        if (Input.GetKey(KeyCode.D))
        {
           Player.transform.rotation = Quaternion.Euler(0f, -40f, 0f);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Player.transform.rotation = Quaternion.Euler(0f, 40f, 0f);
        }
        else
        {
            Player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }

    private void Fire()
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = ShootingPoint.position;
            bullet.SetActive(true);
        }
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.1f);
        Fire();
        StartCoroutine(Shoot());
    }

}
