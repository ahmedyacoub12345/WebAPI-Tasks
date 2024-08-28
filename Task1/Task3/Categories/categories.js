async function getCategory() {
  const url = "https://localhost:44349/api/Categories/AllCategories/Category";
  const response = await fetch(url);
  const dataaaa = await response.json();
  console.log(dataaaa);

  var data = document.getElementById("CategoryInfo");

  dataaaa.forEach((category) => {
    data.innerHTML += `<div class="card" style="width: 18rem;">
    <img src="../images/${category.categoryImage}" class="card-img-top" alt="..."style="height: 18rem;">
    <div class="card-body">
    <h5 class="card-title">${category.categoryName}</h5>
    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
      <a href="/Orders/orders.html"><button value="${category.categoryId}" onclick="saveId(this)" class="btn btn-primary">Open</button></a>
  </div>
</div>`;
  });
}
function saveId(button) {
  let GetId = button.value;
  localStorage.setItem("categoryId", GetId);
}

getCategory();
saveId();
