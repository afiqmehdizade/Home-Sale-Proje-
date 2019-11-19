$(function () {

    $(document).on("click", ".buttons button", function () {
        $(".buttons button").removeClass("active")
        $(this).addClass("active");
    })

    $(document).ready(function () {
        $(".owl-carousel").owlCarousel();
    });

    $('.owl-carousel').owlCarousel({
        rtl: false,
        loop: false,
        margin: 10,
        nav: true,
        dots: false,
        responsive: {
            200: {
                items: 1
            },
            655: {
                items: 2
            },
            800: {
                items: 3
            },
            1000: {
                items: 5
            }
        }
    })

    $(document).on("click", "#buttonblock",function () {
        $(".blockaccount").css("visibility", "visible")
        $("#cngform").css("display", "none")
    });
});

































// $('.grid').isotope({
//     // options
//     itemSelector: '.grid-item',
//     layoutMode: 'fitRows'
// });

// $(".vector").click(function () {
//     $(".grid").isotope({
//         filter: '.vector'
//     })
// });
// $(".raster").click(function () {
//     $(".grid").isotope({
//         filter: '.raster'
//     })
// });
// $(".ui").click(function () {
//     $(".grid").isotope({
//         filter: '.ui'
//     })
// });
// $(".printing").click(function () {
//     $(".grid").isotope({
//         filter: '.printing , .raster'
//     })
// });
// $(".all").click(function () {
//     $(".grid").isotope({
//         filter: '.grid-item'
//     })
// });