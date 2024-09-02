async function Register(event) {
  event.preventDefault(); // Prevent default form submission

  let url = "https://localhost:44349/api/Users/Register";

  // Create FormData from the form element
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

// Attach Register function to form submission
document.getElementById("RegisterForm").addEventListener("submit", Register);
