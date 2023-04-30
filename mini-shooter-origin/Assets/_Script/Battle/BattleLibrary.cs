using UnityEngine;

static class BattleLibrary
{
    //Enemy
    /// <summary>
    /// 取得玩家的位置
    /// </summary>
    public static Vector3 GetPlayerPosition(this MonoBehaviour behaviour)
    {
        if (BattleLab.instance.player != null)
        {
            return BattleLab.instance.player.transform.position;
        }
        else return Vector3.zero;
    }

    /// <summary>
    /// 取得玩家的方向
    /// </summary>
    public static Vector3 GetPlayerDirection(this MonoBehaviour behaviour)
    {
        return Vector3.Normalize(behaviour.GetPlayerPosition() - behaviour.transform.position);
    }

    /// <summary>
    /// 取得玩家的距離
    /// </summary>
    /// <param name="behaviour"></param>
    /// <returns></returns>
    public static float GetPlayerDistance(this MonoBehaviour behaviour)
    {
        Vector3 playerPos = behaviour.GetPlayerPosition();
        return Vector3.Distance(behaviour.transform.position, playerPos);
    }

    //Player
    /// <summary>
    /// 取得鍵盤輸入的方向 (WSAD, 上下左右)
    /// </summary>
    /// <param name="behaviour"></param>
    /// <returns></returns>
    public static Vector3 GetInputDirection(this MonoBehaviour behaviour)
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        return new Vector3(inputX, inputY).normalized;
    }

    /// <summary>
    /// 取得滑鼠在世界的位置
    /// </summary>
    /// <param name="behaviour"></param>
    /// <returns></returns>
    public static Vector3 GetMouseInWorld(this MonoBehaviour behaviour)
    {
        Vector3 mouseInWrold = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseInWrold.z = 0;

        return mouseInWrold;
    }

    /// <summary>
    /// 取得滑鼠的相對方向
    /// </summary>
    /// <param name="behaviour"></param>
    /// <returns></returns>
    public static Vector3 GetMouseDirection(this MonoBehaviour behaviour)
    {
        Vector3 mouseInWorld = behaviour.GetMouseInWorld();
        Vector3 position = behaviour.transform.position;

        return Vector3.Normalize(mouseInWorld - position);
    }

    //Movement
    /// <summary>
    /// 朝只指定方向移動
    /// </summary>
    public static void MoveDirection(this MonoBehaviour behaviour, Vector3 direction, float speed)
    {
        Vector3 movement = direction * speed;
        behaviour.transform.position += movement * Time.deltaTime;
    }

    /// <summary>
    /// 朝只指定位置移動
    /// </summary>
    public static void MovePosition(this MonoBehaviour behaviour, Vector3 position, float speed)
    {
        Vector3 direction = Vector3.Normalize(position - behaviour.transform.position);
        behaviour.MoveDirection(direction, speed);
    }

    /// <summary>
    /// 轉向指定方向
    /// </summary>
    /// <param name="behaviour"></param>
    /// <param name="direction"></param>
    public static void LookDirection(this MonoBehaviour behaviour, Vector3 direction)
    {
        behaviour.transform.up = direction;
    }
    /// <summary>
    /// 轉向指定位置
    /// </summary>
    /// <param name="behaviour"></param>
    /// <param name="position"></param>
    public static void LookPosition(this MonoBehaviour behaviour, Vector3 position)
    {
        Vector3 direction = position - behaviour.transform.position;
        behaviour.transform.up = direction;
    }

    //Attack
    /// <summary>
    /// 朝指定方向發射子彈
    /// </summary>
    public static void ShootDirection(this MonoBehaviour behaviour, Projectile projectile, Vector2 direction)
    {
        Vector2 firePoint = (Vector2)behaviour.transform.position + direction * 0.5f;
        Quaternion projetileRotate = Quaternion.LookRotation(Vector3.forward, direction);

        MonoBehaviour.Instantiate(projectile, firePoint, projetileRotate);
    }
}