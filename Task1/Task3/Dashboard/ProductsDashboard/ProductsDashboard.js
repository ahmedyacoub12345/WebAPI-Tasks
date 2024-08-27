async function GetOrders() {
  const url = "https://localhost:44349/api/Products/AllProducts/Product";
  const response = await fetch(url);
  const data = await response.json();
  console.log(data);
  var info = document.getElementById("tableBody");
  data.forEach((product) => {
    info.innerHTML += `
    <tr>
      <th scope="row">${product.productId}</th>
      <td>${product.productName}</td>
      <td>${product.description}</td>
      <td>${product.price}</td>
      <td>${product.categoryId}</td>
      <td><img src="/images/${product.productImage}" style="height: 100px; width: 100px;" class="card-img-top" alt="${product.productImage}"></td>
      <td><a href="/EditProduct/EditProduct.html">Edit</a></td>
    </tr>
      `;
  });
}
GetOrders();
