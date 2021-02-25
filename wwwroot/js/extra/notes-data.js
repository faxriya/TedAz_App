$(document).ready(function () {

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
    $.ajax({
        url: `/Mention/DataNotes`,
        type: 'POST',
        success: function (data) {
            data = JSON.parse(data);
            console.log(data);
            $.each(data, function (i, v) {
                console.log(v);
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
                                    / ${getHours(new Date(v.PostTime))}
                                    
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
                            <div class="post-links ">
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
                //$(".post-list").append(div);
            });


        },
        error: function (resp) {
            console.error(resp);
        }
    })
    $.ajax({
        url: `/Analytic/DataWords`,
        type: 'POST',
        success: function (data) {

            dataWord = JSON.parse(data);

            for (var i = 0; i < dataWord.length; i++) {



                let div = `<li>
                                            <div class="list-title">
                                                <div class="j-between align-items-center">
                                                    <label>${dataWord[i].name}</label>
                                                    <div class="list-title__count">
                                                       ${dataWord[i].count}
                                                    </div>
                                                </div>
                                                <progress class="progress" value="${dataWord[i].count}" max="1000000"> 32% </progress>
                                            </div>
                                        </li>`
                $(".left-side__list-words").append(div);

            }

        },
        error: function (resp) {
            console.error(resp);
        }
    })
})