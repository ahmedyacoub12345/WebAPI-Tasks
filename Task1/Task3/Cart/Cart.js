async function ShowCart() {
  let url = "https://localhost:44349/api/cartItem/GetCarts";
  let table = document.getElementById("tableBody");
  const response = await fetch(url);
  const data = await response.json();
  data.forEach((element) => {
    table.innerHTML += `
    <tr>
      <th scope="row">${element.cartId}</th>
      <td>${element.productRequest.productName}</td>
      <td><input type="number" value="${element.quantity}" id="quantity${element.cartItemId}"></td>
      <td>
        <button type="button" class="btn btn-primary" onclick="EditItem(${element.cartItemId})">Edit</button>
        <button type="button" class="btn btn-danger" onclick="DeleteItem(${element.cartItemId})">Delete</button>
      </td>
    </tr>
    `;
  });
}
ShowCart();

async function EditItem(id) {
  debugger;
  event.preventDefault();
  var quantity = document.getElementById(`quantity${id}`);
  var data = {
    quantity: quantity.value,
  };
  var url = `https://localhost:44349/api/Quantities/EditQuantity/${id}`;
  var requist = await fetch(url, {
    method: "PUT",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  });
}

async function DeleteItem(data) {
  debugger;
  event.preventDefault();
  var url = `https://localhost:44349/api/Quantities/DeleteItem/${data}`;
  var requist = await fetch(url, {
    method: "DELETE",
    headers: {
      "Content-Type": "application/json",
    },
  });
}
