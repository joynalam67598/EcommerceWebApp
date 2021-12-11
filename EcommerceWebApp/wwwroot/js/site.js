$('.owl-carousel').owlCarousel({
        autoplay: true,
        autoplayhoverpause: true,
        autoplaytimeout: 1000,
        loop: true,
        nav: true,
        responsive: {
            480: { items: 2 }, // from zero to 480 screen width 4 items
            768: { items: 4 }, // from 480 screen widthto 768 6 items
            1024: {
                items: 6   // from 768 screen width to 1024 8 items
            }
        },
    });