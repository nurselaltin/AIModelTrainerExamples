using FindSpamEmail.Entity;
using System.Diagnostics.Metrics;


namespace FindSpamEmail.Helpers
{
    public static class Helper
    {
        public static List<Email> GetEmails(string fileName)
        {
            var emails = new List<Email>();
            var filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Dataset");
            var datasetPath = Path.Combine(filePath, fileName);

            emails = File.ReadAllLines(datasetPath)
                           .Skip(1)
                           .Select(c => c.Split(',', 2))
                           .Where(x => x.Length == 2)
                           .Select(email => new Email() { LabelRaw = email[0], Message = email[1] }).ToList();
            
            return emails;
        }
    }
}
