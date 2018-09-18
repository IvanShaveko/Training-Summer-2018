function toggleNav() {
    document.getElementById("Menu").classList.toggle("open");
};

function openbox(id) {
    if (document.getElementById(id).style.marginLeft == 0) {
        document.getElementById(id).style.marginLeft = '250px';
        document.querySelector('body').style.overflow = 'hidden';
    }
    else {
        document.getElementById(id).style = "inherit";
        document.querySelector('body').style.overflow = 'auto';
    }
}

var slideIndex = 1;
showSlides(slideIndex);

function plusSlides(n) {
    showSlides(slideIndex += n);
}

function currentSlide(n) {
    showSlides(slideIndex = n);
}

function showSlides(n) {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("demo");
    var captionText = document.getElementById("caption");
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