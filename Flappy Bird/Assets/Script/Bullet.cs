using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

//Menambahkan komponen Rigidbody2D dan BoxCollider2D
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour
{
    // RigidBody 2D bullet
    private Rigidbody2D rigidBody2D;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Komponen pipe
        Pipe pipe = collision.gameObject.GetComponent<Pipe>();

        if (pipe) {           
            //Memusnahkan object ketika bersentuhan
            Destroy(collision.gameObject);     
        }       
    }

    //besar kecepatan bullet
    [SerializeField] private float burst = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //bullet bergerak ke kanan sesuai variabel burst
        transform.Translate(Vector3.right * burst * Time.deltaTime, Space.World);
    }

}
