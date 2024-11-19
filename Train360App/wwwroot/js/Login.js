document.addEventListener("DOMContentLoaded", () => {
    const emailInput = document.getElementById("email");
    const passwordInput = document.getElementById("password");
    const loginForm = document.getElementById("loginForm");

    // Regex pattern for email validation
    const emailPattern = /^[^@\s]+@[^@\s]+\.[^@\s]+$/;

    // Real-time validation for email
    emailInput.addEventListener("input", () => {
        const emailError = document.getElementById("emailError");
        if (emailError) emailError.remove();

        const email = emailInput.value.trim();
        if (!emailPattern.test(email)) {
            const error = document.createElement("p");
            error.id = "emailError";
            error.style.color = "red";
            error.textContent = "Invalid email format.";
            emailInput.after(error);
        } else if (email.length > 40) {
            const error = document.createElement("p");
            error.id = "emailError";
            error.style.color = "red";
            error.textContent = "Email should not exceed 40 characters.";
            emailInput.after(error);
        }
    });

    // Real-time validation for password
    passwordInput.addEventListener("input", () => {
        const passwordError = document.getElementById("passwordError");
        if (passwordError) passwordError.remove();

        const password = passwordInput.value.trim();
        if (password.length > 8) {
            passwordInput.value = password.substring(0, 8); // Limit input to 8 characters
            const error = document.createElement("p");
            error.id = "passwordError";
            error.style.color = "red";
            error.textContent = "Password cannot exceed 8 characters.";
            passwordInput.after(error);
        }
    });

    // On login button click
    loginForm.addEventListener("submit", (event) => {
        event.preventDefault(); // Prevent default form submission behavior

        const email = emailInput.value.trim();
        const password = passwordInput.value.trim();

        // Clear previous messages
        const emailError = document.getElementById("emailError");
        const passwordError = document.getElementById("passwordError");
        if (emailError) emailError.remove();
        if (passwordError) passwordError.remove();

        let isValid = true;

        // Validate email on submission
        if (!emailPattern.test(email)) {
            const error = document.createElement("p");
            error.id = "emailError";
            error.style.color = "red";
            error.textContent = "Invalid email format.";
            emailInput.after(error);
            isValid = false;
        } else if (email.length > 40) {
            const error = document.createElement("p");
            error.id = "emailError";
            error.style.color = "red";
            error.textContent = "Email should not exceed 40 characters.";
            emailInput.after(error);
            isValid = false;
        }

        // Validate password on submission
        if (password.length !== 8) {
            const error = document.createElement("p");
            error.id = "passwordError";
            error.style.color = "red";
            error.textContent = "Password must be exactly 8 characters.";
            passwordInput.after(error);
            isValid = false;
        }

        // If validation passes, submit the form
        if (isValid) {
            fetch("/Login/Login", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ email, password }),
            })
                .then((response) => {
                    if (response.ok) {
                        // Redirect on success
                        window.location.href = "/Login/Login"; // Adjust target as needed
                    } else {
                        // Show error message box
                        alert("Invalid email or password. Please try again.");
                    }
                })
                .catch((err) => {
                    console.error("Login failed:", err);
                    alert("Something went wrong. Please try again later.");
                });
        }
    });
});
