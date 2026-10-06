using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public MoverComponent mover;

    public AttackAimComponent aim;

    //public AttackComponent attacker;//новый

    public void MovementInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        mover.SetDirection(new Vector2(x, y));
    }

    public void AttackInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            aim.AimZoneWork();
            //attacker.TryAttack();
        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();

        AttackInput();
    }
}
