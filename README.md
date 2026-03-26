# 💧 Water Rush

![Durum](https://img.shields.io/badge/Durum-Aktif_Geliştirme_Aşamasında-orange?style=flat-square)
![Motor](https://img.shields.io/badge/Oyun_Motoru-Unity_3D-black?style=flat-square&logo=unity)
![Modelleme](https://img.shields.io/badge/Modelleme-Blender-orange?style=flat-square&logo=blender)

**Water Rush**, Unity 3D ile geliştirilen, eğlenceli ve dinamik bir hiper-casual (hyper-casual) mobil koşu (runner) oyunudur. 

Oyuncunun temel amacı; kafasında dengede tuttuğu devasa bir bardak dolusu suyu, zorlu engellerden dökmeden geçirerek bitiş çizgisine kadar taşımak ve kalan suyla kurumuş bir fidanı yeniden yeşertmektir. Okunabilirliği yüksek, absürt ve eğlenceli görsel tarzıyla tam bir mobil oyun deneyimi sunmayı hedefler.

👨‍💻 **Geliştirici:** Metin

---

## 📋 Proje Durumu ve Yol Haritası (Roadmap)

Proje şu anda **aktif geliştirme (Work in Progress)** aşamasındadır. Temel mühendislik mimarisi ve çekirdek oyun döngüsü tamamlanmış olup, görsel cila ve meta oyun sistemleri üzerinde çalışılmaktadır.

### ✅ Tamamlanan Özellikler (Yapılanlar)

**Temel Mekanikler & Sistemler**
- [x] Pürüzsüz sağa/sola kayma (Swerve) ve ileri koşu kontrolleri.
- [x] Engellere çarpma anında hız düşüşü ve sendeleme (Stagger) tepkileri.
- [x] `PlayerPrefs` tabanlı kalıcı kayıt sistemi (Seviye ilerlemesi ve toplanan yıldızların kaydedilmesi).

**Görsel & Fiziksel Entegrasyonlar**
- [x] **Dinamik Su Fiziği:** Su miktarının sadece UI barında değil, bardağın içinde fiziksel olarak azalması (Sahte Pivot hilesi ile pürüzsüz düşüş).
- [x] **Özel 3D Model Entegrasyonu:** Blender'da sıfırdan modellenen özel bardağın eksen düzeltmeleri yapılarak oyuna aktarılması.
- [x] **Hiper-casual Estetik:** Bardağın karakterin kafasına (Head Bone Socketing) eğlenceli ve abartılı bir "taç" şeklinde sabitlenmesi.
- [x] **Animasyon Mimarisi:** Mixamo, Animator Controller ve 1D Blend Tree kullanılarak karakterin "Nefes Alma" ve "Koşma" durumları arasında pürüzsüz geçişlerin sağlanması.

### 🚀 Geliştirme Aşamasındakiler (Yapılmayanlar / To-Do)

**Oyunun Zirve Noktası (Climax) & Ödül**
- [ ] Bitiş çizgisinde (Finish Line) kalan suyu kurumuş fidana dökme animasyonu.
- [ ] Suyun dökülmesiyle birlikte ağacın aniden büyüyüp yeşerme sekansı.

**Meta Oyun & Ekonomi**
- [ ] Ana menüye entegre edilecek Mağaza (Shop) sistemi.
- [ ] Toplanan yıldızlarla satın alınabilecek yeni Blender tasarımları (Termos, Kase, Geniş Bardak vb.).

**Görsel ve İşitsel Cila (Juice & Polish)**
- [ ] Çarpışma anlarında su sıçrama efektleri (Particle System).
- [ ] Bölüm sonu kutlama konfetileri.
- [ ] Arka plan müziği, UI tıklama sesleri ve tatmin edici su şıpırtısı (SFX) entegrasyonu.

**Bölüm Tasarımı (Level Design)**
- [ ] Farklı zorluk eğrilerine ve giderek karmaşıklaşan engel dizilimlerine sahip yeni bölümlerin (Sahneler/Prefablar) üretilmesi.

---

## 🛠️ Kullanılan Teknolojiler ve Araçlar
* **Oyun Motoru:** Unity 3D (C#)
* **3D Modelleme:** Blender
* **Animasyonlar:** Mixamo & Unity Animator (Blend Trees)
* **Sürüm Kontrolü:** Git & GitHub
