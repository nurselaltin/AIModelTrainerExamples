# AIModelTrainerExamples

## 🚀 Proje Hakkında
**AIModelTrainerExamples**, **ML.NET kullanarak farklı veri setleriyle makine öğrenmesi modelleri eğitmek ve test etmek** amacıyla oluşturulmuş bir **solution**dur. 

İlk konsol projesi olan **FindSpamEmail**, **spam e-mailleri tahmin eden bir model** içerir. Gelecekte farklı veri setleriyle çeşitli makine öğrenmesi senaryoları eklenmesi planlanmaktadır.

---

## 📂 Proje Yapısı
```
AIModelTrainerExamples (Solution)
│-- FindSpamEmail (Spam e-mail tespiti modeli)
│-- [Yeni Modeller] (Gelecekte eklenecek makine öğrenmesi projeleri)
│-- Shared Libraries (Helper metodlar, veri işleme araçları vb.)
```

---

## 🎯 FindSpamEmail - Spam E-Mail Tahmin Modeli
Bu proje, **e-maillerin spam olup olmadığını tahmin etmek için ML.NET kullanarak geliştirilmiştir**.

### **⚙️ Kullanılan Teknolojiler & Yöntemler**
- **ML.NET** kullanarak makine öğrenmesi modeli oluşturuldu.
- **Veri Setleri:**
  - **Eğitim Verisi:** `training.csv`
  - **Test Verisi:** `test.csv`
- **Doğal Dil İşleme:** `FeaturizeText` ile metin vektörleştirildi.
- **Ölçeklendirme:** `NormalizeMinMax` ile veriler 0-1 arasına ölçeklendirildi.
- **Makine Öğrenmesi Modeli:** `LbfgsLogisticRegression` algoritması kullanıldı.
- **Overfitting (Aşırı öğrenme) Engelleme:** `l2Regularization: 0.01f` düzenlileştirme kullanıldı.
- **Model Değerlendirme Metrikleri:**
  - **Accuracy (Doğruluk)**
  - **Precision (Kesinlik)**
  - **Recall (Duyarlılık)**

---

## 🛠️ Kurulum ve Kullanım

### **1. Projeyi Klonlayın**
```bash
git clone https://github.com/kullanici/AIModelTrainerExamples.git
cd AIModelTrainerExamples
```

### **2. Gerekli Bağımlılıkları Yükleyin**
- .NET SDK kurulu olmalıdır.

### **3. İlgili Projeyi Çalıştırın**
```bash
cd FindSpamEmail
dotnet run
```

---

## 📈 Gelecek Geliştirmeler
- ✅ **Farklı Veri Setleri:** Spam filtresinin yanı sıra **farklı problem türlerine yönelik modeller eklenecek**.
- ✅ **Alternatif Algoritmalar:** Lojistik regresyon dışında farklı algoritmalar test edilecek.
- ✅ **Genelleme Yeteneği Artırılmış Modeller:** Daha çeşitli veri setleri kullanılarak modelin performansı geliştirilecek.

---

## 🤝 Katkıda Bulunun
Bu projeye katkıda bulunmak isterseniz, **pull request gönderebilir veya önerilerinizi paylaşabilirsiniz**. 

📧 **İletişim:** [GitHub Profiliniz veya E-mail Adresiniz]  

🚀 **İyi kodlamalar!**

