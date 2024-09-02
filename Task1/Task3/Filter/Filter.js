document.getElementById("Name").addEventListener("input", async function () {
  const username = this.value.trim();
  if (!username) {
    document.getElementById("userInfo").innerHTML = "";
    return;
  }

  const url = `https://localhost:44349/api/Users/${username}`;
  try {
    const response = await fetch(url);
    if (!response.ok) {
      throw new Error("User not found");
    }

    const user = await response.json();
    displayUserInfo(user);
  } catch (error) {
    console.error("Error fetching user data:", error);
    document.getElementById("userInfo").innerHTML =
      "User not found or error occurred.";
  }
});

function displayUserInfo(user) {
  const userInfo = document.getElementById("userInfo");
  userInfo.innerHTML = `
        <h3>User Details</h3>
        <p><strong>Username:</strong> ${user.username}</p>
        <p><strong>ID:</strong> ${user.userId}</p>
        <p><strong>Email:</strong> ${user.email}</p>
        <p><strong>Password:</strong> ${user.password}</p>
    `;
}
