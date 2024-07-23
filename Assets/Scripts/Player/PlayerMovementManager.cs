using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : CharacterMovementManager
{
    Player player;

    public override void Start()
    {
        base.Start();

        player = GetComponent<Player>();
    }

    public override void GetMovementInput()
    {
        horizontalInput = player.horizontalInput;
        verticalInput = player.verticalInput;
    }

    public override void GetMouseInput()
    {
        xAxisValue = player.lookInput.x * player.lookSensitivity;
        yAxisValue = player.lookInput.y * player.lookSensitivity;

        yAxisValue = Mathf.Clamp(yAxisValue, -77, 77);
    }
}
