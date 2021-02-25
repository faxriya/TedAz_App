$(document).ready(function () {
    chartData();



    var mainHeigth = $("main").height();
    var monitoringHeigth = $(".logo-monitoring").outerHeight();
    var headerHeigth = $(".header-main").height();
    var dropMenu = $(".drop-menu__header").outerHeight();
    var dropMenuInner = $(".drop-menu__inner").outerHeight();
    var tabWrapper=0;
    if ($(".tab-wrapper").length ) {
        tabWrapper=$(".tab-wrapper").outerHeight(true);
    }
    

    $(window).on('resize', function () {
        $(".drop-wrapper ").css("height", `${$(window).outerHeight() - (monitoringHeigth + dropMenu
            ) + 10}px`);
            $("main").css("height", `${$(window).outerHeight() - ($(".logo-monitoring").outerHeight() +tabWrapper+ $(".header-main").outerHeight())}px`);
    });
    $(".drop-wrapper ").css("height", `${$(window).outerHeight() - (monitoringHeigth + dropMenu
    ) + 10}px`);
    $("main").css("height", `${$(window).outerHeight() - ($(".logo-monitoring").outerHeight() 
    +tabWrapper+ $(".header-main").outerHeight())}px`);


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

    //inner drop
    //$(".inner-report").click(function () {
    //    $(".report-drop").removeClass("show-drop")
    //    $(".response-drop").addClass("show-drop")

    //})
    $(".exit-drop__btn").click(function () {
        $(".exit-drop__el").toggleClass("show-drop");
    });
    $(document).on('click', function (event) {
        
        if (!$(event.target).closest('.exit-drop__btn').length) {
            if ($(".exit-drop__el").hasClass("show-drop")) {
                $(".exit-drop__el").removeClass("show-drop")
            }
        }
    });

    $(".report-show").click(function (e) {
        $(".report-drop").toggleClass("show-drop");
        if ($(".response-drop").hasClass("show-drop")) {
            $(".response-drop").removeClass("show-drop")
            $(".report-drop").removeClass("show-drop")
            e.preventDefault();

        }
    })
    $(document).on('click', function (event) {
        if (!$(event.target).closest('.report-show').length) {
            if ($('.report-drop').hasClass("show-drop")) {
                $('.report-drop.show-drop').removeClass('show-drop');
            }

        }
        if (!$(event.target).closest('.inner-report').length) {
            if ($('.response-drop').hasClass("show-drop")) {
                $('.response-drop.show-drop').removeClass('show-drop');
            }
        }


    });


    //$(".report-show").click(function () {
    //    $(".report-drop").toggleClass("show-drop");
    //});
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

    //var width = 100 / $('#tabs li').length;
    var width = 100 / $('#tabs li:not(".temp-hidden")').length;

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

    var pageName = $(".upper-nav__name span").text().trim()
    $(".drop-menu__list li").each(function () {
        var menuName = $(this).find('div').text().trim()
        if (pageName == menuName) {
            $(this).addClass("current")
            $(".clickable").find("svg").removeClass("choosen-menu")

            if (!$(this).find("svg").hasClass("choosen-menu")) {
                $(this).find("svg").addClass("choosen-menu")

            }
        }

    })


    let showFilter = $('.filter-show');
    $('#choose-filter').click(function () {
        $(this).css('display', 'none')
        $('.filter-show').toggleClass('active-filter-show')
        $('.input-buttons').addClass('active-input-buttons')
        $('.filter-not-choosen').addClass('d-none')
        $('#apply').css('display', 'inline-block')


    })
    $('#cancel-filter').click(function () {
        $('#choose-filter').css('display', 'block')
        $('.input-buttons').removeClass('active-input-buttons')
        $('.filter-show').removeClass('active-filter-show')
    })
    $(document).on('click', '.cancel-choosen-filter', function () {
        let value = $(this).parents('.filter-result__filter').data('value');
        $(`.check-block-input[data-tonal='${value}'] .choosen`).removeClass('active-choosen')
        $(`.check-block-input[data-tonal='${value}'] .un-choosen`).removeClass('active-un-choosen')

        $(`.check-block-input[data-tonal='${value}']`).removeAttr('data-toggle')
        $(this).parents('.filter-result__filter').remove()


    })
    $('#apply').click(function () {
        let filter = $('.filter-result__filter');


        let choosen = [];
        choosen.length = 0;
        let unChoosen = [];
        unChoosen.length = 0;

        console.log(choosen)
        console.log(unChoosen)


        $(".filter-result__filter").each(function (index, item) {
            var testdata = $(item).data('role');
            let title = $(item).data('group');


            let data1 = {};
            let data2 = {};


            if (testdata == 'in') {

                data1['in'] = $(item).data('value');
                data1['title'] = title;




                choosen.push(data1)

            };
            if (testdata == 'out') {


                data2['out'] = $(item).data('value');
                data2['title'] = title;

                unChoosen.push(data2)

            };


        });
        //if ($('.check-block-input').attr('data-toggle', 'in') || $('.check-block-input').attr('data-toggle', 'out')) {

        //    $('.check-block-input').removeAttr('data-toggle')
        //}
        //if ($('.choosen').hasClass('active-choosen')) {
        //    $('.choosen').removeClass('active-choosen')

        //}
        //if ($('.un-choosen').hasClass('active-un-choosen')) {
        //    $('.un-choosen').removeClass('active-un-choosen')

        //}
        // $('.input-buttons').removeClass('active-input-buttons');
        $('.filter-show').removeClass('active-filter-show');
        // $('#choose-filter').css('display','block')
        if ($(".filter-result__filter").length > 0) {
            $(this).css('display', 'none')
            $('#choose-filter').css('display', 'block')


        }

        var data = {
            fromdate: "",
            todate: "",
            in: choosen,
            out:unChoosen
        }
        if ($('#daterange').val().length == 10 || $('#daterange').val().length < 10) {
            var date = new Date($('#daterange').val());
            date.setMonth(date.getMonth() - 1);
            var dd = date.getDate();
            var mm = date.getMonth() + 1;
            var yyyy = date.getFullYear();
            if (dd < 10) {
                dd = '0' + dd;
            }

            if (mm < 10) {
                mm = '0' + mm;
            }
            prevMonth = mm + '.' + dd + '.' + yyyy;
            data = {
                fromdate: prevMonth,
                todate: $('#daterange').val(),
                in: choosen,
                out: unChoosen

            }

        }
        else {
            data = {
                fromdate: $('#daterange').attr("from"),
                todate: $('#daterange').attr("to"),
                in: choosen,
                out: unChoosen

            }
        }
        console.log(data)
        //$.ajax({
        //    url: `/Analytic/Data`,
        //    type: 'POST', 
        //    dataType: 'JSON',  
        //    data: {id:0, data: JSON.stringify(data) },             
        //    traditional: true,
        //    success: function (respData) {
        //        console.log(respData)

              
        //    },
        //    error: function (resp) {
        //        console.error(resp);
        //    }
        //})
        chartData(data);


    })
    $('#cancel-filter').click(function () {
        $('.filter-result__filter').remove();

        $('.filter-not-choosen').removeClass('d-none');

        if ($('.check-block-input').attr('data-toggle', 'in') || $('.check-block-input').attr('data-toggle', 'out')) {

            $('.check-block-input').removeAttr('data-toggle')
        }
        if ($('.choosen').hasClass('active-choosen')) {
            $('.choosen').removeClass('active-choosen')

        }
        if ($('.un-choosen').hasClass('active-un-choosen')) {
            $('.un-choosen').removeClass('active-un-choosen')

        }
    })
    $(document).on('click', '.choosen-click', function () {
        let un = $(this).find('.un-choosen');
        let input = $(this);
        let dataValue = input.parent('.check-block-input').data('tonal')
        let dataGroup = input.parents('.fl-el__row__block').data('group')
        let toggleInput = input.parent('.check-block-input');
        if (un.hasClass('active-un-choosen')) {
            un.removeClass('active-un-choosen')
        }
        if (toggleInput.attr('data-toggle') == 'in') {

            $('.filter-result').find(`.filter-result__filter[data-value='${dataValue}']`).remove();
            toggleInput.removeAttr('data-toggle');

        }
        else if (toggleInput.attr('data-toggle') == 'out') {

            // $('.filter-result').find(`.filter-result__filter[data-value='${dataValue}']`).attr('data-role', 'in');
            $('.filter-result').find(`.filter-result__filter[data-value='${dataValue}']`).remove();
            $('.filter-result').append(`<div data-role='in' data-group='${dataGroup}' data-value='${dataValue}'  class="filter-result__filter">
            <span class="minus"></span>
            <span class="filter-result__filter__group">${dataGroup}:</span>
            <span class="filter-result__filter__element">${dataValue}</span>
            <a class="cancel-choosen-filter" href="#"></a>
        </div>`)
            toggleInput.attr('data-toggle', 'in');




        }
        else {
            toggleInput.attr('data-toggle', 'in');

            $('.filter-result').append(`<div data-role='in' data-group='${dataGroup}' data-value='${dataValue}'  class="filter-result__filter">
            <span class="minus"></span>
            <span class="filter-result__filter__group">${dataGroup}:</span>
            <span class="filter-result__filter__element">${dataValue}</span>
            <a class="cancel-choosen-filter" href="#"></a>
        </div>`)
        }
        input.parent('.check-block-input').addClass('toggle-input')

        input.find('.choosen').toggleClass('active-choosen');


    });

    $(document).on('click', '.un-choosen-click', function () {
        let un = $(this).siblings('.choosen-click').find('.choosen');
        let input = $(this);

        let dataValue = input.parent('.check-block-input').data('tonal')
        let dataGroup = input.parents('.fl-el__row__block').data('group')
        let toggleInput = input.parent('.check-block-input');

        if (un.hasClass('active-choosen')) {
            un.removeClass('active-choosen')
        }
        input.siblings('.choosen-click').find('.un-choosen').toggleClass('active-un-choosen');


        if (toggleInput.attr('data-toggle') == 'out') {

            $('.filter-result').find(`.filter-result__filter[data-value='${dataValue}']`).remove();
            toggleInput.removeAttr('data-toggle');


        }
        else if (toggleInput.attr('data-toggle') == 'in') {

            // $('.filter-result').find(`.filter-result__filter[data-value='${dataValue}']`).attr('data-role', 'out');
            $('.filter-result').find(`.filter-result__filter[data-value='${dataValue}']`).remove();
            $('.filter-result').append(`<div data-role='out' data-group='${dataGroup}' data-value='${dataValue}'  class="filter-result__filter">
            <span class="minus"></span>
            <span class="filter-result__filter__group">${dataGroup}:</span>
            <span class="filter-result__filter__element">${dataValue}</span>
            <a class="cancel-choosen-filter" href="#"></a>
        </div>`)
            toggleInput.attr('data-toggle', 'out');




        }
        else {
            toggleInput.attr('data-toggle', 'out');

            $('.filter-result').append(`<div data-role='out' data-group='${dataGroup}' data-value='${dataValue}'  class="filter-result__filter">
            <span class="minus"></span>
            <span class="filter-result__filter__group">${dataGroup}:</span>
            <span class="filter-result__filter__element">${dataValue}</span>
            <a class="cancel-choosen-filter" href="#"></a>
        </div>`)
        }

    })
    //sec tab
    $('#filter li a:not(:first)').addClass('inactive');
    $('.fl-el').hide();
    $('.fl-el:first').show();

    var width = 100 / $('#filter li').length;
    $('#filter li').width(`${width}%`);
    $('.tabs-sec li').width(`${width}%`);


    $('#filter li a').click(function () {
        var t = $(this).attr('id');
        if ($(this).hasClass('inactive')) {
            $('#filter li a').addClass('inactive');
            $(this).removeClass('inactive');

            $('.fl-el').hide();
            $('#' + t + 'C').fadeIn('slow');
        }
    });
    // second-tab
    $('ul.tabs-sec li').click(function () {
        var tab_id = $(this).attr('data-tab');

        $('ul.tabs-sec li').removeClass('current');
        $('.tab-content').removeClass('current');

        $(this).addClass('current');
        $("#" + tab_id).addClass('current');
    })
    //settings
    $('.cb1').each(function () {
        $(this).on('click', function () {

            var choosen = $(this).attr('check-type');


            if ($(this).is(':checked')) {

                $(`.filter-block__check[check-type=${choosen}]`).find("input").prop('checked', true)
                $(`.filter-block__notification[check-type=${choosen}]`).addClass("opacity-1")


            }
            else {
                $(`.filter-block__check[check-type=${choosen}]`).find("input").prop('checked', false)
                $(`.filter-block__notification[check-type=${choosen}]`).removeClass("opacity-1")


            }
        });
    });
})