using UnityEngine;
using TMPro;

public class SpeedMeter : MonoBehaviour
{
    [Header("参照")]
    public PlayerMove player;              // PlayerMoveスクリプト
    public TextMeshProUGUI speedText;      // 表示するText

    void Update()
    {
        if (player == null || speedText == null)
            return;

        float kmh = player.speed * 3.6f;
        speedText.text = Mathf.RoundToInt(kmh) + " km/h";
    }
}