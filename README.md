


https://github.com/user-attachments/assets/9b04e732-816a-478e-a8ee-6471feb2cd34




# <img width="1185" alt="Ekran Resmi 2024-12-06 18 30 42" src="https://github.com/user-attachments/assets/9e88b0f4-d78c-40aa-aaa7-d804a1c090bf">

Map Data holder scriptinden istediğimiz kadar tile objesini oluşturabilmekteyiz ve oluştururken boş mu yahut herhangi bir item tuttuğunu ayarlayabilmekteyiz.

-----------------------------------------

<img width="835" alt="Ekran Resmi 2024-12-06 18 37 52" src="https://github.com/user-attachments/assets/73d106b9-eb3a-4aa6-8fdb-d76dc3c7a60d">

Oyunucunun datasını ve oluşturduğumuz tile ların datasını tutan 2 adet JSON dosyası oluşturup oyun başlangıcında eğer daha önce kayıtlı olan bir data varsa onu çekiyoruz eğer yoksa otomatik olarak oluşturulan objeleri dataya kaydedip her açıldığında datadan verileri çekerek sahneye yüklüyoruz.

Player Datası:
-İtemler
-Bulunduğu pozisyonu

Map Data:
-Tile obje sayısını,
-Ve tile objesinde bulunan item larını sayısıyla birlikte tutmakta.

-----------------------------------------------

<img width="270" alt="Ekran Resmi 2024-12-06 18 37 04" src="https://github.com/user-attachments/assets/85dfe79c-7598-499b-9b0e-3f876fd9a582">

Inputfield alanlarına 1 - 6 arasında gelmesini istediğimiz zar değerlerini girip yanlarındaki buttonlara basarak verileri kaydediyoruz.

________________________________________________

<img width="542" alt="Ekran Resmi 2024-12-06 18 37 31" src="https://github.com/user-attachments/assets/cbcf15f3-aec1-4440-b5ea-9732d228e89a">
<img width="458" alt="Ekran Resmi 2024-12-06 18 37 17" src="https://github.com/user-attachments/assets/765e8c45-d463-4680-a6ba-2afd8db225bd">

Ardından ROLL DICE diyerek zarın hareketinin tamamlanmasını bekliyoruz.Zar hareketi tamamen fizik ile oluşturulmuştur.
-----------------------------------------------------------------------


<img width="162" alt="Ekran Resmi 2024-12-06 18 37 11" src="https://github.com/user-attachments/assets/528ba567-488b-456c-99ad-e4d518a0328d">

Sağ üst köşede oyuncunun topladığı objelerin datalarını görebiliriz.

