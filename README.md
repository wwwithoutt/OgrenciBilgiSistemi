# Öğrenci Bilgi Sistemi | Система Учета Студентов 🎓

WPF (.NET 10) tabanlı, öğrenci verilerini yönetmek için tasarlanmış bir masaüstü uygulamasıdır. Bu proje, veri akışını ve arayüz mantığını "manuel" olarak kontrol etmeyi öğrenmek amacıyla geliştirilmiştir.

Это настольное приложение на базе WPF (.NET 10), предназначенное для управления данными студентов. Проект разработан с целью изучения "ручного" управления потоками данных и логикой интерфейса.

---

## 🇹🇷 Türkçe Açıklama

### 🚀 Özellikler
* **Veri Yönetimi:** Öğrenci adı, soyadı ve numarasının kaydedilmesi.
* **Dinamik Ders Listesi:** Gerçek zamanlı olarak ders ekleme ve silme.
* **Giriş Doğrulama:** Numara alanına sadece rakam girilmesini sağlayan "manuel" filtreleme (`PreviewTextInput`).
* **Kalıcı Veri (JSON):** Verilerin JSON formatında kaydedilmesi. Uygulama açıldığında öğrenci bilgilerini ve derslerini otomatik olarak yükler.
* **Kısayol Desteği:** `D` veya `Delete` tuşları ile listeden hızlı ders silme ve sayaç güncelleme.

### 🛠 Teknolojiler
* **Dil:** C#
* **Platform:** WPF (.NET 10)
* **Veri Formatı:** JSON (System.Text.Json)

---

## 🇷🇺 Описание на Русском

### 🚀 Основные возможности
* **Управление данными:** Сохранение имени, фамилии и номера студента.
* **Динамический список предметов:** Добавление и удаление дисциплин в реальном времени.
* **Валидация ввода:** "Ручной" фильтр для ввода только цифр в поле номера (`PreviewTextInput`).
* **Постоянство данных (JSON):** Сохранение данных в JSON-файл. При старте программа автоматически загружает профиль студента.
* **Горячие клавиши:** Удаление предметов кнопками `D` или `Delete` с мгновенным обновлением счетчика.

### 🛠 Технологический стек
* **Язык:** C#
* **Платформа:** WPF (.NET 10)
* **Формат данных:** JSON (System.Text.Json)

---

## 🧠 Öğrendiğim Kavramlar | Чему я научился

1.  **Pattern Matching:** `is string variable` yapısı ile güvenli veri çekme.
2.  **UI Refresh:** `ItemsSource = null` hilesi ile arayüzü manuel tetikleme.
3.  **Event Handling:** `KeyDown` ve `PreviewTextInput` olayları ile kullanıcı etkileşimi yönetimi.
4.  **Serialization:** Nesneleri JSON formatına dönüştürme ve dosyadan okuma (`System.IO`).

## 📂 Kurulum | Установка

1. Projeyi klonlayın (Clone the repo).
2. Visual Studio 2022 ile `.sln` dosyasını açın.
3. `.NET 10 SDK
