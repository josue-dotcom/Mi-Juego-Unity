using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static int SCORF = 0;


    public float thrusForce = 5f; 
    public float rotationSpeed = 10f;

    public GameObject gun, bulletPrefab;

    private Rigidbody _rigid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float rotation = Input.GetAxis("Rotate")*Time.deltaTime;
        float thrust = Input.GetAxis("Thrust")*Time.deltaTime;

        Vector3 thrusDirection = transform.right;

        _rigid.AddForce(thrusDirection * thrust * thrusForce); 

        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);

        if(Input.GetKeyDown(KeyCode.Space)){
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            Bullet balaScript = bullet.GetComponent<Bullet>();
            balaScript.targetVector = transform.right;
        
        }
    }
}
