using UnityEngine;

public static class InputManager
{
    private static Controls _ctrls;

    private static Vector3 _mousePos;

    private static Camera cam;
    public static Ray GetCameraRay()
    {
        return cam.ScreenPointToRay(_mousePos);
    }

    public static void Init(Player p)
    {
        _ctrls = new();

        cam = Camera.main;

        _ctrls.Permenanet.Enable();

        _ctrls.InGame.Movement.performed += watchWASD =>
        {
            p.SetMovementDirection(watchWASD.ReadValue<Vector3>());
        };
        _ctrls.InGame.Shoot.performed += _ =>
        {
            p.Shoot();
        };
        _ctrls.Permenanet.MousePos.performed += ctx =>
        {
            _mousePos = ctx.ReadValue<Vector2>();
        };
        _ctrls.InGame.WeaponSwitch.performed += weaponWatch =>
        {
            for (int i = 1; i <= 5; i++)
            {
                if (Input.GetKeyDown(i.ToString())) p.WeaponSwap(i);
            }
        };
        _ctrls.InGame.BulletSwitch.performed += bulletType =>
        {
            for(int i = 6; i <= 9; i++)
            {
                if (Input.GetKeyDown(i.ToString())) p.BulletSwap(i - 6);
            }
        };
        _ctrls.InGame.Reload.performed += reload =>
        {
            p.CallReload();
        };
    }

    public static void EnableInGame()
    {
        _ctrls.InGame.Enable();
    }
}
