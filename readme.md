
kodu indirdi�inizde do�rudan �al��t�rabilmeniz i�in migration eklendi.
db i�in mssql kullan�lmakta.

i�lem yapabilmek i�in token alman�z gerekli

http://localhost:63177/api/user/login => post request
body => json
{
    "name": "test1",
    "password": "test1"
}
result => 
{
    "id": 1,
    "name": "test1",
    "password": "",
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwibmJmIjoxNjA2MTM5MjM1LCJleHAiOjE2MDYyMjU2MzUsImlhdCI6MTYwNjEzOTIzNX0.U2lyGcAUUFX9qYLq5GanSh2K0Ow-gdA-3coWEnMsjCU"
}
token s�resi olarak 1 g�n olarak ayarlanm��t�r.

http://localhost:63177/api/shoppingcart/ => get request
token sahibi kullan�c�ya ait al��veri� sepeti g�r�nt�lenir.
http://localhost:63177/api/shoppingcart/cartId => post request
cartId ShoppingCarts tablosundaki id alan� olmal�
verilen id'ye ait al��veri� listesinde sat�n alma tamamlan�r.
http://localhost:63177/api/shoppingcart/cartId => delete request
cartId ShoppingCarts tablosundaki id alan� olmal�
verilen id'ye ait al��veri� listesi temizlenir.

http://localhost:63177/api/shoppingcartitem/ => post request
body => json
{
    "productId": 1,
    "quantity": 1
}
belirtilen �r�nden istek atan kullan�c�n�n sepetine ekleme yapar.
stoktan fazla bir istek yap�l�rsa hata d�ner.
http://localhost:63177/api/shoppingcartitem/ => put request
body => json
{
    "productId": 1,
    "quantity": 2,
    "cartId": 1
}
belirtilen �r�n�n miktar�n� g�nceller.
stoktan fazla bir istek yap�l�rsa hata d�nder.
http://localhost:63177/api/shoppingcartitem/ => delete request
body => json
{
    "productId": 1,
    "quantity": 1,
    "cartId": 1
}
belirtilen �r�n al��veri� listesinden ��kart�l�r

