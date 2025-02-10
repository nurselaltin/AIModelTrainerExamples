using FindSpamEmail.Entity;
using System.Diagnostics.Metrics;


namespace FindSpamEmail.Helpers
{
    public static class Helper
    {
        public static List<Email> CleanEmailData(string[] data)
        {
            var emails = new List<Email>();
            for (int i = 1; i < data.Length; i++)
            {
                var parts = data[i].Split(',', 2); // İlk virgülde ayır, mesajda virgüller olabilir. *** 2 değeri en fazla 2 parçaya bölebilirsin demek.
                if (parts.Length < 2) continue; // Boş satırları veya hatalı satırları atla

                string label = parts[0].Trim().ToLower(); // "ham" veya "spam"
                string message = parts[1].Trim(); // Mesaj içeriği

                if (label == "ham" || label == "spam")
                {
                    emails.Add(new Email { LabelRaw = label, Message = message });
                }
            }
            return emails;
        }
    }
}
