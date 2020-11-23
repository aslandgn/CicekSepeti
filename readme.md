
kodu indirdiðinizde doðrudan çalýþtýrabilmeniz için migration eklendi.
db için mssql kullanýlmakta.

iþlem yapabilmek için token almanýz gerekli

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
token süresi olarak 1 gün olarak ayarlanmýþtýr.

http://localhost:63177/api/shoppingcart/ => get request
token sahibi kullanýcýya ait alýþveriþ sepeti görüntülenir.
http://localhost:63177/api/shoppingcart/cartId => post request
cartId ShoppingCarts tablosundaki id alaný olmalý
verilen id'ye ait alýþveriþ listesinde satýn alma tamamlanýr.
http://localhost:63177/api/shoppingcart/cartId => delete request
cartId ShoppingCarts tablosundaki id alaný olmalý
verilen id'ye ait alýþveriþ listesi temizlenir.

http://localhost:63177/api/shoppingcartitem/ => post request
body => json
{
    "productId": 1,
    "quantity": 1
}
belirtilen üründen istek atan kullanýcýnýn sepetine ekleme yapar.
stoktan fazla bir istek yapýlýrsa hata döner.
http://localhost:63177/api/shoppingcartitem/ => put request
body => json
{
    "productId": 1,
    "quantity": 2,
    "cartId": 1
}
belirtilen ürünün miktarýný günceller.
stoktan fazla bir istek yapýlýrsa hata dönder.
http://localhost:63177/api/shoppingcartitem/ => delete request
body => json
{
    "productId": 1,
    "quantity": 1,
    "cartId": 1
}
belirtilen ürün alýþveriþ listesinden çýkartýlýr

