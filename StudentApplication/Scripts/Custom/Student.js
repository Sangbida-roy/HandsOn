$(document).ready(function () {

    $.ajax({
        url: '/Student/GetAllStudentsJson',
        type: 'GET',
        success: function (data) {
            console.log(data);
            var htmlText = '';
            for (var i = 0; i < data.length; i++) {
                var tr = '<tr><td>' + data[i].FN + '<td><td>' + data[i].LN + '<td><td>' + data[i].RollNo + '<td><td>' + data[i].Marks + '<tr><td>';
                htmlText += tr;
            }
            $('#tblData').html(htmlText);
        },

        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus);
            alert("Error: " + errorThrown);
        }
    });
});