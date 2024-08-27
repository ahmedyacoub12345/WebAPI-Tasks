let N = localStorage.getItem("categoryId");
const url = `https://localhost:44349/api/Categories/UpdateCategory/$${N}`;
var data = document.getElementById("form");

async function Edit() {
  event.preventDefault();
  var formswager = new FormData(form);
  let response = await fetch(url, {
    method: "PUT",
    body: formswager,
  });
  let result = response;
}
