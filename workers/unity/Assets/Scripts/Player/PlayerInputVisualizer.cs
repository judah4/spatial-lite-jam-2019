using System.Collections;
using System.Collections.Generic;
using Dragon;
using Improbable.Gdk.GameObjectRepresentation;
using UnityEngine;

public class PlayerInputVisualizer : MonoBehaviour
{

    [Require] protected PlayerInput.Requirable.Writer PlayerInputWriter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var inputY = Input.GetAxis("Vertical");
        var inputX = Input.GetAxis("Horizontal");

        PlayerInputWriter.Send(new PlayerInput.Update() {Horizontal = inputX, Vertical = inputY});
    }
}
