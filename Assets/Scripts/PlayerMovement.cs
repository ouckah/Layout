using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Transform _transform;
    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        } 
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        } 
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        } 
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
    }

    private void MoveForward()
    {
        _controller.Move(_transform.forward * speed * Time.deltaTime);
    }

    private void MoveBackward()
    {
        _controller.Move(-_transform.forward * speed * Time.deltaTime);
    }

    private void MoveLeft()
    {
        _controller.Move(-_transform.right * speed * Time.deltaTime);
    }

    private void MoveRight()
    {
        _controller.Move(_transform.right * speed * Time.deltaTime);
    }
}
