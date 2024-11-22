window.CreateUser = function () {
    const userForm = document.getElementById("userForm");
    if (userForm) {
        userForm.dispatchEvent(new Event("submit")); // Trigger the submit event
    } else {
        console.error("User form not found.");
    }
};