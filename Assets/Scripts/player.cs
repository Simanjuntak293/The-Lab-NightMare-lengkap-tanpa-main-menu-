using UnityEngine;

public class DeteksiWASD : MonoBehaviour
{
    [Header("Pengaturan Gerak")]
    public float kecepatan = 5f;

    [Header("Pengaturan Mouse")]
    public float sensitivitasMouse = 300f;
    
    // Referensi ke kamera utama (opsional jika script dipasang di Player, 
    // tapi kamera diletakkan di dalam objek Player sebagai anak/child)
    private float rotasiX = 0f;

    void Start()
    {
        // Mengunci kursor di tengah layar dan menyembunyikannya agar masuk ke game
        AturKursor(true);
    }

    void Update()
    {
        // ==================== MENGATUR KURSOR MOUSE ====================
        // Jika Anda mengklik layar game, kursor akan otomatis terkunci kembali ke dalam game
        if (Input.GetMouseButtonDown(0))
        {
            AturKursor(true);
        }

        // Tekan ESC untuk memunculkan kursor kembali (jika ingin keluar sementara)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AturKursor(false);
        }

        // ==================== BAGIAN GERAK (WASD) ====================
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Tombol W ditekan (Maju)");
            transform.Translate(Vector3.forward * kecepatan * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Tombol S ditekan (Mundur)");
            transform.Translate(Vector3.back * kecepatan * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Tombol A ditekan (Kiri)");
            transform.Translate(Vector3.left * kecepatan * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Tombol D ditekan (Kanan)");
            transform.Translate(Vector3.right * kecepatan * Time.deltaTime);
        }

        // ==================== BAGIAN MOUSE (PANDANGAN) ====================
        float mouseX = Input.GetAxis("Mouse X") * sensitivitasMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivitasMouse * Time.deltaTime;

        // Memutar badan player ke kiri/kanan berdasarkan gerakan horizontal mouse
        transform.Rotate(Vector3.up * mouseX);
    }

    // Fungsi pembantu untuk mengunci/membuka kursor
    void AturKursor(bool kunci)
    {
        if (kunci)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}