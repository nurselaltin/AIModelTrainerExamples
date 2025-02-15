using FindSpamEmail.Entity;
using FindSpamEmail.Helpers;
using Microsoft.ML;

Console.WriteLine("Hello, World!");

#region Eğitim verisini işle
var emails = Helper.GetEmails("training.csv");
#endregion

#region Pipeline Oluştur

var context = new MLContext();

var trainingData = context.Data.LoadFromEnumerable(emails);

//Veri işleme pipeline oluştur
var pipeline = context.Transforms.Text.FeaturizeText("Features", nameof(Email.Message))
    .Append(context.Transforms.NormalizeMinMax("Features")) // Özellikleri normalleştir
    .Append(context.BinaryClassification.Trainers.LbfgsLogisticRegression(labelColumnName: "Label", l2Regularization : 0.01f));

#endregion

#region Modeli Eğit
var model = pipeline.Fit(trainingData);

#endregion

#region Modeli test et

var testDataset = Helper.GetEmails("test.csv");
var testData = context.Data.LoadFromEnumerable(testDataset);


var predictions = model.Transform(testData);
var predictionResults = context.Data.CreateEnumerable<EmailPrediction>(predictions, reuseRowObject: false).ToList();

for (int i = 0; i < testDataset.Count(); i++)
{
    Console.WriteLine($"Mesaj: {testDataset[i].Message}");
    Console.WriteLine($"Tahmin: {(predictionResults[i].PredictedLabel ? "Spam" : "Ham")}");
    Console.WriteLine("-------------------------");
    testDataset[i].LabelRaw = (predictionResults[i].PredictedLabel ? "Spam" : "Ham");
}
#endregion

#region Modeli Ölç
var testDataset2 = Helper.GetEmails("test.csv");

testData = context.Data.LoadFromEnumerable(testDataset2);

var metrics = context.BinaryClassification.Evaluate(model.Transform(testData), labelColumnName: "Label");
Console.WriteLine($"Accuracy: {metrics.Accuracy}");
Console.WriteLine($"Precision: {metrics.PositivePrecision}");
Console.WriteLine($"Recall: {metrics.PositiveRecall}");
#endregion

Console.ReadLine();
