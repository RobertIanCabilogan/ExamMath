using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    public PlayerMovement player;

    public TMP_Text speedTXT;
    public TMP_Text sizeTXT;
    public TMP_Text rotationTXT;
    public TMP_Text distanceTXT;

    private Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedTXT.text = "Speed: " + player.CurrentSpeed.ToString("F1");

        Vector3 scale = player.transform.localScale;

        sizeTXT.text = "Scale X: " + scale.x.ToString("F2") + " Y: " + scale.y.ToString("F2") + " Z: " + scale.z.ToString("F2");

        Vector3 rotation = player.transform.eulerAngles;

        rotationTXT.text = "Rotation: X: " + rotation.x.ToString("F2") + " Y: " + rotation.y.ToString("F2") + " Z: " + rotation.z.ToString("F2");

        if (player.IsBoostActive)
        {
            speedTXT.text += " (Boost!)";
        }

        float distance = Vector3.Distance(startPos, player.transform.position);

        distanceTXT.text = "Distance: " + distance.ToString("F2") + " m";
    }
}
