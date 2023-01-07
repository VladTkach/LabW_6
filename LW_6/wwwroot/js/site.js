// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


const hamburger = document.querySelector(".menu__icon")
const nav = document.querySelector(".nav")

hamburger.addEventListener("click", () => {
    hamburger.classList.toggle("active")
    nav.classList.toggle("active")
})