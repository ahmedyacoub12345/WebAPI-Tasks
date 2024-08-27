async function getCategory() {
  const url = "https://localhost:44349/api/Categories/AllCategories/Category";
  const response = await fetch(url);
  const dataaaa = await response.json();
  console.log(dataaaa);

  var data = document.getElementById("tableBody");
  dataaaa.forEach((category) => {
    data.innerHTML += `
    <tr>
      <th scope="row">${category.categoryId}</th>
      <td>${category.categoryName}</td>
      <td><img src="/images/${category.categoryImage}" style="height: 100px; width: 100px;" class="card-img-top" alt="${category.categoryImage}"></td>
      <td><a href="/Dashboard/EditCategory/EditCategory.html" onclick = "setLocalStorage(${category.categoryId})">Edit</a></td>
    </tr>
    `;
  });
}
function setLocalStorage(id) {
  localStorage.categoryId = id;
}
getCategory();
