# UdemyJWTApp
<h2><a href="https://sfatektas.bsite.net/api/Products"> To test live </a> !Not İşlem yapabilmek için authentice olmanız gerekli</h2>

<h3>**User Rolü sadece GET işlemleri yapabilir , POST,DELETE ve PUT işlemi yapabilmek için admin olarak giriş yapmalısınız</h3>
<b>Web API &amp; JWT Token &amp; CQRS &amp; Cookie</b>

<p>Jwt Token , CQRS ve Cookie yapıları kullanılarak basit olarak CRUD işlemlerinin yapıldığı bir proje</p>

<h3>Endpointler</h3>
<h4>Auth</h4>
Post Methods;
<p>api/Auth/Register</p>
json format;
{
"Name" = "admin",
"Surname" = "admin",
"PhoneNumber" = 298739823798,
"Password" = "admin",
"AppRoleId" = 1
}
<p>api/Auth/SignIn</p>
json format 
{
  "Username" = "admin"
  "Password" = "admin"
}
{
  "Username" = "user"
  "Password" = "user"
}

<h4>Products</h4>
<b>Get Methods</b>

<p>api/Products</p>
<p>api/Products/id  (ve Delete Method)</p>

<b>Post Methods</b>
<p>Create</p>
json format;
{
  "description": null,
  "stock": 0,
  "price": 0.0,
  "categoryId": 0
}
<p>Update</p>
json format;
{
  "id": 0,
  "description": null,
  "stock": 0,
  "price": 0.0,
  "categoryId": 0
}

<h4>Category</h4>

<b>Get Methods</b>

<p>api/Categories</p>
<p>api/Categories/id (ve Delete Method)</p>
<p>api/Categories/id/Products</p>

<b> Post Methods<b>
<p>Create</p>
{
"Description" : "string"
}
<p></p>

<p>Upload</p>
{
  "id": 0,
  "description": null
}



