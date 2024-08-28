async function getCategory() {
  const url = "https://localhost:44349/api/Categories/AllCategories/Category";
  const response = await fetch(url);
  const data = await response.json();
  console.log(data);
  var info = document.getElementById("select");
  data.forEach((element) => {
    info.innerHTML += `<option value="${element.categoryId}">${element.categoryName}</option>`;
  });
}
getCategory();

async function AddProduct() {
  debugger;
  const url1 = "https://localhost:44349/api/Products/AddProducts";
  event.preventDefault();
  var form = document.getElementById("form");
  var formswager = new FormData(form); //(swagger) الموجودة ب ([FromForm]) هذه تكافي ال

  let categoryId = document.getElementById("select").value;

  formswager.append("categoryId", categoryId);

  let response1 = await fetch(url1, {
    method: "POST",
    body: formswager,
  });
  console.log(response1);
  alert("Successfuly Adding Product!");
}
