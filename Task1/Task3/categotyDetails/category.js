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
      <a href="categotyDetails/category.html" onclick="setlocal(${product.productId})" class="btn btn-primary">Add To Cart</a>
  </div>
  </div>`;
  });
}

function setlocal(id) {
  localStorage.productId = id;
}
function saveId(button) {
  let GetId = button.value;
  localStorage.setItem("productId", GetId);
}

getCategory();
