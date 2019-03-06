using System.Collections;
using System.Collections.Generic;
using Dragon;
using Improbable;
using Improbable.Gdk.GameObjectRepresentation;
using UnityEngine;

public class PlayerInputBehavior : MonoBehaviour
{
    [Require] protected PlayerInput.Requirable.Reader PlayerInputWriter;

    [Require] protected Position.Requirable.Writer PositionWriter;

    [SerializeField] private float _moveSpeed = 5;


    // Start is called before the first frame update
    void OnEnable()
    {
    }


    // Update is called once per frame
    void Update()
    {
        var input = new Vector3(PlayerInputWriter.Data.Horizontal, 0, PlayerInputWriter.Data.Vertical);

        var movement = transform.forward.normalized;
        movement.x *= input.x;
        movement.z = input.z;

        transform.position += transform.rotation * input * _moveSpeed * Time.deltaTime;

    }
}
