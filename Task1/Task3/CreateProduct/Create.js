const url = "https://localhost:44349/api/Categories/AddCategory";

var form = document.getElementById("form");

async function AddCategory() {
  var formswager = new FormData(form); //(swagger) الموجودة ب ([FromForm]) هذه تكافي ال
  event.preventDefault();
  let response = await fetch(url, {
    method: "POST",
    body: formswager,
  });
  let data = response;
}
