async function Register() {
  event.preventDefault();

  let url = "https://localhost:44349/api/Users/Register";

  const formData = new FormData(document.getElementById("RegisterForm"));

  const response = await fetch(url, {
    method: "POST",

    body: formData,
  });

  const result = await response.json();

  if (response.ok) {
    console.log("Register successful:", result);
    alert("Registration Successful");
    window.location.href = "/Login_Register/Login.html";
  } else {
    console.error("Registration failed:", result);
    alert("Please Enter a Valid Email or Password");
  }
}

document.getElementById("RegisterForm").addEventListener("submit", Register);
