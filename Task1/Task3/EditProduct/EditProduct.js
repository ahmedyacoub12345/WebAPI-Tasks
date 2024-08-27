debugger;
let N = localStorage.getItem("productId");
const url = `https://localhost:44349/api/Products/UpdateProduct/${N}`;
var data = document.getElementById("form");
async function EditProduct() {
  event.preventDefault();
  var formswager = new FormData(form);
  let response = await fetch(url, {
    method: "PUT",
    body: formswager,
  });
  let result = response;
}
