using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private float upForce = 100;
    [SerializeField] private Bird bird;
    [SerializeField] private Bullet bullet;
    [SerializeField] private UnityEvent OnFire;
    [SerializeField] private UnityEvent OnNotification;
    [SerializeField] private UnityEvent OffNotification;
    [SerializeField] private int fireReady = 500; 
    [SerializeField]private int delay = 500;
    private Rigidbody2D rigidBody2d;
    

    //tombol tembak
    public KeyCode fire = KeyCode.A;

    //method spawn bullet
    private void SpawnBullet()
    {
        //pemain menekan tombol A pada keyboad
        if (Input.GetKey(fire))
        {
            if (delay >= fireReady)
            {
                delay = 0;

                //memanggil event OnFire
                OnFire.Invoke();

                //duplikasi bullet
                Bullet newBullet = Instantiate(bullet);

                //mengaktifkan game object
                newBullet.gameObject.SetActive(true);

                //menempatkan new bullet sesuai letak bulletspawner
                newBullet.transform.position = rigidBody2d.position;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Melakukan pengecekan jika belum mati dan klik kiri pada mouse
        if (!bird.IsDead() && Input.GetMouseButtonDown(0))
        {
            //Burung meloncat
            Jump();
        }

        delay++;

        SpawnBullet();

        //Notif Fire Menyala
        if (delay >= fireReady)
        {
            OnNotification.Invoke();
        }

        //Notif Fire mati
        if(delay < fireReady)
        {
            OffNotification.Invoke();
        }
    }

    void Jump()
    {
        //Mengecek rigidbody null atau tidak
        if (rigidBody2d)
        {
            //menghentikan kecepatan burung ketika jatuh
            rigidBody2d.velocity = Vector2.zero;

            //Menambahkan gaya ke arah sumbu y agar burung meloncat
            rigidBody2d.AddForce(new Vector2(0, upForce));
        }
    }
}
