using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionWaypoint : MonoBehaviour
{
    public List<Image> imgs; // Daftar untuk menyimpan beberapa gambar
    public List<Transform> targets; // Daftar untuk menyimpan beberapa target
    public List<TextMeshProUGUI> meters; // Daftar untuk menyimpan beberapa teks jarak

    private void Update()
    {
        if (targets.Count == 0 || imgs.Count == 0 || meters.Count == 0) return; // Pastikan ada target, gambar, dan meter yang ditentukan

        // Menghitung posisi waypoint
        float minX = imgs[0].GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = imgs[0].GetPixelAdjustedRect().height / 2; // Menggunakan height untuk minY
        float maxY = Screen.height - minY;

        for (int i = 0; i < targets.Count; i++)
        {
            Transform target = targets[i];
            Image img = imgs[i];
            TextMeshProUGUI meter = meters[i];

            // Menemukan posisi target
            Vector2 pos = Camera.main.WorldToScreenPoint(target.position);

            // Memeriksa apakah target berada di belakang waypoint
            if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
            {
                if (pos.x < Screen.width / 2)
                {
                    pos.x = maxX; // Pindahkan ke sisi kanan
                }
                else
                {
                    pos.x = minX; // Pindahkan ke sisi kiri
                }
            }

            // Mengatur posisi agar tetap dalam batas layar
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            img.transform.position = pos;

            // Mengupdate teks jarak menggunakan TextMeshPro
            float distance = Vector3.Distance(target.position, transform.position);
            meter.text = distance.ToString("0") + " m";
        }
    }
}
