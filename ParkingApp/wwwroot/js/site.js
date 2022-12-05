// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var sidebarOpen = false;
var sidebar = document.getElementById("sidebar");

function openSidebar() {
    if (!sidebarOpen) {
        sidebar.classList.add("sidebar-responsive");
        sidebarOpen = true;
    }
}

function closeSidebar() {
    if (sidebarOpen) {
        sidebar.classList.remove("sidebar-responsive");
        sidebarOpen = false;
    }
}

// SIDEBAR TOGGLE

var sidebarOpen = false;
var sidebar = document.getElementById("sidebar1");

function openSidebar() {
    if (!sidebarOpen) {
        sidebar.classList.add("sidebar-responsive1");
        sidebarOpen = true;
    }
}

function closeSidebar() {
    if (sidebarOpen) {
        sidebar.classList.remove("sidebar-responsive1");
        sidebarOpen = false;
    }
}


//slide comment homepage
let slideIndex = 1;
showSlides(slideIndex);

function plusSlides(n) {
    showSlides(slideIndex += n);
}

function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    let i;
    let slides = document.getElementsByClassName("mySlides");
    let dots = document.getElementsByClassName("dot");
    if (n > slides.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = slides.length }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
}
//end

function totalPay() {
    var Date_Arrival = document.getElementById("Date_Arrival").value;
    var Date_Depature = document.getElementById("Date_Depature").value;
    var Daily_Rate = document.getElementById("Daily_Rate").value;

    const dateOne = new Date(Date_Arrival);
    const dateTwo = new Date(Date_Depature);
    const time = Math.abs(dateTwo - dateOne);
    const days = Math.ceil(time / (1000 * 60 * 60 * 24));
    const payment = Math.ceil(days * Daily_Rate);
    console.log(days);
    console.log(payment);
    
    document.getElementById("output").innerHTML = days;
}


//switch between daily and monthly booking driver
let monthly = document.getElementById("monthly");
let daily = document.getElementById("daily");

function changedaily() {
    let monthly = document.getElementById("monthly");
    let daily = document.getElementById("daily");
    monthly.style.display = "none";
    daily.style.display = "block";
}
function changemonthly() {
    let monthly = document.getElementById("monthly");
    let daily = document.getElementById("daily");
    daily.style.display = "none";
    monthly.style.display = "block";
}

