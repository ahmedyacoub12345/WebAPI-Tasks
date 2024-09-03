async function ValidateEmail() {
  event.preventDefault();
  debugger;
  let url = "https://localhost:44349/api/Users/LoginPost";
  const email = document.getElementById("Email").value;
  const password = document.getElementById("Password").value;

  const response = await fetch(url, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      Username: email,
      Password: password,
    }),
  });

  const result = await response.json();

  if (response.ok) {
    localStorage.setItem("Token", result.token);
    console.log("Login successful:", result);
    alert("Login Successfuly");
    window.location.href = "/Categories/WebApiToFront.html";
  } else {
    console.error("Login failed:", result);
    alert("Please Enter a Valid Email or Password");
  }
}

document.getElementById("Login").addEventListener("submit", ValidateEmail);
