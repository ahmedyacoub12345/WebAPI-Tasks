import { initializeApp } from "https://www.gstatic.com/firebasejs/10.13.1/firebase-app.js";
import {
  getAuth,
  GoogleAuthProvider,
  signInWithPopup,
} from "https://www.gstatic.com/firebasejs/10.13.1/firebase-auth.js";

// Your Firebase configuration
const firebaseConfig = {
  apiKey: "AIzaSyAv5vCoLdqubm_IJAOjNlgF7o9zo-1-VfE",
  authDomain: "login-3e8e4.firebaseapp.com",
  projectId: "login-3e8e4",
  storageBucket: "login-3e8e4.appspot.com",
  messagingSenderId: "251369161445",
  appId: "1:251369161445:web:ef0c157a6b0cdcdb1a0a0c",
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const auth = getAuth(app);
auth.languageCode = "en";
const provider = new GoogleAuthProvider();

// Get the Google login button element
const googleLogin = document.getElementById("google-login-btn");

if (googleLogin) {
  googleLogin.addEventListener("click", async function () {
    try {
      console.log("Button clicked, attempting login...");
      const result = await signInWithPopup(auth, provider);

      // The signed-in user info.
      const user = result.user;
      console.log("User:", user);

      // Redirect to a new page
      window.location.href = "../Categories/WebApiToFront.html";
    } catch (error) {
      // Handle Errors here.
      console.error("Error during login:", error);
      alert("Error during login. Please try again.");
    }
  });
} else {
  console.error("Login button not found");
}
