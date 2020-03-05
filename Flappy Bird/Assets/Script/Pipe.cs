using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Menambahkan komponen Rigidbody2D dan BoxCollider2D
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Pipe : MonoBehaviour
{
    //Global variable
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Komponen bullet
        Bullet shot = collision.gameObject.GetComponent<Bullet>();
    
        if (shot)
        {
            //Memusnahkan object ketika bersentuhan
            Destroy(collision.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Melakukan pengecekan jika burung belum mati
        if (!bird.IsDead())
        {
            //Membuat pipa bergerak kesebelah kiri dengan kecepatan tertentu
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    //Membuat Bird mati ketika bersentuhan dan menjatuhkannya ke ground jika mengenai di atas collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        //Pengecekan Null value
        if (bird)
        {
            //Mendapatkan komponent Collider pada game object
            Collider2D collider = GetComponent<Collider2D>();

            //Melakukan pengecekan Null varibale atau tidak
            if (collider)
            {
                //Menonaktifkan collider
                collider.enabled = false;
            }

            //Burung Mati
            bird.Dead();
        }
    }
}
