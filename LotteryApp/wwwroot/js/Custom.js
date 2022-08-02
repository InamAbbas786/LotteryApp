var drawInfoRequest = {
    n: 48,
    m: 6,
    r: 6
};
function IsNaN(value) {
    debugger
    if (Number.isInteger(value) === true)
        return true;
    return false;
}
function ValidationR() {
    var flag = false;
    if ($('#R').val() != '') {
        if (IsNaN(parseInt($('#R').val()))) {
            $('#ErrorlabelR').text('')
            flag = true;
        }
        else {
            $('#ErrorlabelR').text('Please enter the number only')
            flag = false;
        }
    }
    else {
        $('#ErrorlabelR').text('Please enter the number')
        flag = false;
    }
    return flag;
}
function ValidationN() {
    var flag = false;
    if ($('#N').val() != '') {
        if (IsNaN(parseInt($('#N').val()))) {
            $('#ErrorlabelN').text('')
            flag = true;
        }
        else {
            $('#ErrorlabelN').text('Please enter the number only')
            flag = false;
        }
    }
    else {
        $('#ErrorlabelN').text('Please enter the number')
        flag = false;
    }
    return flag;
}

function GetLottery() {
    $('#Lottery').empty();
    if (ValidationR() && ValidationN()) {
        drawInfoRequest.n = parseInt($('#N').val());
        drawInfoRequest.m = parseInt($('#M').val());
        drawInfoRequest.r = parseInt($('#R').val());
        $.ajax({
            url: '/Lotteries/GetLottery',
            type: 'POST',
            dataType: "html",
            data: { drawInfo: drawInfoRequest },
            success: function (response) {
                $('#Lottery').append(response);
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }
}