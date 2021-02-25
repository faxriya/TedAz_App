$(document).ready(function () {




    var mainHeigth = $("main").height();
    var monitoringHeigth = $(".logo-monitoring").outerHeight();
    var headerHeigth = $(".header-main").height();
    var dropMenu = $(".drop-menu__header").outerHeight();
    var dropMenuInner = $(".drop-menu__inner").outerHeight();


    $(window).on('resize', function () {
        $(".drop-wrapper ").css("height", `${$(window).outerHeight() - (monitoringHeigth + dropMenu
            ) + 10}px`);
            $("main").css("height", `${$(window).outerHeight() - ($(".logo-monitoring").outerHeight() + $(".header-main").outerHeight())}px`);
    });
    $(".drop-wrapper ").css("height", `${$(window).outerHeight() - (monitoringHeigth + dropMenu
    ) + 10}px`);
    $("main").css("height", `${$(window).outerHeight() - ($(".logo-monitoring").outerHeight() + $(".header-main").outerHeight())}px`);


    $(".burger-btn").click(function () {
        $(".burger-menu").toggleClass("show-burger")
    })


    $(".menu-btn").click(function () {



        if (!$(".drop-menu__inner").hasClass(("show-drop"))) {
            $(".drop-menu__inner").addClass("show-drop");
            return
        }
        $(".drop-menu__inner").removeClass("show-drop");
    });

    $(".clickable").click(function () {
        $(".clickable").find("svg").removeClass("choosen-menu")

        if (!$(this).find("svg").hasClass("choosen-menu")) {
            $(this).find("svg").addClass("choosen-menu")

        }

    })

    $(".header-drop").click(function () {
        $(".header-search").toggleClass("show-drop");
    });

    $(document).on('click', function (event) {
        if (!$(event.target).closest('.header-drop').length) {
            if ($(".header-search").hasClass("show-drop")) {
                $(".header-search").removeClass("show-drop")
            }
        }
    });

    $(".left-side__navigation ul li a").click(function () {
        if ($(this).hasClass("active-side")) {
            return
        }
        $(".left-side__navigation ul li a").removeClass("active-side")

        $(this).addClass("active-side")
        if ($(this).attr('side') == "tags") {

            $(this).closest('ul').toggleClass("show-tags");
            $(".left-side__list-tags , .left-side__list-words").toggleClass("show-tags");

        }
        else {
            $(this).closest('ul').removeClass("show-tags")
            $(".left-side__list-tags , .left-side__list-words").removeClass("show-tags");
        }

    })

    $(".like").click(function () {
        if ($(this).attr("presed") == "false") {
            $(this).find("i").css("color", "red");
            $(this).attr("presed", "true")

            return
        }
        else {
            $(this).attr("presed", "false")

            $(this).find("i").css("color", "#5987ff")

        }

    });

    $(".gallery-element__title .more-info-button").click(function () {

        $(this).siblings(".text-hider").toggleClass("show-text")
    });

    // main-tabs
    $('#tabs li a:not(:first)').addClass('inactive');
    $('.tab-el').hide();
    $('.tab-el:first').show();

    var width = 100 / $('#tabs li').length;
    $('#tabs li').width(`${width}%`);
    $('.tabs-sec li').width(`${width}%`);


    $('#tabs li a').click(function () {
        var t = $(this).attr('id');
        if ($(this).hasClass('inactive')) {
            $('#tabs li a').addClass('inactive');
            $(this).removeClass('inactive');

            $('.tab-el').hide();
            $('#' + t + 'C').fadeIn('slow');
        }
    });
    // second-tab
    $('ul.tabs-sec li').click(function(){
		var tab_id = $(this).attr('data-tab');

		$('ul.tabs-sec li').removeClass('current');
		$('.tab-content').removeClass('current');

		$(this).addClass('current');
		$("#"+tab_id).addClass('current');
	})
    //settings
    $('.cb1').each(function () {
        $(this).on('click', function () {

            var choosen = $(this).attr('check-type');
            

            if ($(this).is(':checked')) {
             
              $(`.filter-block__check[check-type=${choosen}]`).find("input").prop('checked', true)
              $(`.filter-block__notification[check-type=${choosen}]`).addClass("opacity-1")
                

            }
            else{
                $(`.filter-block__check[check-type=${choosen}]`).find("input").prop('checked', false)
              $(`.filter-block__notification[check-type=${choosen}]`).removeClass("opacity-1")


            }
        });
    });

})
