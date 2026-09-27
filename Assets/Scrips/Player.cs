using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static int SCORF = 0;


    public float thrusForce = 5f; 
    public float rotationSpeed = 10f;

    public float xBorderLimit = 9f;
    public float yBorderLimit = 5f;

    public GameObject gun, bulletPrefab;

    private Rigidbody _rigid;

    public static int SCORE = 0;

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
        CheckBorders();
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Enemy"){
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void CheckBorders()
    {
        Vector3 newPos = transform.position;

        if (newPos.x > xBorderLimit)
        {
            newPos.x = -xBorderLimit;
        }
        else if (newPos.x < -xBorderLimit)
        {
            newPos.x = xBorderLimit;
        }

        if (newPos.y > yBorderLimit)
        {
            newPos.y = -yBorderLimit;
        }
        else if (newPos.y < -yBorderLimit)
        {
            newPos.y = yBorderLimit;
        }

        transform.position = newPos;
    }
}
