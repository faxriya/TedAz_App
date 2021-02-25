$(document).ready(function () {

    var ajx = $.ajax({
        url: '/Mention/DataNotes',
        data: { id: 1 },
        type: 'POST',
        success: function (tableData) {

            tableData = JSON.parse(tableData)
            var state = {
                'querySet': tableData,

                'page': 1,
                'rows': 4,
                'window': 3,
            }

            buildTable()

            function pagination(querySet, page, rows) {

                var trimStart = (page - 1) * rows
                var trimEnd = trimStart + rows

                var trimmedData = querySet.slice(trimStart, trimEnd)

                var pages = Math.round(tableData.length / rows);


                return {
                    'querySet': trimmedData,
                    'pages': pages,
                }
            }

            function pageButtons(pages) {
                var wrapper = document.getElementById('pagination-wrapper')

                wrapper.innerHTML = ``


                var maxLeft = (state.page - Math.floor(state.window / 2))
                var maxRight = (state.page + Math.floor(state.window / 2))

                if (maxLeft < 1) {
                    maxLeft = 1
                    maxRight = state.window
                }

                if (maxRight > pages) {
                    maxLeft = pages - (state.window - 1)

                    if (maxLeft < 1) {
                        maxLeft = 1
                    }
                    maxRight = pages
                }



                for (var page = maxLeft; page <= maxRight; page++) {
                    wrapper.innerHTML += `<button style="color:black" value=${page} class="page btn btn-sm btn-info">${page}</button>`
                }

                if (state.page != 1) {
                    wrapper.innerHTML = `<button style="color:black" value=${1} class="page btn btn-sm btn-info"> <img src="/img/arrLeft.png" alt="left"> </button>` + wrapper.innerHTML
                }

                if (state.page != pages) {
                    wrapper.innerHTML += `<button style="color:black" value=${pages} class="page btn btn-sm btn-info"> <img src="/img/arrRight.png" alt="left"></button>`
                }

                $('.page').on('click', function () {
                    // $('#table-body').empty()
                    var id = $(this).val()
                    state.page = Number($(this).val())
                    var data = null;
                    var ajx = $.ajax({
                        url: '/Mention/DataNotes',
                        global: false,
                        data: { id: id },
                        async: false,
                        type: 'POST',
                        success: function (data) {
                            data = data;
                            return data

                        },
                        error: function (resp) {
                            console.error(resp);
                        }
                    }).responseText;
                    var dataObject = jQuery.parseJSON(ajx);


                    buildTable(dataObject)
                })

            }

            function getMonth(string) {
                const date = new Date(string);
                const month = date.toLocaleString('default', { month: 'long' });
                return month;
            }
            function getToday(string) {

                if (string !== undefined) {
                    const date = new Date(string);
                    let toDay = new Date();
                    if (date.getDate() == toDay.getDate()) {
                        return "Bu gün"
                    }
                    else {
                        return ""
                    }
                }

            }
            function getHours(date) {

                var hours = date.getHours();
                var minutes = date.getMinutes();
                var ampm = hours >= 12 ? 'pm' : 'am';
                hours = hours % 12;
                hours = hours ? hours : 12; // the hour '0' should be '12'
                minutes = minutes < 10 ? '0' + minutes : minutes;
                var strTime = hours + ':' + minutes + ' ' + ampm;
                return strTime;
            }
            function buildTable(dataObject) {
                var table = $('#table-body')

                var data = pagination(state.querySet, state.page, state.rows)
                var myList = dataObject



                if (dataObject == undefined) {

                    myList = data.querySet
                }
                else {
                    myList = JSON.parse(dataObject)

                }

                $.each(myList, function (i, v) {

                    let div = `
                <div class="main-post">
                <div class="main-post__header">
                    <div class="row align-items-center">
                        <div class="col-3">
                            <div class="post-user d-flex align-items-center">
                                <div>
                                    <img src="${v.PostImageUrl}" alt="user">
                                </div>
                                <span class="user-name">${v.PostAuthor}</span>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="post-date d-flex align-items-center">
                                <span class="post-date__type">Post </span>
                                &nbsp <p>${getToday(v.PostDate)}/</p>
                                <span class="post-date__month">${getMonth(v.PostDate)}</span>
                                &nbsp
                                <time class="post-date__time">
                                    / ${getHours(new Date(v.PostDate))}
                                    
                                </time>
                            </div>
                        </div>
                        <div class="col-2">
                            <div class="post-location d-flex align-items-center">
                                <div>
                                    <img src="/img/post-icons/mark.png" alt="mark">
                                </div>
                                <span>${v.PostRegion},</span>
                                <span>${v.PostCity}</span>
                            </div>
                        </div>
                        <div class="col-3 ">
                            <div class="post-links temp-hidden">
                                <ul class="d-flex align-items-center">
                                    <li>
                                        <a href="#">
                                            <img src="/img/post-icons/2-layers (10).png" alt="">
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <img src="/img/post-icons/Path (10).png" alt="">
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <img src="/img/post-icons/Path (11).png" alt="">
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <img src="/img/post-icons/Path (12).png" alt="">
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <img src="/img/post-icons//3-layers (6).png" alt="">
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="main-post__body">
                    <div class="row">
                        <div class="col-2">
                            <div class="post-img">
                                <img src=" ${v.PostImageUrl}" alt="">
                            </div>
                        </div>
                        <div class="col-10">
                            <div class="post-title">
                                <p>
                                    ${v.PostText}
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="main-post__footer">
                    <div class="row">
                        <div class="col-12">
                            <div class="post-actions">
                                <ul class="d-flex">
                                    <li>
                                        <a class="like" presed="false" href="#">
                                            <i class="far fa-heart"></i>
                                            <span>${v.PostLikesCount}</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <img src="/img/post-icons/Path (14).png" alt="hearth">
                                            <span>${v.PostCommentsCount}</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <img src="/img/post-icons/3-layers (7).png" alt="hearth">
                                            <span>${v.PostRepostsCount}</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
`
                    $(".post-list").append(div);
                });

                pageButtons(data.pages)
            }




        },
        error: function (resp) {
            console.error(resp);
        }
    })

})