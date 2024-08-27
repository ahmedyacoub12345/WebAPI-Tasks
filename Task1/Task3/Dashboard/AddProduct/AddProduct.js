async function getCategory() {
  const url = "https://localhost:44349/api/Categories/AllCategories/Category";
  const response = await fetch(url);
  const data = await response.json();
  console.log(data);
  var info = document.getElementById("option");
  data.forEach((element) => {
    info.innerHTML += `<option value="${element.categoryId}">${element.categoryName}</option>`;
  });
}
getCategory();

async function AddProduct() {
  const URL = "https://localhost:44349/api/Products/AllProducts/Product";
  var form = document.getElementById("form");
  var formswager = new FormData(form); //(swagger) الموجودة ب ([FromForm]) هذه تكافي ال
  event.preventDefault();
  let response = await fetch(URL, {
    method: "POST",
    body: formswager,
  });
  let data = response;
  alert("Successfuly Adding Product!");
}
AddProduct();
