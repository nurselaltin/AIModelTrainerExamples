using Microsoft.ML.Data;

namespace FindSpamEmail.Entity
{
    public  class Email
    {
        [LoadColumn(0)]
        public string LabelRaw { get; set; }  // "spam" veya "ham" olarak okunur

        [LoadColumn(1)]
        public string Message { get; set; }

        public bool Label => LabelRaw == "spam"; // "spam" ise true, değilse false
    }

    public class EmailPrediction
    {   
        [ColumnName("PredictedLabel")]
        public bool PredictedLabel { get; set; }
    }
}
