// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

async function closetoast(time = 0)
{
    var toast = document.getElementById("mytoast");
    for (let i = 0; i < time; i++) {
        await sleep(1000);
    }
    toast.style.display = "none";
    toast.style.opacity = 0;
    toast.style.zIndex = -10;
}

async function closeProfileToast() {
    var toast = document.getElementById("profileToast");
    toast.style.opacity = 0;
    toast.style.zIndex = -10;
}

async function showProfile() {
    var toast = document.getElementById("profileToast");
    toast.style.opacity = 1;
    toast.style.zIndex = 10;
}
