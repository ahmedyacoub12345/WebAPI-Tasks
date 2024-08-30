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

let N = localStorage.getItem("productId");
let URL = `https://localhost:44349/api/Products/UpdateProduct/${N}`;
async function EditProduct() {
  debugger;
  event.preventDefault();
  var form = document.getElementById("form");
  var formswager = new FormData(form); //(swagger) الموجودة ب ([FromForm]) هذه تكافي ال

  let categoryId = document.getElementById("select").value;

  formswager.append("categoryId", categoryId);

  let response = await fetch(URL, {
    method: "PUT",
    body: formswager,
  });
  alert("Successfuly Editing Product!");
}
