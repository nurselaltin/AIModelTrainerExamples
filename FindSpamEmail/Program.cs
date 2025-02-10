// See https://aka.ms/new-console-template for more information
using FindSpamEmail.Entity;
using Microsoft.ML;

Console.WriteLine("Hello, World!");

#region Eğitim verisini işle
var datasetFilePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Dataset");
var trainData = Path.Combine(datasetFilePath, "spam.csv");

var emails = File.ReadAllLines(trainData)
                .Skip(1)
                .Select(c => c.Split(',', 2))
                .Where(c => c.Length == 2)
                .Select(email => new Email()
                {
                     LabelRaw = email[0],
                     Message = email[1],
                })
                ;

#endregion

#region Pipeline Oluştur

var context = new MLContext();

var trainingData = context.Data.LoadFromEnumerable(emails);

//Veri işleme pipeline oluştur
var pipeline = context.Transforms.Text.FeaturizeText("Features", nameof(Email.Message))
    .Append(context.Transforms.NormalizeMinMax("Features")) // Özellikleri normalleştir
    .Append(context.BinaryClassification.Trainers.LbfgsLogisticRegression(labelColumnName: "Label"));

#endregion

#region Modeli Eğit
var model = pipeline.Fit(trainingData);

#endregion

var predictor = context.Model.CreatePredictionEngine<Email, EmailPrediction>(model);


var testEmail = new Email { Message = "Merhaba" };
var prediction = predictor.Predict(testEmail);

Console.WriteLine($"Mesaj: {testEmail.Message}");
Console.WriteLine($"Spam mı? {(prediction.PredictedLabel ? "Evet" : "Hayır")}");


Console.ReadLine();
