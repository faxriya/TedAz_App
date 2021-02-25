$(document).ready(function () {
    $.ajax({
        url: `/Analytic/Filters`,//link to source filter
        type: 'POST',
        data: { id: 4 },
        success: function (data) {
            data = JSON.parse(data);
            for (let i = 0; i < data.length; i++) {
                var li = `
                                          <li>
                                            <div class="check-block">
                                                <div data-tonal='${data[i].name}'
                                                     class="check-block-input d-flex align-items-baseline position-relative">
                                                    <div class="d-flex choosen-click">
                                                        <div class="checkbox-def">
                                                            <span class="choosen"></span>
                                                            <span class="un-choosen"></span>

                                                        </div>
                                                        <span>'${data[i].name}'</span>
                                                    </div>
                                                    <div class="un-choosen-click">
                                                        <span>
                                                            <div class="minus"></div>
                                                        </span>
                                                    </div>
                                                </div>


                                            </div>
                                        </li>
                                        `
                $(".append-source").append(li)
                
            }



        },
        error: function (resp) {
            console.error(resp);
        }
    })
    $.ajax({
        url: `/Analytic/Filters`,//link to authors filter
        type: 'POST',
        data: { id: 6 },
        success: function (data) {
            data = JSON.parse(data);

            for (let i = 0; i < data.length; i++) {
                var li = `
                                          <li>
                                            <div class="check-block">
                                                <div data-tonal='${data[i].name}'
                                                     class="check-block-input d-flex align-items-baseline position-relative">
                                                    <div class="d-flex choosen-click">
                                                        <div class="checkbox-def">
                                                            <span class="choosen"></span>
                                                            <span class="un-choosen"></span>

                                                        </div>
                                                        <span>'${data[i].name}'</span>
                                                    </div>
                                                    <div class="un-choosen-click">
                                                        <span>
                                                            <div class="minus"></div>
                                                        </span>
                                                    </div>
                                                </div>


                                            </div>
                                        </li>
                                        `
                $(".append-authors").append(li)

            }



        },
        error: function (resp) {
            console.error(resp);
        }
    })
    $.ajax({
        url: `/Analytic/Filters`,//link to sharingSource filter
        type: 'POST',
        data: { id: 11 },
        success: function (data) {
            data = JSON.parse(data);

            for (let i = 0; i < data.length; i++) {
                var li = `
                                          <li>
                                            <div class="check-block">
                                                <div data-tonal='${data[i].name}'
                                                     class="check-block-input d-flex align-items-baseline position-relative">
                                                    <div class="d-flex choosen-click">
                                                        <div class="checkbox-def">
                                                            <span class="choosen"></span>
                                                            <span class="un-choosen"></span>

                                                        </div>
                                                        <span>'${data[i].name}'</span>
                                                    </div>
                                                    <div class="un-choosen-click">
                                                        <span>
                                                            <div class="minus"></div>
                                                        </span>
                                                    </div>
                                                </div>


                                            </div>
                                        </li>
                                        `
                $(".append-sharingSource").append(li)

            }



        },
        error: function (resp) {
            console.error(resp);
        }
    })
})