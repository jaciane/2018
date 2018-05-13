$('form').submit(function (e) {
    if (!$(this).hasClass("search-form")) {
        $('#myModal').find('button[type="submit"]').prop("disabled", true);
        if ($(this).valid()) {
            e.preventDefault();
            var data;
            var contentType = "application/x-www-form-urlencoded";
            var processData = true;
            if ($(this).attr('enctype') == 'multipart/form-data') {
                data = new FormData($('.form-upload').get(0));
                contentType = false;
                processData = false;
            } else {
                data = $(this).serialize();
            }
            $.ajax({
                url: this.action,
                type: this.method,
                data: data,
                contentType: contentType,
                processData: processData,
            }).done(function (data) {
                verifyErrorExists(data);
            });
        } else {
            $('#myModal').find('button[type="submit"]').prop("disabled", false);
        }
    }
});

function verifyErrorExists(data) {
    var input = $(data);
    var url = $(input).find('#inputUrl').val();
    if ($(data).find('.validation-summary-errors').length) {
        $('.modal-content').html(data);
    }
    else if (url != null) {
        $('#myModal').modal('hide');
        location.href = url;
    }
    else {
        var flash = $(data).find('#flash-messages').html();
        $('#myModal').modal('hide');
        localStorage.setItem("flash-messages", flash);
        setTimeout(function () {
            sessionStorage.reloadAfterPageLoad = true;
            location.reload();
        }, 1000);
    }
};

//ADD VALIDATION TO FILE INPUT SIZE
$(function () {
    jQuery.validator.addMethod("filesize", function (value, element, params) {
        param = 25 * 1024 * 1024;
        return this.optional(element) || (element.files[0].size <= param);
    });

    $('input[type="file"]').each(function () {
        $(this).rules('add', {
            filesize: true,
            messages: {
                filesize: "Tamanho do arquivo superior a 25MB."
            }
        });
    });
});