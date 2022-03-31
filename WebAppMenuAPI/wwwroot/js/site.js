$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:7083/api/Menu/GetMenu',
        type: 'GET',
        success: function (data1) {
            var html = '';
            for (var index = 0; index < data1.length; index++) {
                console.log(data1[index]);
                html += ('<option value="' + data1[index].menuID + '">' + data1[index].cusine + '</option>');
            }
            $('#menuList').append(html);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("Status: " + textStatus);
            alert("Error: " + errorThrown);
        }
    });

    $('#menuList').change(function () {
        var menuselected = $('#menuList').val();
        //alert(menuselected);
        $.ajax({
            url: 'https://localhost:7083/api/Menu/GetChoice',
            type: 'GET',
            success: function (data1) {
                var html = '<option value=" ">' + "Select" + '</option>';
                for (var index = 0; index < data1.length; index++) {
                    console.log(data1[index]);
                    html += ('<option value="' + data1[index].choiceID + '">' + data1[index].category + '</option>');
                }
                $('#choiceList').html(html);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus);
                alert("Error: " + errorThrown);
            }
        });

    });
    $('#choiceList').change(function () {
        var choiceList = $('#choiceList').val();
        //alert(choiceList);
        var menuselected = $('#menuList').val();
        $.ajax({
            url: 'https://localhost:7083/api/Menu/GetMenuCard?Mid=' + menuselected + '&Cid=' + choiceList,

            type: 'GET',
            success: function (data1) {
                var html = '';
                for (var index = 0; index < data1.length; index++) {
                    console.log(data1[index]);
                    html += ('<tr>' +
                        '<td>' + data1[index].dishId + '</td>' +
                        '<td>' + data1[index].dishName + '</td>' +
                        '<td>' + data1[index].price + '</td>' +
                        '</tr>');
                }
                $('#tbody').html(html);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus);
                alert("Error: " + errorThrown);
            }
        });
    });
    $.ajax({
        url: 'https://localhost:7083/api/Menu/AddDish',
        type: 'POST',
        success: function (response) {

        }
    });

});