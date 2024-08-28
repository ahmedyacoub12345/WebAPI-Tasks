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
      <td>${element.quantity}</td>
      <td><a>Edit</a></td>
    </tr>
    `;
  });
}
ShowCart();
