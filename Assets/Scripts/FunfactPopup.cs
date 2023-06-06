using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FunfactPopup : MonoBehaviour
{
    public GameObject popupPanel;
    public TextMeshProUGUI funfactText;
    public string[] funfacts = new string[]
    {
        "Capybara ramai disebut Masbro dan dijadikan meme di internet.",
        "Capybara adalah hewan pengerat terbesar di dunia.",
        "Capybara berasal dari Amerika Selatan.",
        "Capybara adalah hewan semi-air dan ahli berenang.",
        "Capybara memiliki kaki berselaput, yang membuat mereka efisien di air.",
        "Capybara memiliki masa hidup sekitar 8-10 tahun di alam liar.",
        "Capybara adalah herbivora dan makan rumput dan tanaman air.",
        "Capybara adalah hewan sosial dan hidup dalam kawanan.",
        "Nama ilmiah capybara adalah 'Hydrochoerus hydrochaeris'.",
        "Capybara berkomunikasi menggunakan berbagai suara, klik, dan seruan.",
        "Capybara memiliki kelenjar di hidung yang disebut 'morillo'.",
        "Capybara bisa memiliki berat hingga 68 kilogram.",
        "Capybara memiliki sifat ramah dan jinak.",
        "Capybara sering terlihat berjemur atau berendam di air untuk menjaga kestabilan suhu tubuh.",
        "Capybara memiliki gigi tajam yang digunakan untuk merumput dan bertahan.",
        "Capybara memiliki naluri merawat anak keturunannya dengan baik."
    };

    private void Start()
    {
        popupPanel.SetActive(false);
    }

    public void ShowRandomFunfact()
    {
        if (funfacts.Length == 0)
        {
            Debug.LogWarning("Tidak ada fakta menarik yang tersedia.");
            return;
        }

        int randomIndex = Random.Range(0, funfacts.Length);
        string randomFunfact = funfacts[randomIndex];
        funfactText.text = randomFunfact;
        popupPanel.SetActive(true);
    }

    public void ClosePopup()
    {
        popupPanel.SetActive(false);
    }
}
