async function getCategory() {
  var N = localStorage.getItem("productId");
  const url = `https://localhost:44349/api/Products/Product/${N}`;
  const response = await fetch(url);
  const data = await response.json();
  console.log(data);
  var info = document.getElementById("Products");
  data.forEach((product) => {
    info.innerHTML += `<div class="card" style="width: 18rem;">
  <img src="../images/${product.productImage}" class="card-img-top" alt="..." style="height: 18rem;">
  
  <div class="card-body">
  <h5 class="card-title"><strong>Name : </strong><br>${product.productName}</h5>
  <p class="card-text"><strong>Description :</strong> <br>${product.description}</p>
  <p ><strong>Price:</strong> <br>${product.price} $</p>
      <a href="../EditProduct/EditProduct.html" onclick="setlocal(${product.productId})" class="btn btn-primary">Edit</a>
      <form id="addToCart">
                        <div>
                            <label>Enter Quantity:</label>
                            <input type="number" name="quantity" id="EnterNumber" />
                        </div>
                        <div>
                            <button type="submit" onclick="addToCart()"class="btn btn-primary">Add To Cart</button>
                        </div>
                    </form>
  </div>`;
  });
}

function setlocal(id) {
  localStorage.productId = id;
}

getCategory();

const formRef = document.getElementById("addToCart");

function addToCart() {
  event.preventDefault();
  const formRef = document.querySelector("form");
  let Q = document.getElementById("EnterNumber");
  fetch("https://localhost:44349/api/cartItem/AddCartItem", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      cartId: localStorage.getItem("CartId"),
      productId: localStorage.getItem("productId"),
      quantity: Q.value,
    }),
  });
}
