using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public Vector3 MoveVector { set; get; }
    public Module_MoveStick joystick;

    private Vector3 oldpos = new Vector2();

    public Animator anim;

    void Update()
    {
        MoveVector = PoolInput();
        Move();
    }

    private void Move()
    {
         
        transform.position = transform.position + MoveVector * moveSpeed * Time.deltaTime;
        if (transform.position != oldpos)
        {
            anim.SetBool("move", true);
        }
        else
            anim.SetBool("move", false);
        oldpos = transform.position;
    }

    private Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = joystick.Horizontal();
        dir.y = joystick.Vertical();

        return dir;
    }
}