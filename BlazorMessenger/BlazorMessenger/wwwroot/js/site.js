function togglePassword(element) {
    if (element.type === "password") {
        element.type = "text";
    } else {
        element.type = "password";
    }
}

function BlazorScrollToId(id) {
    const element = document.getElementById(id);
    element.scrollIntoView({
        behavior: "smooth",
        block: "start",
        inline: "nearest"
    });
}